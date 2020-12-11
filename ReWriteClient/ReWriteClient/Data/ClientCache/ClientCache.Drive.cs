using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public partial class ClientCache
    {
        #region Properties

        public string CurrentDriveCounter { get; set; }
        public string MaxDriverCounter { get; set; }
        public string DisableDrive { get; set; }
        // TODO add the rest when you can change the message?

        #endregion Properties

        public async Task RefreshDriveCache()
        {
            if (!string.IsNullOrEmpty(this.CurrentDriveCounter))
                this.messages.MessageMappings["Drive"]["SendCurrentDriveCounterMessage"].Invoke(ManipulationType.Set, this.CurrentDriveCounter);

            if (!string.IsNullOrEmpty(this.MaxDriverCounter))
                this.messages.MessageMappings["Drive"]["SendMaxDriveCounterMessage"].Invoke(ManipulationType.Set, this.MaxDriverCounter);

            if (!string.IsNullOrEmpty(this.DisableDrive))
                this.messages.MessageMappings["Drive"]["SendDisableDriveMessage"].Invoke(ManipulationType.Set, this.DisableDrive);
        }
    }
}