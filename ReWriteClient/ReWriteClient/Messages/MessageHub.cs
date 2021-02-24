using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using ReWriteClient.Data;
using ReWriteClient.Events;
using System;
using System.Collections.Generic;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public class MessageHub : Hub
    {
        public readonly Messages Messages = Messages.Instance;

        private readonly HubConnection messageHubConnection;
        private readonly string username;


        public static event MessageHubDelegate OnServerLogReceived;
        public static event OptionsDelegate OnUpdateOptionsReceived;

        public Dictionary<string, List<ButtonTemplate>> Options;

        public MessageHub(HubConnection connection, string username)
        {
            this.messageHubConnection = connection;
            this.username = username;

            this.SubscribeToMessages(connection);
        }

        public void SubscribeToMessages(HubConnection connection)
        {
            foreach (var (holderName, dict) in Messages.MessageMappings)
            {
                foreach (var (messageName, method) in dict)
                {
                    connection.On<Request>(messageName, message =>
                    {
                        var isSuccessful = method.Method.Invoke(message.ManipulationType, message.Value);

                        SendServerLogReceived(this, new MessageHubArgs { Viewer = message.ViewerName, MethodName = messageName, Value = message.Value } );

                        this.SendResponseMessage(new Response
                        {
                            HostConnectionId = message.HostConnectionId,
                            HostName = message.HostName,
                            ViewerName = message.ViewerName,
                            Cost = message.Cost,
                            IsSuccessful = isSuccessful
                        });
                    });
                }
            }

            connection.On<Option>("SendUpdateOptionsMessage", message =>
            {
                SendUpdateOptionsReceived(this, new OptionsArgs { Options = message.Options });
            });
        }

        public async void SendResponseMessage(Response response)
        {
            try
            {
                await this.messageHubConnection.InvokeAsync("SendResponseMessage", response);
            }
            catch(Exception e)
            {
                Logger.Instance.Error(e.Message, "SendResponseMessage");
            }
        }

        public async void SendDynamicUIResponseMessage(List<string> options)
        {
            try
            {
                var response = new DynamicUIResponse
                {
                    HostName = this.username,
                    HostConnectionId = this.messageHubConnection.ConnectionId,
                    Options = options
                };

                await this.messageHubConnection.InvokeAsync("SendDynamicUIResponseMessage", response);
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "SendResponseMessage");
            }
        }

        public void UpdateOptionsMessage()
        {
            try
            {
                this.messageHubConnection.InvokeAsync("RequestUpdateOptionsMessage", username);
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "UpdateOptionsMessage");
            }
        }

        public static void SendServerLogReceived(object sender, MessageHubArgs e)
        {
            OnServerLogReceived?.Invoke(sender, e);
        }

        private static void SendUpdateOptionsReceived(object sender, OptionsArgs e)
        {
            OnUpdateOptionsReceived?.Invoke(sender, e);
        }
    }
}