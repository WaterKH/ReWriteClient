﻿using ReWriteClient.Data;
using System.Timers;
using System.Windows;

namespace ReWriteClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Timer Timer;
        private readonly MemoryProcessor memoryProcessor = MemoryProcessor.Instance;
        private readonly Messages.Messages messages = Messages.Messages.Instance;

        public App()
        {
            this.SetupMemoryChecker();
        }

        public void SetupMemoryChecker()
        {
            Timer = new Timer
            {
                AutoReset = true,
                Interval = 100
            };

            Timer.Elapsed += (sender, obj) =>
            {
                this.memoryProcessor.CheckForEvent();
            };

            Timer.Start();
        }
    }
}
