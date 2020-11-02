using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using ReWriteClient.Data;
using ReWriteClient.Events;
using ReWriteClient.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private readonly string connectionUrl = "https://localhost:44362/MessageHub";
        //private readonly string connectionUrl = "https://memoryscape.azurewebsites.net/MessageHub";

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

                    this.clientConnected = true;

                    return;
                }

                this.ClientConnectionStatusMessage.Content = $"Connection Status: Not Connected";
            }
            catch (Exception ex)
            {
                this.ClientConnectionStatusMessage.Content = ex.Message;
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
                });

                await this.connection.StartAsync();
            };

            this.Dispatcher.Invoke(() =>
            {
                this.ServerConnectionStatusMessage.Content = $"Connection Status: {this.connection.State}";

                this.serverConnected = true;
            });

            this.messageHub = new MessageHub(this.connection, username);
        }

        public Task AddToServerLog(object sender, MessageHubArgs args)
        {
            this.ServerLog.Items.Add(new ServerLogItem { Viewer = args.Viewer, MethodName = args.MethodName, Value = args.Value });

            return null;
        }

        public Task UpdateOptionsReceived(object sender, OptionsArgs args)
        {
            if (messageHub.Options == null)
                messageHub.Options = args.Options;

            ManualCommands.Items.Clear();

            foreach (var (group, buttons) in messageHub.Options)
            {
                var methodsInGroup = Messages.Messages.Instance.MessageMappings[group];

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
                    foreach (var subButtons in button.SubMethodParams)
                    {
                        var uiButton = new Button
                        {
                            Content = subButtons.Name,
                            Margin = new Thickness(10, 10, 10, 10)
                        };

                        var method = methodsInGroup.FirstOrDefault(x => x.Key == subButtons.MethodName).Value;

                        uiButton.Click += (sender, e) => { method.Invoke(subButtons.ManipulationType, subButtons.Value.ToString()); };

                        ((WrapPanel)((ScrollViewer)tabItem.Content).Content).Children.Add(uiButton);
                    }
                }

                ManualCommands.Items.Add(tabItem);
            }

            return null;
        }
    }
}