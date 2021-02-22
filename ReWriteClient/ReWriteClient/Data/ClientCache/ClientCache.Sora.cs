using ReWriteClient.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waterkh.Common.Mappings;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public partial class ClientCache
    {
        #region Properties

        #region Stats

        public string SoraLevel { get; set; }
        public string SoraCurrentHP { get; set; }
        public string SoraMaxHP { get; set; }
        public bool IsSoraInvincible { get; set; }
        public string SoraCurrentMagic { get; set; }
        public string SoraMaxMagic { get; set; }
        public string SoraAPBoost { get; set; }
        public string SoraStrengthBoost { get; set; }
        public string SoraMagicBoost { get; set; }
        public string SoraDefenseBoost { get; set; }
        public string SoraSpeed { get; set; }

        #endregion Stats

        #region Magic

        public string SoraFireMagic { get; set; }
        public string SoraBlizzardMagic { get; set; }
        public string SoraThunderMagic { get; set; }
        public string SoraCureMagic { get; set; }
        public string SoraMagnetMagic { get; set; }
        public string SoraReflectMagic { get; set; }

        #region Cost

        #region Spells

        public string SoraFireMagicCost { get; set; }
        public string SoraBlizzardMagicCost { get; set; }
        public string SoraThunderMagicCost { get; set; }
        public string SoraCureMagicCost { get; set; }
        public string SoraMagnetMagicCost { get; set; }
        public string SoraReflectMagicCost { get; set; }

        #endregion Spells

        #region Limits

        public string TrinityLimitMagicCost { get; set; }
        public string DuckFlareMagicCost { get; set; }
        public string CometMagicCost { get; set; }
        public string WhirliGoofMagicCost { get; set; }
        public string KnocksmashMagicCost { get; set; }
        public string RedRocketMagicCost { get; set; }
        public string TwinHowlMagicCost { get; set; }
        public string BushidoMagicCost { get; set; }
        public string BluffMagicCost { get; set; }
        public string DanceCallMagicCost { get; set; }
        public string SpeedsterMagicCost { get; set; }
        public string WildcatMagicCost { get; set; }
        public string SetupMagicCost { get; set; }
        public string SessionMagicCost { get; set; }

        #endregion Limits

        #region Limit Form

        public string StrikeRaidMagicCost { get; set; }
        public string SonicBladeMagicCost { get; set; }
        public string RagnarokMagicCost { get; set; }
        public string ArsArcanumMagicCost { get; set; }

        #endregion Limit Form

        #endregion Cost

        #endregion Magic

        #region Equipment

        public string SoraKeyblade { get; set; }
        public string SoraValorKeyblade { get; set; }
        public string SoraMasterKeyblade { get; set; }
        public string SoraFinalKeyblade { get; set; }

        #endregion Equipment

        #region Armor

        public string SoraArmorSlots { get; set; }
        public string SoraArmorSlot1 { get; set; }
        public string SoraArmorSlot2 { get; set; }
        public string SoraArmorSlot3 { get; set; }
        public string SoraArmorSlot4 { get; set; }

        #endregion Armor

        #region Accessory

        public string SoraAccessorySlots { get; set; }
        public string SoraAccessorySlot1 { get; set; }
        public string SoraAccessorySlot2 { get; set; }
        public string SoraAccessorySlot3 { get; set; }
        public string SoraAccessorySlot4 { get; set; }

        #endregion Accessory

        #region Items

        public string SoraItemSlots { get; set; }
        public string SoraItemSlot1 { get; set; }
        public string SoraItemSlot2 { get; set; }
        public string SoraItemSlot3 { get; set; }
        public string SoraItemSlot4 { get; set; }
        public string SoraItemSlot5 { get; set; }
        public string SoraItemSlot6 { get; set; }
        public string SoraItemSlot7 { get; set; }
        public string SoraItemSlot8 { get; set; }

        #endregion Items

        #region Quick Menu

        public string SoraQuickMenuSlot1 { get; set; }
        public string SoraQuickMenuSlot2 { get; set; }
        public string SoraQuickMenuSlot3 { get; set; }
        public string SoraQuickMenuSlot4 { get; set; }

        #endregion Quick Menu

        #region Abilities

        public List<string> SoraAbilities { get; set; } = new List<string>();
        // TODO Add a list of abilities removed?

        #endregion Abilities

        #endregion Properties

        public async Task RefreshSoraCache()
        {
            await this.RefreshSoraStatsCache();
            await this.RefreshSoraMagicCache();
            await this.RefreshSoraEquipmentCache();
            await this.RefreshSoraArmorCache();
            await this.RefreshSoraAccessoryCache();
            await this.RefreshSoraItemsCache();
            await this.RefreshSoraQuickMenuCache();
            await this.RefreshSoraAbilitiesCache();
        }

        #region Refresh Cache Sub-Methods

        public async Task RefreshSoraStatsCache()
        {
            if (!string.IsNullOrEmpty(this.SoraLevel))
                this.messages.MessageMappings["Sora"]["SendSoraLevelMessage"].Method.Invoke(ManipulationType.Set, this.SoraLevel);

            if (!string.IsNullOrEmpty(this.SoraCurrentHP))
                this.messages.MessageMappings["Sora"]["SendSoraCurrentHPMessage"].Method.Invoke(ManipulationType.Set, this.SoraCurrentHP);

            if (!string.IsNullOrEmpty(this.SoraMaxHP))
                this.messages.MessageMappings["Sora"]["SendSoraMaxHPMessage"].Method.Invoke(ManipulationType.Set, this.SoraMaxHP);

            if (!string.IsNullOrEmpty(this.SoraCurrentMagic))
                this.messages.MessageMappings["Sora"]["SendSoraCurrentMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraCurrentMagic);

            if (!string.IsNullOrEmpty(this.SoraMaxMagic))
                this.messages.MessageMappings["Sora"]["SendSoraMaxMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraMaxMagic);

            if (!string.IsNullOrEmpty(this.SoraAPBoost))
                this.messages.MessageMappings["Sora"]["SendSoraAPBoostMessage"].Method.Invoke(ManipulationType.Set, this.SoraAPBoost);

            if (!string.IsNullOrEmpty(this.SoraStrengthBoost))
                this.messages.MessageMappings["Sora"]["SendSoraStrengthBoostMessage"].Method.Invoke(ManipulationType.Set, this.SoraStrengthBoost);

            if (!string.IsNullOrEmpty(this.SoraMagicBoost))
                this.messages.MessageMappings["Sora"]["SendSoraMagicBoostMessage"].Method.Invoke(ManipulationType.Set, this.SoraMagicBoost);

            if (!string.IsNullOrEmpty(this.SoraDefenseBoost))
                this.messages.MessageMappings["Sora"]["SendSoraDefenseBoostMessage"].Method.Invoke(ManipulationType.Set, this.SoraDefenseBoost);

            if (!string.IsNullOrEmpty(this.SoraSpeed))
                this.messages.MessageMappings["Sora"]["SendSoraSpeedMessage"].Method.Invoke(ManipulationType.Set, this.SoraSpeed);
        }

        public async Task RefreshSoraMagicCache()
        {
            if (!string.IsNullOrEmpty(this.SoraFireMagic))
                this.messages.MessageMappings["Sora"]["SendFireMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraFireMagic);

            if (!string.IsNullOrEmpty(this.SoraBlizzardMagic))
                this.messages.MessageMappings["Sora"]["SendBlizzardMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraBlizzardMagic);

            if (!string.IsNullOrEmpty(this.SoraThunderMagic))
                this.messages.MessageMappings["Sora"]["SendThunderMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraThunderMagic);

            if (!string.IsNullOrEmpty(this.SoraCureMagic))
                this.messages.MessageMappings["Sora"]["SendSoraCureMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraCureMagic);

            if (!string.IsNullOrEmpty(this.SoraMagnetMagic))
                this.messages.MessageMappings["Sora"]["SendMagnetMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraMagnetMagic);
            
            if (!string.IsNullOrEmpty(this.SoraReflectMagic))
                this.messages.MessageMappings["Sora"]["SendReflectMagicMessage"].Method.Invoke(ManipulationType.Set, this.SoraReflectMagic);

            #region Cost

            #region Spells

            if (!string.IsNullOrEmpty(this.SoraFireMagicCost))
                this.messages.MessageMappings["Sora"]["SendFireMagicCostMessage"].Method.Invoke(ManipulationType.Set, this.SoraFireMagicCost);

            if (!string.IsNullOrEmpty(this.SoraBlizzardMagicCost))
                this.messages.MessageMappings["Sora"]["SendBlizzardMagicCostMessage"].Method.Invoke(ManipulationType.Set, this.SoraBlizzardMagicCost);

            if (!string.IsNullOrEmpty(this.SoraThunderMagicCost))
                this.messages.MessageMappings["Sora"]["SendThunderMagicCostMessage"].Method.Invoke(ManipulationType.Set, this.SoraThunderMagicCost);

            if (!string.IsNullOrEmpty(this.SoraCureMagicCost))
                this.messages.MessageMappings["Sora"]["SendSoraCureMagicCostMessage"].Method.Invoke(ManipulationType.Set, this.SoraCureMagicCost);

            if (!string.IsNullOrEmpty(this.SoraMagnetMagicCost))
                this.messages.MessageMappings["Sora"]["SendMagnetMagicCostMessage"].Method.Invoke(ManipulationType.Set, this.SoraMagnetMagicCost);

            if (!string.IsNullOrEmpty(this.SoraReflectMagicCost))
                this.messages.MessageMappings["Sora"]["SendReflectMagicCostMessage"].Method.Invoke(ManipulationType.Set, this.SoraReflectMagicCost);

            #endregion Spells

            #region Limits

            if (!string.IsNullOrEmpty(this.TrinityLimitMagicCost))
                this.messages.MessageMappings["Sora"]["TrinityLimitCostMessage"].Method.Invoke(ManipulationType.Set, this.TrinityLimitMagicCost);

            if (!string.IsNullOrEmpty(this.DuckFlareMagicCost))
                this.messages.MessageMappings["Sora"]["DuckFlareCostMessage"].Method.Invoke(ManipulationType.Set, this.DuckFlareMagicCost);

            if (!string.IsNullOrEmpty(this.CometMagicCost))
                this.messages.MessageMappings["Sora"]["CometCostMessage"].Method.Invoke(ManipulationType.Set, this.CometMagicCost);

            if (!string.IsNullOrEmpty(this.WhirliGoofMagicCost))
                this.messages.MessageMappings["Sora"]["WhirliGoofCostMessage"].Method.Invoke(ManipulationType.Set, this.WhirliGoofMagicCost);

            if (!string.IsNullOrEmpty(this.KnocksmashMagicCost))
                this.messages.MessageMappings["Sora"]["KnocksmashCostMessage"].Method.Invoke(ManipulationType.Set, this.KnocksmashMagicCost);

            if (!string.IsNullOrEmpty(this.RedRocketMagicCost))
                this.messages.MessageMappings["Sora"]["RedRocketCostMessage"].Method.Invoke(ManipulationType.Set, this.RedRocketMagicCost);

            if (!string.IsNullOrEmpty(this.TwinHowlMagicCost))
                this.messages.MessageMappings["Sora"]["TwinHowlCostMessage"].Method.Invoke(ManipulationType.Set, this.TwinHowlMagicCost);

            if (!string.IsNullOrEmpty(this.BushidoMagicCost))
                this.messages.MessageMappings["Sora"]["BushidoCostMessage"].Method.Invoke(ManipulationType.Set, this.BushidoMagicCost);

            if (!string.IsNullOrEmpty(this.BluffMagicCost))
                this.messages.MessageMappings["Sora"]["BluffCostMessage"].Method.Invoke(ManipulationType.Set, this.BluffMagicCost);

            if (!string.IsNullOrEmpty(this.DanceCallMagicCost))
                this.messages.MessageMappings["Sora"]["DanceCallCostMessage"].Method.Invoke(ManipulationType.Set, this.DanceCallMagicCost);

            if (!string.IsNullOrEmpty(this.SpeedsterMagicCost))
                this.messages.MessageMappings["Sora"]["SpeedsterCostMessage"].Method.Invoke(ManipulationType.Set, this.SpeedsterMagicCost);

            if (!string.IsNullOrEmpty(this.WildcatMagicCost))
                this.messages.MessageMappings["Sora"]["WildcatCostMessage"].Method.Invoke(ManipulationType.Set, this.WildcatMagicCost);

            if (!string.IsNullOrEmpty(this.SetupMagicCost))
                this.messages.MessageMappings["Sora"]["SetupCostMessage"].Method.Invoke(ManipulationType.Set, this.SetupMagicCost);

            if (!string.IsNullOrEmpty(this.SessionMagicCost))
                this.messages.MessageMappings["Sora"]["SessionCostMessage"].Method.Invoke(ManipulationType.Set, this.SessionMagicCost);

            #endregion Limits

            #region Limit Form

            if (!string.IsNullOrEmpty(this.StrikeRaidMagicCost))
                this.messages.MessageMappings["Sora"]["StrikeRaidCostMessage"].Method.Invoke(ManipulationType.Set, this.StrikeRaidMagicCost);

            if (!string.IsNullOrEmpty(this.SonicBladeMagicCost))
                this.messages.MessageMappings["Sora"]["SonicBladeCostMessage"].Method.Invoke(ManipulationType.Set, this.SonicBladeMagicCost);

            if (!string.IsNullOrEmpty(this.RagnarokMagicCost))
                this.messages.MessageMappings["Sora"]["RagnarokCostMessage"].Method.Invoke(ManipulationType.Set, this.RagnarokMagicCost);

            if (!string.IsNullOrEmpty(this.ArsArcanumMagicCost))
                this.messages.MessageMappings["Sora"]["ArsArcanumCostMessage"].Method.Invoke(ManipulationType.Set, this.ArsArcanumMagicCost);

            #endregion Limit Form

            #endregion Cost
        }

        public async Task RefreshSoraEquipmentCache()
        {
            if (!string.IsNullOrEmpty(this.SoraKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipKeybladeMessage"].Method.Invoke(ManipulationType.Set, this.SoraKeyblade);

            if (!string.IsNullOrEmpty(this.SoraValorKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipValorKeybladeMessage"].Method.Invoke(ManipulationType.Set, this.SoraValorKeyblade);

            if (!string.IsNullOrEmpty(this.SoraMasterKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipMasterKeybladeMessage"].Method.Invoke(ManipulationType.Set, this.SoraMasterKeyblade);

            if (!string.IsNullOrEmpty(this.SoraFinalKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipFinalKeybladeMessage"].Method.Invoke(ManipulationType.Set, this.SoraFinalKeyblade);
        }

        public async Task RefreshSoraArmorCache()
        {
            if (!string.IsNullOrEmpty(this.SoraArmorSlots))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlotsMessage"].Method.Invoke(ManipulationType.Set, this.SoraArmorSlots);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot1Message"].Method.Invoke(ManipulationType.Set, this.SoraArmorSlot1);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot2Message"].Method.Invoke(ManipulationType.Set, this.SoraArmorSlot2);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot3Message"].Method.Invoke(ManipulationType.Set, this.SoraArmorSlot3);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot4Message"].Method.Invoke(ManipulationType.Set, this.SoraArmorSlot4);
        }

        public async Task RefreshSoraAccessoryCache()
        {
            if (!string.IsNullOrEmpty(this.SoraAccessorySlots))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlotsMessage"].Method.Invoke(ManipulationType.Set, this.SoraAccessorySlots);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot1))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot1Message"].Method.Invoke(ManipulationType.Set, this.SoraAccessorySlot1);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot2))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot2Message"].Method.Invoke(ManipulationType.Set, this.SoraAccessorySlot2);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot3))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot3Message"].Method.Invoke(ManipulationType.Set, this.SoraAccessorySlot3);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot4))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot4Message"].Method.Invoke(ManipulationType.Set, this.SoraAccessorySlot4);
        }

        public async Task RefreshSoraItemsCache()
        {
            if (!string.IsNullOrEmpty(this.SoraItemSlots))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlotsMessage"].Method.Invoke(ManipulationType.Set, this.SoraItemSlots);

            if (!string.IsNullOrEmpty(this.SoraItemSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot1Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot1);

            if (!string.IsNullOrEmpty(this.SoraItemSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot2Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot2);

            if (!string.IsNullOrEmpty(this.SoraItemSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot3Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot3);

            if (!string.IsNullOrEmpty(this.SoraItemSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot4Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot4);
            
            if (!string.IsNullOrEmpty(this.SoraItemSlot5))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot5Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot5);

            if (!string.IsNullOrEmpty(this.SoraItemSlot6))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot6Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot6);

            if (!string.IsNullOrEmpty(this.SoraItemSlot7))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot7Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot7);

            if (!string.IsNullOrEmpty(this.SoraItemSlot8))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot8Message"].Method.Invoke(ManipulationType.Set, this.SoraItemSlot8);
        }

        public async Task RefreshSoraQuickMenuCache()
        {
            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot1Message"].Method.Invoke(ManipulationType.Set, this.SoraQuickMenuSlot1);

            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot2Message"].Method.Invoke(ManipulationType.Set, this.SoraQuickMenuSlot2);

            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot3Message"].Method.Invoke(ManipulationType.Set, this.SoraQuickMenuSlot3);

            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot4Message"].Method.Invoke(ManipulationType.Set, this.SoraQuickMenuSlot4);
        }

        public async Task RefreshSoraAbilitiesCache()
        {
            foreach (var ability in this.SoraAbilities)
            {
                var abilityValue = AbilityMapping.SoraAbilities[ability];

                var memoryObject = new MemoryObject { Address = 0x2032E074, Type = DataType.Byte, ManipulationType = ManipulationType.Set, Value = abilityValue.Value.ToString(), IsValueHex = true };

                this.memoryProcessor.UpdateAbilityMemory(memoryObject, abilityValue.MaxNumber, abilityValue.ToggleValue, 148);
            }
        }

        #endregion Refresh Cache Sub-Methods
    }
}