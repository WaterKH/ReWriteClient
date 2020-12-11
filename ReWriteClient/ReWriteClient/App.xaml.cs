using ReWriteClient.Data;
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

        public App()
        {
            this.SetupMemoryChecker();
            this.SetupTPoseFixer();

            ClientCache.Instance.SetupUpdateTimer();
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

        public void SetupTPoseFixer()
        {
            Timer = new Timer
            {
                AutoReset = true,
                Interval = 100
            };

            Timer.Elapsed += (sender, obj) =>
            {
                if (this.memoryProcessor.CheckTPose())
                {
                    this.memoryProcessor.FixTPose();
                }
            };

            Timer.Start();
        }
    }
}
