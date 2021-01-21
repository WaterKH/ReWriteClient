using Microsoft.AspNetCore.SignalR.Client;
using ReWriteClient.Data;
using ReWriteClient.Events;
using ReWriteClient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Waterkh.Common.Memory;

namespace ReWriteClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HubConnection connection;
        private MessageHub messageHub;
        private readonly MemoryProcessor memoryProcessor = MemoryProcessor.Instance;

        //private readonly string connectionUrl = "https://localhost:44303/MessageHub";
        private readonly string connectionUrl = "https://memoryscape.azurewebsites.net/MessageHub";

        private bool serverConnected = false;
        private bool clientConnected = false;

        public MainWindow()
        {
            InitializeComponent();

            // TODO Do these need to be static?
            MessageHub.OnServerLogReceived += AddToServerLog;
            MessageHub.OnUpdateOptionsReceived += UpdateOptionsReceived;
        }

        #region View Methods

        private void ClientConnectClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.memoryProcessor.ConnectToProcess())
                {
                    this.ClientConnectionStatusMessage.Content = $"Connection Status: Connected";

                    this.memoryProcessor.Process.Exited += UpdateClientConnectionStatus;

                    Logger.Instance.Info("Client Connection Established", "ClientConnectClicked");

                    this.clientConnected = true;

                    return;
                }

                this.ClientConnectionStatusMessage.Content = $"Connection Status: Not Connected";
            }
            catch (Exception ex)
            {
                this.ClientConnectionStatusMessage.Content = ex.Message;

                Logger.Instance.Error(ex.Message, "ClientConnectClicked");
            }

            this.clientConnected = false;
        }

        private async void ServerConnectClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this.serverConnected)
                {
                    if (string.IsNullOrEmpty(this.UsernameInput.Text))
                    {
                        this.ServerConnectionStatusMessage.Content = $"Please input your Username to connect.";

                        this.serverConnected = false;

                        return;
                    }

                    await this.ConnectToServer(this.UsernameInput.Text);

                    this.serverConnected = true;
                }
            }
            catch (Exception ex)
            {
                this.ServerConnectionStatusMessage.Content = ex.Message;

                this.serverConnected = false;

                Logger.Instance.Error(ex.Message, "ServerConnectClicked");
            }
        }

        private void UpdateOptions(object sender, RoutedEventArgs e)
        {
            if (messageHub == null)
                return;

            messageHub.UpdateOptionsMessage();
        }

        #endregion View Methods

        private void UpdateClientConnectionStatus(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.ClientConnectionStatusMessage.Content = $"Connection Status: Disconnected";

                this.clientConnected = false;

                Logger.Instance.Error("Client Connection Disconnected Forcebly", "UpdateClientConnectionStatus");
            });
        }

        private async Task ConnectToServer(string username)
        {
            this.connection = new HubConnectionBuilder().WithUrl($"{this.connectionUrl}?username={username}").Build();

            await connection.StartAsync();

            this.connection.Closed += async (error) =>
            {
                await Task.Delay(1000);

                this.Dispatcher.Invoke(() =>
                {
                    this.ServerConnectionStatusMessage.Content = $"Connection Status: {this.connection.State}";

                    this.serverConnected = false;

                    Logger.Instance.Error("Server Connection Disconnected Forcebly", "ConnectToServer");
                });

                await this.connection.StartAsync();
            };

            this.Dispatcher.Invoke(() =>
            {
                this.ServerConnectionStatusMessage.Content = $"Connection Status: {this.connection.State}";

                this.serverConnected = true;

                Logger.Instance.Info("Server Connection Established", "ConnectToServer");
            });

            this.messageHub = new MessageHub(this.connection, username);
        }

        public Task AddToServerLog(object sender, MessageHubArgs args)
        {
            this.ServerLog.Items.Add(new ServerLogItem { Viewer = args.Viewer, MethodName = args.MethodName, Value = args.Value });

            Logger.Instance.Info($"{args.Viewer} sent {args.MethodName} with {args.Value}", "AddToServerLog");

            return null;
        }

        public Task UpdateOptionsReceived(object sender, OptionsArgs args)
        {
            if (messageHub.Options == null)
                messageHub.Options = args.Options;
            
            this.Dispatcher.Invoke(() =>
            {
                ManualCommands.Items.Clear();
            });
            
            foreach (var (group, buttons) in messageHub.Options)
            {
                this.Dispatcher.Invoke(() =>
                {
                    var tabItem = new TabItem
                    {
                        Header = group.ToString(),
                        Content = new ScrollViewer
                        {
                            HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                            Content = new WrapPanel()
                        }
                    };

                    foreach (var button in buttons)
                    {
                        var uiButton = new Button
                        {
                            Content = button.Name,
                            Margin = new Thickness(10, 10, 10, 10)
                        };

                        uiButton.Click += (sender, e) => { this.OpenPopup(button.SubMethodParams, group); };

                        ((WrapPanel)((ScrollViewer)tabItem.Content).Content).Children.Add(uiButton);
                    }

                    ManualCommands.Items.Add(tabItem);
                });
            }

            return null;
        }

        public void OpenPopup(List<ButtonTemplate> subButtons, string group)
        {
            var methodsInGroup = Messages.Messages.Instance.MessageMappings[group];

            this.Dispatcher.Invoke(() =>
            {
                ((WrapPanel)(SubCommands.Content)).Children.Clear();

                foreach (var subButton in subButtons)
                {
                    var uiButton = new Button
                    {
                        Content = subButton.Name,
                        Margin = new Thickness(10, 10, 10, 10)
                    };

                    var method = methodsInGroup.FirstOrDefault(x => x.Key == subButton.MethodName).Value;

                    uiButton.Click += (sender, e) => { method.Invoke(subButton.ManipulationType, subButton.Value.ToString()); ClosePopup(null, null); };

                    ((WrapPanel)(SubCommands.Content)).Children.Add(uiButton);
                }

                ClosePopupButton.Visibility = Visibility.Visible;
            });

            SubCommandsPopup.IsOpen = true;
        }

        public void ClosePopup(object sender, RoutedEventArgs e)
        {
            SubCommandsPopup.IsOpen = false;

            ClosePopupButton.Visibility = Visibility.Hidden;
        }
    }
}