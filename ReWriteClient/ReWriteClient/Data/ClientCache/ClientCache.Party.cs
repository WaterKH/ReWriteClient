using System.Collections.Generic;
using System.Threading.Tasks;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public partial class ClientCache
    {
        #region Properties

        #region Donald

        public string DonaldStaff { get; set; }
        public string DonaldArmorSlots { get; set; }
        public string DonaldArmorSlot1 { get; set; }
        public string DonaldArmorSlot2 { get; set; }
        public string DonaldAccessorySlots { get; set; }
        public string DonaldAccessorySlot1 { get; set; }
        public string DonaldAccessorySlot2 { get; set; }
        public string DonaldAccessorySlot3 { get; set; }
        public string DonaldItemSlots { get; set; }
        public string DonaldItemSlot1 { get; set; }
        public string DonaldItemSlot2 { get; set; }
        public List<string> DonaldAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Donald

        #region Goofy

        public string GoofyShield { get; set; }
        public string GoofyArmorSlots { get; set; }
        public string GoofyArmorSlot1 { get; set; }
        public string GoofyArmorSlot2 { get; set; }
        public string GoofyArmorSlot3 { get; set; }
        public string GoofyAccessorySlots { get; set; }
        public string GoofyAccessorySlot1 { get; set; }
        public string GoofyAccessorySlot2 { get; set; }
        public string GoofyItemSlots { get; set; }
        public string GoofyItemSlot1 { get; set; }
        public string GoofyItemSlot2 { get; set; }
        public string GoofyItemSlot3 { get; set; }
        public string GoofyItemSlot4 { get; set; }
        public List<string> GoofyAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Goofy

        #region Mulan

        public string MulanArmorSlots { get; set; }
        public string MulanArmorSlot1 { get; set; }
        public string MulanAccessorySlots { get; set; }
        public string MulanAccessorySlot1 { get; set; }
        public string MulanItemSlots { get; set; }
        public string MulanItemSlot1 { get; set; }
        public string MulanItemSlot2 { get; set; }
        public string MulanItemSlot3 { get; set; }
        public List<string> MulanAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Mulan

        #region Beast

        public string BeastAccessorySlots { get; set; }
        public string BeastAccessorySlot1 { get; set; }
        public string BeastItemSlots { get; set; }
        public string BeastItemSlot1 { get; set; }
        public string BeastItemSlot2 { get; set; }
        public string BeastItemSlot3 { get; set; }
        public string BeastItemSlot4 { get; set; }
        public List<string> BeastAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Beast

        #region Auron

        public string AuronArmorSlots { get; set; }
        public string AuronArmorSlot1 { get; set; }
        public string AuronItemSlots { get; set; }
        public string AuronItemSlot1 { get; set; }
        public string AuronItemSlot2 { get; set; }
        public List<string> AuronAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Auron

        #region Captain Jack Sparrow

        public string CaptainJackSparrowArmorSlots { get; set; }
        public string CaptainJackSparrowArmorSlot1 { get; set; }
        public string CaptainJackSparrowAccessorySlots { get; set; }
        public string CaptainJackSparrowAccessorySlot1 { get; set; }
        public string CaptainJackSparrowItemSlots { get; set; }
        public string CaptainJackSparrowItemSlot1 { get; set; }
        public string CaptainJackSparrowItemSlot2 { get; set; }
        public string CaptainJackSparrowItemSlot3 { get; set; }
        public string CaptainJackSparrowItemSlot4 { get; set; }
        public List<string> CaptainJackSparrowAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Captain Jack Sparrow

        #region Aladdin

        public string AladdinArmorSlots { get; set; }
        public string AladdinArmorSlot1 { get; set; }
        public string AladdinArmorSlot2 { get; set; }
        public string AladdinItemSlots { get; set; }
        public string AladdinItemSlot1 { get; set; }
        public string AladdinItemSlot2 { get; set; }
        public string AladdinItemSlot3 { get; set; }
        public string AladdinItemSlot4 { get; set; }
        public string AladdinItemSlot5 { get; set; }
        public List<string> AladdinAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Aladdin

        #region Jack Skellington

        public string JackSkellingtonAccessorySlots { get; set; }
        public string JackSkellingtonAccessorySlot1 { get; set; }
        public string JackSkellingtonAccessorySlot2 { get; set; }
        public string JackSkellingtonItemSlots { get; set; }
        public string JackSkellingtonItemSlot1 { get; set; }
        public string JackSkellingtonItemSlot2 { get; set; }
        public string JackSkellingtonItemSlot3 { get; set; }
        public List<string> JackSkellingtonAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Jack Skellington

        #region Simba

        public string SimbaAccessorySlots { get; set; }
        public string SimbaAccessorySlot1 { get; set; }
        public string SimbaAccessorySlot2 { get; set; }
        public string SimbaItemSlots { get; set; }
        public string SimbaItemSlot1 { get; set; }
        public string SimbaItemSlot2 { get; set; }
        public string SimbaItemSlot3 { get; set; }
        public List<string> SimbaAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Simba

        #region Tron

        public string TronArmorSlots { get; set; }
        public string TronArmorSlot1 { get; set; }
        public string TronAccessorySlots { get; set; }
        public string TronAccessorySlot1 { get; set; }
        public string TronItemSlots { get; set; }
        public string TronItemSlot1 { get; set; }
        public string TronItemSlot2 { get; set; }
        public List<string> TronAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Tron

        #region Riku

        public string RikuArmorSlots { get; set; }
        public string RikuArmorSlot1 { get; set; }
        public string RikuArmorSlot2 { get; set; }
        public string RikuAccessorySlots { get; set; }
        public string RikuAccessorySlot1 { get; set; }
        public string RikuItemSlots { get; set; }
        public string RikuItemSlot1 { get; set; }
        public string RikuItemSlot2 { get; set; }
        public string RikuItemSlot3 { get; set; }
        public string RikuItemSlot4 { get; set; }
        public string RikuItemSlot5 { get; set; }
        public string RikuItemSlot6 { get; set; }
        public List<string> RikuAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Riku

        #endregion Properties

        public async Task RefreshPartyCache()
        {
            await this.RefreshDonaldPartyCache();
            await this.RefreshGoofyPartyCache();
            await this.RefreshMulanPartyCache();
            await this.RefreshBeastPartyCache();
            await this.RefreshAuronPartyCache();
            await this.RefreshCaptainJackSparrowPartyCache();
            await this.RefreshAladdinPartyCache();
            await this.RefreshJackSkellingtonPartyCache();
            await this.RefreshSimbaPartyCache();
            await this.RefreshTronPartyCache();
            await this.RefreshRikuPartyCache();
        }

        #region Refresh Cache Sub-Methods

        public async Task RefreshDonaldPartyCache()
        {
            if (!string.IsNullOrEmpty(this.DonaldStaff))
                this.messages.MessageMappings["Party"]["SendEquipStaffMessage"].Method.Invoke(ManipulationType.Set, this.DonaldStaff);
            
            if (!string.IsNullOrEmpty(this.DonaldArmorSlots))
                this.messages.MessageMappings["Party"]["SendDonaldArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.DonaldArmorSlots);

            if (!string.IsNullOrEmpty(this.DonaldArmorSlot1))
                this.messages.MessageMappings["Party"]["SendDonaldArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.DonaldArmorSlot1);

            if (!string.IsNullOrEmpty(this.DonaldArmorSlot2))
                this.messages.MessageMappings["Party"]["SendDonaldArmorSlot2Message"].Method.Invoke(ManipulationType.Set, this.DonaldArmorSlot2);

            if (!string.IsNullOrEmpty(this.DonaldAccessorySlots))
                this.messages.MessageMappings["Party"]["SendDonaldAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.DonaldAccessorySlots);

            if (!string.IsNullOrEmpty(this.DonaldAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendDonaldAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.DonaldAccessorySlot1);

            if (!string.IsNullOrEmpty(this.DonaldAccessorySlot2))
                this.messages.MessageMappings["Party"]["SendDonaldAccessorySlot2Message"].Method.Invoke(ManipulationType.Set, this.DonaldAccessorySlot2);

            if (!string.IsNullOrEmpty(this.DonaldAccessorySlot3))
                this.messages.MessageMappings["Party"]["SendDonaldAccessorySlot3Message"].Method.Invoke(ManipulationType.Set, this.DonaldAccessorySlot3);

            if (!string.IsNullOrEmpty(this.DonaldItemSlots))
                this.messages.MessageMappings["Party"]["SendDonaldItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.DonaldItemSlots);

            if (!string.IsNullOrEmpty(this.DonaldItemSlot1))
                this.messages.MessageMappings["Party"]["SendDonaldItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.DonaldItemSlot1);

            if (!string.IsNullOrEmpty(this.DonaldItemSlot2))
                this.messages.MessageMappings["Party"]["SendDonaldItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.DonaldItemSlot2);

            // TODO Add a better ability system

        }

        public async Task RefreshGoofyPartyCache()
        {
            if (!string.IsNullOrEmpty(this.GoofyShield))
                this.messages.MessageMappings["Party"]["SendEquipShieldMessage"].Method.Invoke(ManipulationType.Set, this.GoofyShield);

            if (!string.IsNullOrEmpty(this.GoofyArmorSlots))
                this.messages.MessageMappings["Party"]["SendGoofyArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.GoofyArmorSlots);

            if (!string.IsNullOrEmpty(this.GoofyArmorSlot1))
                this.messages.MessageMappings["Party"]["SendGoofyArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.GoofyArmorSlot1);

            if (!string.IsNullOrEmpty(this.GoofyArmorSlot2))
                this.messages.MessageMappings["Party"]["SendGoofyArmorSlot2Message"].Method.Invoke(ManipulationType.Set, this.GoofyArmorSlot2);

            if (!string.IsNullOrEmpty(this.GoofyArmorSlot3))
                this.messages.MessageMappings["Party"]["SendGoofyArmorySlot3Message"].Method.Invoke(ManipulationType.Set, this.GoofyArmorSlot3);

            if (!string.IsNullOrEmpty(this.GoofyAccessorySlots))
                this.messages.MessageMappings["Party"]["SendGoofyAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.GoofyAccessorySlots);

            if (!string.IsNullOrEmpty(this.GoofyAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendGoofyAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.GoofyAccessorySlot1);

            if (!string.IsNullOrEmpty(this.GoofyAccessorySlot2))
                this.messages.MessageMappings["Party"]["SendGoofyAccessorySlot2Message"].Method.Invoke(ManipulationType.Set, this.GoofyAccessorySlot2);

            if (!string.IsNullOrEmpty(this.GoofyItemSlots))
                this.messages.MessageMappings["Party"]["SendGoofyItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.GoofyItemSlots);

            if (!string.IsNullOrEmpty(this.GoofyItemSlot1))
                this.messages.MessageMappings["Party"]["SendGoofyItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.GoofyItemSlot1);

            if (!string.IsNullOrEmpty(this.GoofyItemSlot2))
                this.messages.MessageMappings["Party"]["SendGoofyItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.GoofyItemSlot2);
            
            if (!string.IsNullOrEmpty(this.GoofyItemSlot3))
                this.messages.MessageMappings["Party"]["SendGoofyItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.GoofyItemSlot3);

            if (!string.IsNullOrEmpty(this.GoofyItemSlot4))
                this.messages.MessageMappings["Party"]["SendGoofyItemSlot4Message"].Method.Invoke(ManipulationType.Set, this.GoofyItemSlot4);

            // TODO Add a better ability system
        }

        public async Task RefreshMulanPartyCache()
        {
            if (!string.IsNullOrEmpty(this.MulanArmorSlots))
                this.messages.MessageMappings["Party"]["SendMulanArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.MulanArmorSlots);

            if (!string.IsNullOrEmpty(this.MulanArmorSlot1))
                this.messages.MessageMappings["Party"]["SendMulanArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.MulanArmorSlot1);

            if (!string.IsNullOrEmpty(this.MulanAccessorySlots))
                this.messages.MessageMappings["Party"]["SendMulanAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.MulanAccessorySlots);

            if (!string.IsNullOrEmpty(this.MulanAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendMulanAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.MulanAccessorySlot1);

            if (!string.IsNullOrEmpty(this.MulanItemSlots))
                this.messages.MessageMappings["Party"]["SendMulanItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.MulanItemSlots);

            if (!string.IsNullOrEmpty(this.MulanItemSlot1))
                this.messages.MessageMappings["Party"]["SendMulanItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.MulanItemSlot1);

            if (!string.IsNullOrEmpty(this.MulanItemSlot2))
                this.messages.MessageMappings["Party"]["SendMulanItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.MulanItemSlot2);

            if (!string.IsNullOrEmpty(this.MulanItemSlot3))
                this.messages.MessageMappings["Party"]["SendMulanItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.MulanItemSlot3);

            // TODO Add a better ability system
        }

        public async Task RefreshBeastPartyCache()
        {
            if (!string.IsNullOrEmpty(this.BeastAccessorySlots))
                this.messages.MessageMappings["Party"]["SendBeastAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.BeastAccessorySlots);

            if (!string.IsNullOrEmpty(this.BeastAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendBeastAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.BeastAccessorySlot1);

            if (!string.IsNullOrEmpty(this.BeastItemSlots))
                this.messages.MessageMappings["Party"]["SendBeastItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.BeastItemSlots);

            if (!string.IsNullOrEmpty(this.BeastItemSlot1))
                this.messages.MessageMappings["Party"]["SendBeastItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.BeastItemSlot1);

            if (!string.IsNullOrEmpty(this.BeastItemSlot2))
                this.messages.MessageMappings["Party"]["SendBeastItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.BeastItemSlot2);

            if (!string.IsNullOrEmpty(this.BeastItemSlot3))
                this.messages.MessageMappings["Party"]["SendBeastItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.BeastItemSlot3);

            if (!string.IsNullOrEmpty(this.BeastItemSlot4))
                this.messages.MessageMappings["Party"]["SendBeastItemSlot4Message"].Method.Invoke(ManipulationType.Set, this.BeastItemSlot4);

            // TODO Add a better ability system
        }

        public async Task RefreshAuronPartyCache()
        {
            if (!string.IsNullOrEmpty(this.AuronArmorSlots))
                this.messages.MessageMappings["Party"]["SendAuronArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.AuronArmorSlots);

            if (!string.IsNullOrEmpty(this.AuronArmorSlot1))
                this.messages.MessageMappings["Party"]["SendAuronArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.AuronArmorSlot1);

            if (!string.IsNullOrEmpty(this.AuronItemSlots))
                this.messages.MessageMappings["Party"]["SendAuronItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.AuronItemSlots);

            if (!string.IsNullOrEmpty(this.AuronItemSlot1))
                this.messages.MessageMappings["Party"]["SendAuronItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.AuronItemSlot1);

            if (!string.IsNullOrEmpty(this.AuronItemSlot2))
                this.messages.MessageMappings["Party"]["SendAuronItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.AuronItemSlot2);

            // TODO Add a better ability system
        }

        public async Task RefreshCaptainJackSparrowPartyCache()
        {
            if (!string.IsNullOrEmpty(this.CaptainJackSparrowArmorSlots))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowArmorSlots);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowArmorSlot1))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowArmorSlot1);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowAccessorySlots))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowAccessorySlots);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowAccessorySlot1);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowItemSlots))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowItemSlots);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowItemSlot1))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowItemSlot1);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowItemSlot2))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowItemSlot2);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowItemSlot3))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowItemSlot3);

            if (!string.IsNullOrEmpty(this.CaptainJackSparrowItemSlot4))
                this.messages.MessageMappings["Party"]["SendCaptainJackSparrowItemSlot4Message"].Method.Invoke(ManipulationType.Set, this.CaptainJackSparrowItemSlot4);

            // TODO Add a better ability system
        }

        public async Task RefreshAladdinPartyCache()
        {
            if (!string.IsNullOrEmpty(this.AladdinArmorSlots))
                this.messages.MessageMappings["Party"]["SendAladdinArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.AladdinArmorSlots);

            if (!string.IsNullOrEmpty(this.AladdinArmorSlot1))
                this.messages.MessageMappings["Party"]["SendAladdinArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.AladdinArmorSlot1);

            if (!string.IsNullOrEmpty(this.AladdinArmorSlot2))
                this.messages.MessageMappings["Party"]["SendAladdinArmorSlot2Message"].Method.Invoke(ManipulationType.Set, this.AladdinArmorSlot2);

            if (!string.IsNullOrEmpty(this.AladdinItemSlots))
                this.messages.MessageMappings["Party"]["SendAladdinItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.AladdinItemSlots);

            if (!string.IsNullOrEmpty(this.AladdinItemSlot1))
                this.messages.MessageMappings["Party"]["SendAladdinItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.AladdinItemSlot1);

            if (!string.IsNullOrEmpty(this.AladdinItemSlot2))
                this.messages.MessageMappings["Party"]["SendAladdinItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.AladdinItemSlot2);

            if (!string.IsNullOrEmpty(this.AladdinItemSlot3))
                this.messages.MessageMappings["Party"]["SendAladdinItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.AladdinItemSlot3);

            if (!string.IsNullOrEmpty(this.AladdinItemSlot4))
                this.messages.MessageMappings["Party"]["SendAladdinItemSlot4Message"].Method.Invoke(ManipulationType.Set, this.AladdinItemSlot4);

            if (!string.IsNullOrEmpty(this.AladdinItemSlot5))
                this.messages.MessageMappings["Party"]["SendAladdinItemSlot5Message"].Method.Invoke(ManipulationType.Set, this.AladdinItemSlot5);

            // TODO Add a better ability system
        }

        public async Task RefreshJackSkellingtonPartyCache()
        {
            if (!string.IsNullOrEmpty(this.JackSkellingtonAccessorySlots))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonAccessorySlots);

            if (!string.IsNullOrEmpty(this.JackSkellingtonAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonAccessorySlot1);

            if (!string.IsNullOrEmpty(this.JackSkellingtonAccessorySlot2))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonAccessorySlot2Message"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonAccessorySlot2);

            if (!string.IsNullOrEmpty(this.JackSkellingtonItemSlots))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonItemSlots);

            if (!string.IsNullOrEmpty(this.JackSkellingtonItemSlot1))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonItemSlot1);

            if (!string.IsNullOrEmpty(this.JackSkellingtonItemSlot2))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonItemSlot2);

            if (!string.IsNullOrEmpty(this.JackSkellingtonItemSlot3))
                this.messages.MessageMappings["Party"]["SendJackSkellingtonItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.JackSkellingtonItemSlot3);

            // TODO Add a better ability system
        }

        public async Task RefreshSimbaPartyCache()
        {
            if (!string.IsNullOrEmpty(this.SimbaAccessorySlots))
                this.messages.MessageMappings["Party"]["SendSimbaAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.SimbaAccessorySlots);

            if (!string.IsNullOrEmpty(this.SimbaAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendSimbaAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.SimbaAccessorySlot1);

            if (!string.IsNullOrEmpty(this.SimbaAccessorySlot2))
                this.messages.MessageMappings["Party"]["SendSimbaAccessorySlot2Message"].Method.Invoke(ManipulationType.Set, this.SimbaAccessorySlot2);

            if (!string.IsNullOrEmpty(this.SimbaItemSlots))
                this.messages.MessageMappings["Party"]["SendSimbaItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.SimbaItemSlots);

            if (!string.IsNullOrEmpty(this.SimbaItemSlot1))
                this.messages.MessageMappings["Party"]["SendSimbaItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.SimbaItemSlot1);

            if (!string.IsNullOrEmpty(this.SimbaItemSlot2))
                this.messages.MessageMappings["Party"]["SendSimbaItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.SimbaItemSlot2);
            
            if (!string.IsNullOrEmpty(this.SimbaItemSlot3))
                this.messages.MessageMappings["Party"]["SendSimbaItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.SimbaItemSlot3);

            // TODO Add a better ability system
        }

        public async Task RefreshTronPartyCache()
        {
            if (!string.IsNullOrEmpty(this.TronArmorSlots))
                this.messages.MessageMappings["Party"]["SendTronArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.TronArmorSlots);

            if (!string.IsNullOrEmpty(this.TronArmorSlot1))
                this.messages.MessageMappings["Party"]["SendTronArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.TronArmorSlot1);

            if (!string.IsNullOrEmpty(this.TronAccessorySlots))
                this.messages.MessageMappings["Party"]["SendTronAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.TronAccessorySlots);

            if (!string.IsNullOrEmpty(this.TronAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendTronAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.TronAccessorySlot1);

            if (!string.IsNullOrEmpty(this.TronItemSlots))
                this.messages.MessageMappings["Party"]["SendTronItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.TronItemSlots);

            if (!string.IsNullOrEmpty(this.TronItemSlot1))
                this.messages.MessageMappings["Party"]["SendTronItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.TronItemSlot1);

            if (!string.IsNullOrEmpty(this.TronItemSlot2))
                this.messages.MessageMappings["Party"]["SendTronItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.TronItemSlot2);

            // TODO Add a better ability system
        }

        public async Task RefreshRikuPartyCache()
        {
            if (!string.IsNullOrEmpty(this.RikuArmorSlots))
                this.messages.MessageMappings["Party"]["SendRikuArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.RikuArmorSlots);

            if (!string.IsNullOrEmpty(this.RikuArmorSlot1))
                this.messages.MessageMappings["Party"]["SendRikuArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.RikuArmorSlot1);

            if (!string.IsNullOrEmpty(this.RikuArmorSlot2))
                this.messages.MessageMappings["Party"]["SendRikuArmorSlot2Message"].Method.Invoke(ManipulationType.Set, this.RikuArmorSlot2);

            if (!string.IsNullOrEmpty(this.RikuAccessorySlots))
                this.messages.MessageMappings["Party"]["SendRikuAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.RikuAccessorySlots);

            if (!string.IsNullOrEmpty(this.RikuAccessorySlot1))
                this.messages.MessageMappings["Party"]["SendRikuAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.RikuAccessorySlot1);

            if (!string.IsNullOrEmpty(this.RikuItemSlots))
                this.messages.MessageMappings["Party"]["SendRikuItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.RikuItemSlots);

            if (!string.IsNullOrEmpty(this.RikuItemSlot1))
                this.messages.MessageMappings["Party"]["SendRikuItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.RikuItemSlot1);

            if (!string.IsNullOrEmpty(this.RikuItemSlot2))
                this.messages.MessageMappings["Party"]["SendRikuItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.RikuItemSlot2);
            
            if (!string.IsNullOrEmpty(this.RikuItemSlot3))
                this.messages.MessageMappings["Party"]["SendRikuItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.RikuItemSlot3);

            if (!string.IsNullOrEmpty(this.RikuItemSlot4))
                this.messages.MessageMappings["Party"]["SendRikuItemSlot4Message"].Method.Invoke(ManipulationType.Set, this.RikuItemSlot4);
            
            if (!string.IsNullOrEmpty(this.RikuItemSlot5))
                this.messages.MessageMappings["Party"]["SendRikuItemSlot5Message"].Method.Invoke(ManipulationType.Set, this.RikuItemSlot5);

            if (!string.IsNullOrEmpty(this.RikuItemSlot6))
                this.messages.MessageMappings["Party"]["SendRikuItemSlot6Message"].Method.Invoke(ManipulationType.Set, this.RikuItemSlot6);

            // TODO Add a better ability system
        }

        #endregion Refresh Cache Sub-Methods
    }
}