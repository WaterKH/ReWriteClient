using System.Threading.Tasks;
using System.Timers;

namespace ReWriteClient.Data
{
    public partial class ClientCache
    {
        private static ClientCache instance;
        public readonly static ClientCache Instance = instance ?? new ClientCache();

        private readonly Messages.Messages messages = Messages.Messages.Instance;
        private readonly MemoryProcessor memoryProcessor = MemoryProcessor.Instance;

        private Timer updateTimer;
        private Timer refreshTimer;

        // TODO Maybe make a timer for each property? That way when they aren't forever updating?
        private ClientCache() { }

        public void SetupUpdateTimer()
        {
            if (updateTimer == null)
            {
                updateTimer = new Timer()
                {
                    AutoReset = true,
                    Interval = 1000 // 1 second every update?
                };

                updateTimer.Elapsed += (sender, obj) =>
                {
                    UpdateCache();
                };
            }

            updateTimer.Start();
        }

        public void SetupRefreshTimer()
        {
            if (refreshTimer == null)
            { 
                refreshTimer = new Timer()
                {
                    AutoReset = true,
                    Interval = 1000 // 1 second every update?
                };

                refreshTimer.Elapsed += (sender, obj) => {
                    RefreshFromCache();
                };
            }
            
            refreshTimer.Start();
        }

        public async Task UpdateCache()
        {
            // Check animation state - 912 is death
            if (memoryProcessor.CheckAnimationState("912"))
            {
                updateTimer.Stop();

                SetupRefreshTimer();

                // For now, we don't want to update our cache on death, although
                // we may want to rethink this later on
            }
        }

        public async Task RefreshFromCache()
        {
            if (memoryProcessor.CheckAnimationState("48")) // This will probably not activate everything until the next room?
            {
                refreshTimer.Stop();

                SetupUpdateTimer();

                await this.RefreshSoraCache();
                await this.RefreshModelSwapCache();
                await this.RefreshPartyCache();
                await this.RefreshEnemyCache();
                await this.RefreshDriveCache();
                await this.RefreshSummonCache();
                await this.RefreshItemCache();
                await this.RefreshMiscCache();
            }
        }
    }
}