using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KH2FM_CrowdControl
{
    public class Program
    {
        private static HubConnection connection;
        private static MessageHub messageHub;

        //private static readonly string connectionUrl = "https://localhost:44362/MessageHub";
        private static readonly string connectionUrl = "https://memoryscape.azurewebsites.net/MessageHub";

        static async Task Main(string[] args)
        {
            Console.Write("Please enter your Twitch username: ");

            var username = Console.ReadLine();

            await ConnectToServer(username.ToLower());

            Console.WriteLine("Subscribing to messages...");

            messageHub = new MessageHub(connection);

            Console.WriteLine("Finished Subscribing");

            Console.WriteLine("Keep this window open.");

            while (connection.State == HubConnectionState.Connected)
            {
                Thread.Sleep(1000);
            }
        }

        private static async Task ConnectToServer(string username)
        {
            connection = new HubConnectionBuilder()
                .WithUrl($"{connectionUrl}?username={username}")
                .Build();

            Console.WriteLine("Connecting...");

            await connection.StartAsync();

            Console.WriteLine($"Connection Status: {connection.State}");

            connection.Closed += async (error) =>
            {
                await Task.Delay(1000);
                await connection.StartAsync();
            };

        }
    }
}