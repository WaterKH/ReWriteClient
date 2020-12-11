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

        #region Sora

        public string SoraModel { get; set; }
        public string SoraLionModel { get; set; }
        public string SoraTimelessRiverModel { get; set; }
        public string SoraHalloweenModel { get; set; }
        public string SoraChristmasModel { get; set; }
        public string SoraSpaceParanoidsModel { get; set; }

        #endregion Sora

        #region Donald

        public string DonaldModel { get; set; }
        public string DonaldBirdModel { get; set; }
        public string DonaldTimelessRiverModel { get; set; }
        public string DonaldHalloweenModel { get; set; }
        public string DonaldChristmasModel { get; set; }
        public string DonaldSpaceParanoidsModel { get; set; }

        #endregion Donald

        #region Goofy

        public string GoofyModel { get; set; }
        public string GoofyTortoiseModel { get; set; }
        public string GoofyTimelessRiverModel { get; set; }
        public string GoofyHalloweenModel { get; set; }
        public string GoofyChristmasModel { get; set; }
        public string GoofySpaceParanoidsModel { get; set; }

        #endregion Goofy

        #region Party

        public string MulanModel { get; set; }
        public string BeastModel { get; set; }
        public string AuronModel { get; set; }
        public string CaptainJackSparrowModel { get; set; }
        public string AladdinModel { get; set; }
        public string JackSkellingtonModel { get; set; }
        public string SimbaModel { get; set; }
        public string TronModel { get; set; }
        public string RikuModel { get; set; }

        #endregion Party

        #endregion Properties

        public async Task RefreshModelSwapCache()
        {
            await this.RefreshSoraModelCache();
            await this.RefreshDonaldModelCache();
            await this.RefreshGoofyModelCache();
            await this.RefreshPartyModelCache();
        }

        #region Refresh Cache Sub-Methods

        public async Task RefreshSoraModelCache()
        {
            if (!string.IsNullOrEmpty(this.SoraModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraModelMessage"].Invoke(ManipulationType.Set, this.SoraModel);

            if (!string.IsNullOrEmpty(this.SoraLionModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraLionModelMessage"].Invoke(ManipulationType.Set, this.SoraLionModel);

            if (!string.IsNullOrEmpty(this.SoraTimelessRiverModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraTimelessRiverModelMessage"].Invoke(ManipulationType.Set, this.SoraTimelessRiverModel);

            if (!string.IsNullOrEmpty(this.SoraHalloweenModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraHalloweenModelMessage"].Invoke(ManipulationType.Set, this.SoraHalloweenModel);

            if (!string.IsNullOrEmpty(this.SoraChristmasModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraChristmasModelMessage"].Invoke(ManipulationType.Set, this.SoraChristmasModel);

            if (!string.IsNullOrEmpty(this.SoraSpaceParanoidsModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraSpaceParanoidsModelMessage"].Invoke(ManipulationType.Set, this.SoraSpaceParanoidsModel);
        }

        public async Task RefreshDonaldModelCache()
        {
            if (!string.IsNullOrEmpty(this.DonaldModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldModelMessage"].Invoke(ManipulationType.Set, this.DonaldModel);

            if (!string.IsNullOrEmpty(this.DonaldBirdModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldBirdModelMessage"].Invoke(ManipulationType.Set, this.DonaldBirdModel);

            if (!string.IsNullOrEmpty(this.DonaldTimelessRiverModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldTimelessRiverModelMessage"].Invoke(ManipulationType.Set, this.DonaldTimelessRiverModel);

            if (!string.IsNullOrEmpty(this.DonaldHalloweenModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldHalloweenModelMessage"].Invoke(ManipulationType.Set, this.DonaldHalloweenModel);

            if (!string.IsNullOrEmpty(this.DonaldChristmasModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldChristmasModelMessage"].Invoke(ManipulationType.Set, this.DonaldChristmasModel);

            if (!string.IsNullOrEmpty(this.DonaldSpaceParanoidsModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldSpaceParanoidsModelMessage"].Invoke(ManipulationType.Set, this.DonaldSpaceParanoidsModel);
        }

        public async Task RefreshGoofyModelCache()
        {
            if (!string.IsNullOrEmpty(this.GoofyModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyModelMessage"].Invoke(ManipulationType.Set, this.GoofyModel);

            if (!string.IsNullOrEmpty(this.GoofyTortoiseModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyTortoiseModelMessage"].Invoke(ManipulationType.Set, this.GoofyTortoiseModel);

            if (!string.IsNullOrEmpty(this.GoofyTimelessRiverModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyTimelessRiverModelMessage"].Invoke(ManipulationType.Set, this.GoofyTimelessRiverModel);

            if (!string.IsNullOrEmpty(this.GoofyHalloweenModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyHalloweenModelMessage"].Invoke(ManipulationType.Set, this.GoofyHalloweenModel);

            if (!string.IsNullOrEmpty(this.GoofyChristmasModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyChristmasModelMessage"].Invoke(ManipulationType.Set, this.GoofyChristmasModel);

            if (!string.IsNullOrEmpty(this.GoofySpaceParanoidsModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofySpaceParanoidsModelMessage"].Invoke(ManipulationType.Set, this.GoofySpaceParanoidsModel);
        }

        public async Task RefreshPartyModelCache()
        {
            if (!string.IsNullOrEmpty(this.MulanModel))
                this.messages.MessageMappings["ModelSwap"]["SendMulanModelMessage"].Invoke(ManipulationType.Set, this.MulanModel);

            if (!string.IsNullOrEmpty(this.BeastModel))
                this.messages.MessageMappings["ModelSwap"]["SendBeastModelMessage"].Invoke(ManipulationType.Set, this.BeastModel);

            if (!string.IsNullOrEmpty(this.AuronModel))
                this.messages.MessageMappings["ModelSwap"]["SendAuronModelMessage"].Invoke(ManipulationType.Set, this.AuronModel);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowModel))
                this.messages.MessageMappings["ModelSwap"]["SendCaptainJackSparrowModelMessage"].Invoke(ManipulationType.Set, this.CaptainJackSparrowModel);

            if (!string.IsNullOrEmpty(this.AladdinModel))
                this.messages.MessageMappings["ModelSwap"]["SendAladdinModelMessage"].Invoke(ManipulationType.Set, this.AladdinModel);

            if (!string.IsNullOrEmpty(this.JackSkellingtonModel))
                this.messages.MessageMappings["ModelSwap"]["SendJackSkellingtonModelMessage"].Invoke(ManipulationType.Set, this.JackSkellingtonModel);

            if (!string.IsNullOrEmpty(this.SimbaModel))
                this.messages.MessageMappings["ModelSwap"]["SendSimbaModelMessage"].Invoke(ManipulationType.Set, this.SimbaModel);

            if (!string.IsNullOrEmpty(this.TronModel))
                this.messages.MessageMappings["ModelSwap"]["SendTronModelMessage"].Invoke(ManipulationType.Set, this.TronModel);

            if (!string.IsNullOrEmpty(this.RikuModel))
                this.messages.MessageMappings["ModelSwap"]["SendRikuModelMessage"].Invoke(ManipulationType.Set, this.RikuModel);
        }

        #endregion Refresh Cache Sub-Methods
    }
}