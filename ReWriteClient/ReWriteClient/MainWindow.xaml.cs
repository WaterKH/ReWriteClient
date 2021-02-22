using Microsoft.AspNetCore.SignalR.Client;
using ReWriteClient.Data;
using ReWriteClient.Events;
using ReWriteClient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
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

        private Timer soloTimer;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // TODO Do these need to be static?
            MessageHub.OnServerLogReceived += AddToServerLog;
            MessageHub.OnUpdateOptionsReceived += UpdateOptionsReceived;
        }

        #region View Methods

        private async void ClientConnectClicked(object sender, RoutedEventArgs e)
        {
            await this.ConnectToClient();
        }

        private async void ClientDisconnectClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.DisconnectFromClient();
            }
            catch (Exception ex)
            {
                this.ClientConnectionStatusMessage.Content = ex.Message;

                this.clientConnected = false;

                Logger.Instance.Error(ex.Message, "ClientDisconnectClicked");
            }
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

            ServerDisconnectButton.Visibility = this.serverConnected ? Visibility.Visible : Visibility.Hidden;
        }

        private async void ServerDisconnectClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.DisconnectFromServer(this.UsernameInput.Text);
            }
            catch (Exception ex)
            {
                this.ServerConnectionStatusMessage.Content = ex.Message;

                this.serverConnected = false;

                Logger.Instance.Error(ex.Message, "ServerDisconnectClicked");
            }

            ServerDisconnectButton.Visibility = this.serverConnected ? Visibility.Visible : Visibility.Hidden;
        }

        private void UpdateOptions(object sender, RoutedEventArgs e)
        {
            if (messageHub == null)
                return;

            messageHub.UpdateOptionsMessage();
        }

        private async void StartSoloClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.StartSoloPlay();
            }
            catch (Exception ex)
            {
                Logger.Instance.Error($"Error Starting Solo: {ex.Message}", "StartSoloClicked");
            }
        }

        private async void StopSoloClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.StopSoloPlay();
            }
            catch(Exception ex)
            {
                Logger.Instance.Error($"Error Stoping Solo: {ex.Message}", "StopSoloClicked");
            }
        }

        #endregion View Methods

        private async Task ConnectToClient()
        {
            try
            {
                if (this.memoryProcessor.ConnectToProcess())
                {
                    this.memoryProcessor.Process.Exited += (object sender, EventArgs e) => { Task.Run(async () => await ReconnectClientConnection()); };

                    this.Dispatcher.Invoke(() =>
                    {
                        this.ClientConnectionStatusMessage.Content = $"Connection Status: Connected";

                        Logger.Instance.Info("Client Connection Established", "ConnectToClient");

                        this.clientConnected = true;
                    });

                    ClientDisconnectButton.Visibility = Visibility.Visible;

                    return;
                }
            }
            catch (Exception ex)
            {
                this.ClientConnectionStatusMessage.Content = ex.Message;

                Logger.Instance.Error(ex.Message, "ClientConnectClicked");
            }

            this.Dispatcher.Invoke(() =>
            {
                this.ClientConnectionStatusMessage.Content = $"Connection Status: Not Connected";

                this.clientConnected = false;
            });
        }

        private async Task DisconnectFromClient()
        {
            this.memoryProcessor.DisconnectFromProcess();

            ClientDisconnectButton.Visibility = Visibility.Hidden;
        }

        private async Task ReconnectClientConnection()
        {
            this.Dispatcher.Invoke(() =>
            {
                this.ClientConnectionStatusMessage.Content = $"Connection Status: Disconnected";

                this.clientConnected = false;

                Logger.Instance.Error("Client Connection Disconnected Forcebly - Trying to Re-establish Connection", "ReconnectClientConnection");
            });

            while (!this.clientConnected)
            {
                await Task.Delay(5000); // Wait 5 seconds to retry a reconnection

                this.ConnectToClient();
            }
        }

        private async Task ConnectToServer(string username)
        {
            this.connection = new HubConnectionBuilder().WithUrl($"{this.connectionUrl}?username={username}").Build();

            await connection.StartAsync();

            if (this.connection.State == HubConnectionState.Connected)
            {
                this.connection.Closed += async (error) => { await ReconnectToServer(username); };

                this.Dispatcher.Invoke(() =>
                {
                    this.ServerConnectionStatusMessage.Content = $"Connection Status: {this.connection.State}";

                    this.serverConnected = true;

                    Logger.Instance.Info("Server Connection Established", "ConnectToServer");
                });

                this.messageHub = new MessageHub(this.connection, username);
            }
        }

        private async Task DisconnectFromServer(string username)
        {
            if (this.connection == null) return;

            await this.connection.StopAsync();

            this.Dispatcher.Invoke(() =>
            {
                this.ServerConnectionStatusMessage.Content = $"Connection Status: {this.connection.State}";

                this.serverConnected = false;

                Logger.Instance.Info("Server Connection Disconnected", "DisconnectFromServer");
            });

            this.messageHub = null;   
        }

        private async Task ReconnectToServer(string username)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.ServerConnectionStatusMessage.Content = $"Connection Status: {this.connection.State}";

                this.serverConnected = false;

                Logger.Instance.Error("Server Connection Disconnected Forcebly - Trying to Re-establish Connection", "ReconnectToServer");

                ServerDisconnectButton.Visibility = Visibility.Hidden;
            });

            while (!this.serverConnected)
            {
                await Task.Delay(5000); // Wait 5 seconds to retry a reconnection

                await this.ConnectToServer(username);
            }

            ServerDisconnectButton.Visibility = this.serverConnected ? Visibility.Visible : Visibility.Hidden;
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

                    uiButton.Click += (sender, e) => { method.Method.Invoke(subButton.ManipulationType, subButton.Value.ToString()); ClosePopup(null, null); };

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

        public void StartSoloPlay()
        {
            int randomValueParsed = 0;

            try
            {
                randomValueParsed = int.Parse(RandomEventPerSecond.Text);
            }
            catch(Exception ex)
            {
                Logger.Instance.Error(ex.Message, "StartSoloPlay");
            }

            if (randomValueParsed == 0)
                return;

            this.soloTimer = new Timer
            {
                AutoReset = true,
                Interval = randomValueParsed * 1000
            };

            this.soloTimer.Elapsed += (object sender, ElapsedEventArgs e) => {
                Messages.Messages.Instance.SelectRandomMessage();
            };
        }

        public void StopSoloPlay()
        {
            this.soloTimer.Stop();
            this.soloTimer.Dispose();

            this.soloTimer = null;
        }
    }
}