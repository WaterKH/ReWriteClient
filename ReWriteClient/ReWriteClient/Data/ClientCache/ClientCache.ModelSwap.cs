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

        #region Forms

        public string SoraValorFormModel { get; set; }
        public string SoraWisdomFormModel { get; set; }
        public string SoraLimitFormModel { get; set; }
        public string SoraMasterFormModel { get; set; }
        public string SoraFinalFormModel { get; set; }
        public string SoraAntiFormModel { get; set; }

        #endregion Forms

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
                this.messages.MessageMappings["ModelSwap"]["SendSoraModelMessage"].Method.Invoke(ManipulationType.Set, this.SoraModel);

            if (!string.IsNullOrEmpty(this.SoraLionModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraLionModelMessage"].Method.Invoke(ManipulationType.Set, this.SoraLionModel);

            if (!string.IsNullOrEmpty(this.SoraTimelessRiverModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraTimelessRiverModelMessage"].Method.Invoke(ManipulationType.Set, this.SoraTimelessRiverModel);

            if (!string.IsNullOrEmpty(this.SoraHalloweenModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraHalloweenModelMessage"].Method.Invoke(ManipulationType.Set, this.SoraHalloweenModel);

            if (!string.IsNullOrEmpty(this.SoraChristmasModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraChristmasModelMessage"].Method.Invoke(ManipulationType.Set, this.SoraChristmasModel);

            if (!string.IsNullOrEmpty(this.SoraSpaceParanoidsModel))
                this.messages.MessageMappings["ModelSwap"]["SendSoraSpaceParanoidsModelMessage"].Method.Invoke(ManipulationType.Set, this.SoraSpaceParanoidsModel);
        }

        public async Task RefreshDonaldModelCache()
        {
            if (!string.IsNullOrEmpty(this.DonaldModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldModelMessage"].Method.Invoke(ManipulationType.Set, this.DonaldModel);

            if (!string.IsNullOrEmpty(this.DonaldBirdModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldBirdModelMessage"].Method.Invoke(ManipulationType.Set, this.DonaldBirdModel);

            if (!string.IsNullOrEmpty(this.DonaldTimelessRiverModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldTimelessRiverModelMessage"].Method.Invoke(ManipulationType.Set, this.DonaldTimelessRiverModel);

            if (!string.IsNullOrEmpty(this.DonaldHalloweenModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldHalloweenModelMessage"].Method.Invoke(ManipulationType.Set, this.DonaldHalloweenModel);

            if (!string.IsNullOrEmpty(this.DonaldChristmasModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldChristmasModelMessage"].Method.Invoke(ManipulationType.Set, this.DonaldChristmasModel);

            if (!string.IsNullOrEmpty(this.DonaldSpaceParanoidsModel))
                this.messages.MessageMappings["ModelSwap"]["SendDonaldSpaceParanoidsModelMessage"].Method.Invoke(ManipulationType.Set, this.DonaldSpaceParanoidsModel);
        }

        public async Task RefreshGoofyModelCache()
        {
            if (!string.IsNullOrEmpty(this.GoofyModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyModelMessage"].Method.Invoke(ManipulationType.Set, this.GoofyModel);

            if (!string.IsNullOrEmpty(this.GoofyTortoiseModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyTortoiseModelMessage"].Method.Invoke(ManipulationType.Set, this.GoofyTortoiseModel);

            if (!string.IsNullOrEmpty(this.GoofyTimelessRiverModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyTimelessRiverModelMessage"].Method.Invoke(ManipulationType.Set, this.GoofyTimelessRiverModel);

            if (!string.IsNullOrEmpty(this.GoofyHalloweenModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyHalloweenModelMessage"].Method.Invoke(ManipulationType.Set, this.GoofyHalloweenModel);

            if (!string.IsNullOrEmpty(this.GoofyChristmasModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofyChristmasModelMessage"].Method.Invoke(ManipulationType.Set, this.GoofyChristmasModel);

            if (!string.IsNullOrEmpty(this.GoofySpaceParanoidsModel))
                this.messages.MessageMappings["ModelSwap"]["SendGoofySpaceParanoidsModelMessage"].Method.Invoke(ManipulationType.Set, this.GoofySpaceParanoidsModel);
        }

        public async Task RefreshPartyModelCache()
        {
            if (!string.IsNullOrEmpty(this.MulanModel))
                this.messages.MessageMappings["ModelSwap"]["SendMulanModelMessage"].Method.Invoke(ManipulationType.Set, this.MulanModel);

            if (!string.IsNullOrEmpty(this.BeastModel))
                this.messages.MessageMappings["ModelSwap"]["SendBeastModelMessage"].Method.Invoke(ManipulationType.Set, this.BeastModel);

            if (!string.IsNullOrEmpty(this.AuronModel))
                this.messages.MessageMappings["ModelSwap"]["SendAuronModelMessage"].Method.Invoke(ManipulationType.Set, this.AuronModel);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowModel))
                this.messages.MessageMappings["ModelSwap"]["SendCaptainJackSparrowModelMessage"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowModel);

            if (!string.IsNullOrEmpty(this.AladdinModel))
                this.messages.MessageMappings["ModelSwap"]["SendAladdinModelMessage"].Method.Invoke(ManipulationType.Set, this.AladdinModel);

            if (!string.IsNullOrEmpty(this.JackSkellingtonModel))
                this.messages.MessageMappings["ModelSwap"]["SendJackSkellingtonModelMessage"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonModel);

            if (!string.IsNullOrEmpty(this.SimbaModel))
                this.messages.MessageMappings["ModelSwap"]["SendSimbaModelMessage"].Method.Invoke(ManipulationType.Set, this.SimbaModel);

            if (!string.IsNullOrEmpty(this.TronModel))
                this.messages.MessageMappings["ModelSwap"]["SendTronModelMessage"].Method.Invoke(ManipulationType.Set, this.TronModel);

            if (!string.IsNullOrEmpty(this.RikuModel))
                this.messages.MessageMappings["ModelSwap"]["SendRikuModelMessage"].Method.Invoke(ManipulationType.Set, this.RikuModel);
        }

        #endregion Refresh Cache Sub-Methods
    }
}