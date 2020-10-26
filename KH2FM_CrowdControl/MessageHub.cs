using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Timers;
using Waterkh.Common.Memory;

namespace KH2FM_CrowdControl
{
    public class MessageHub
    {
        private readonly MemoryProcessor MemoryProcessor;

        public MessageHub(HubConnection connection)
        {
            MemoryProcessor = new MemoryProcessor();

            this.SubscribeToMessages(connection);
        }

        public void SubscribeToMessages(HubConnection connection)
        {
            connection.On<MemoryObject>("SendUpdateMemoryMessage", message =>
            {
                MemoryProcessor.UpdateMemory(message);

                Console.WriteLine($"{message.Name} updated to {message.Value} - Type: {message.Type} - Address: {message.Address}");
            });

            // This is under the impression that the last item is a button press
            connection.On<MemoryObject[]>("SendUpdateMultipleMemoryMessage", message =>
            {
                for (int i = 0; i < message.Length - 1; ++i)
                {
                    MemoryProcessor.UpdateMemory(message[i]);

                    Console.WriteLine($"{message[i].Name} updated to {message[i].Value} - Type: {message[i].Type} - Address: {message[i].Address}");
                }

                this.CreateInterval(message[^1]);
            });

            connection.On<MemoryObject, int, int>("SendUpdateMemoryRangeMessage", (message, maxNumber, toggleValue) =>
            {
                this.CheckMemoryForAbility(message, maxNumber, toggleValue);
            });
        }

        private void CreateInterval(MemoryObject obj, int interval = 1)
        {
            var timer = new Timer(interval)
            {
                Enabled = true,
            };

            switch (obj.Name)
            {
                case "Press Triangle Reaction Command":

                    this.CheckMemoryForTrianglePress(MemoryProcessor.UpdateMemory, obj, timer);

                    Console.WriteLine($"{obj.Name} updated to {obj.Value} - Type: {obj.Type} - Address: {obj.Address}");

                    break;
                default:

                    MemoryProcessor.UpdateMemory(obj);

                    Console.WriteLine($"{obj.Name} updated to {obj.Value} - Type: {obj.Type} - Address: {obj.Address}");

                    break;
            }
        }

        private void CheckMemoryForTrianglePress(Action<MemoryObject> action, MemoryObject obj, Timer timer)
        {
            timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                if (MemoryProcessor.CheckMemory(0x21C5FF4E, DataType.TwoBytes, "0"))
                    timer.Stop();

                action.Invoke(obj);
            };
        }

        private void CheckMemoryForAbility(MemoryObject obj, int maxNumber, int toggleValue)
        {
            switch (obj.Address)
            {
                // Ability start location
                case 0x2032E074:

                    if(MemoryProcessor.UpdateAbilityMemory(obj, maxNumber, toggleValue))
                        Console.WriteLine($"{obj.Name} updated to {obj.Value} - Type: {obj.Type} - Address: {obj.Address}");
                    else
                        Console.WriteLine($"{obj.Name} Failed to update to {obj.Value} - Address: {obj.Address}");

                    break;
                default:
                    break;
            }
        }
    }
}