using System.Threading.Tasks;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public partial class ClientCache
    {
        #region Properties

        public string ChangeBoss { get; set; }

        #endregion Properties

        public async Task RefreshEnemyCache()
        {
            if (!string.IsNullOrEmpty(this.ChangeBoss))
                this.messages.MessageMappings["Enemy"]["SendBossChangeMessage"].Invoke(ManipulationType.Set, this.ChangeBoss);
        }
    }
}