using ReWriteClient.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                this.messages.MessageMappings["Sora"]["SendSoraLevelMessage"].Invoke(ManipulationType.Set, this.SoraLevel);

            if (!string.IsNullOrEmpty(this.SoraCurrentHP))
                this.messages.MessageMappings["Sora"]["SendSoraCurrentHPMessage"].Invoke(ManipulationType.Set, this.SoraCurrentHP);

            if (!string.IsNullOrEmpty(this.SoraMaxHP))
                this.messages.MessageMappings["Sora"]["SendSoraMaxHPMessage"].Invoke(ManipulationType.Set, this.SoraMaxHP);

            if (!string.IsNullOrEmpty(this.SoraCurrentMagic))
                this.messages.MessageMappings["Sora"]["SendSoraCurrentMagicMessage"].Invoke(ManipulationType.Set, this.SoraCurrentMagic);

            if (!string.IsNullOrEmpty(this.SoraMaxMagic))
                this.messages.MessageMappings["Sora"]["SendSoraMaxMagicMessage"].Invoke(ManipulationType.Set, this.SoraMaxMagic);

            if (!string.IsNullOrEmpty(this.SoraAPBoost))
                this.messages.MessageMappings["Sora"]["SendSoraAPBoostMessage"].Invoke(ManipulationType.Set, this.SoraAPBoost);

            if (!string.IsNullOrEmpty(this.SoraStrengthBoost))
                this.messages.MessageMappings["Sora"]["SendSoraStrengthBoostMessage"].Invoke(ManipulationType.Set, this.SoraStrengthBoost);

            if (!string.IsNullOrEmpty(this.SoraMagicBoost))
                this.messages.MessageMappings["Sora"]["SendSoraMagicBoostMessage"].Invoke(ManipulationType.Set, this.SoraMagicBoost);

            if (!string.IsNullOrEmpty(this.SoraDefenseBoost))
                this.messages.MessageMappings["Sora"]["SendSoraDefenseBoostMessage"].Invoke(ManipulationType.Set, this.SoraDefenseBoost);

            if (!string.IsNullOrEmpty(this.SoraSpeed))
                this.messages.MessageMappings["Sora"]["SendSoraSpeedMessage"].Invoke(ManipulationType.Set, this.SoraSpeed);
        }

        public async Task RefreshSoraMagicCache()
        {
            if (!string.IsNullOrEmpty(this.SoraFireMagic))
                this.messages.MessageMappings["Sora"]["SendFireMagicMessage"].Invoke(ManipulationType.Set, this.SoraFireMagic);

            if (!string.IsNullOrEmpty(this.SoraBlizzardMagic))
                this.messages.MessageMappings["Sora"]["SendBlizzardMagicMessage"].Invoke(ManipulationType.Set, this.SoraBlizzardMagic);

            if (!string.IsNullOrEmpty(this.SoraThunderMagic))
                this.messages.MessageMappings["Sora"]["SendThunderMagicMessage"].Invoke(ManipulationType.Set, this.SoraThunderMagic);

            if (!string.IsNullOrEmpty(this.SoraCureMagic))
                this.messages.MessageMappings["Sora"]["SendSoraCureMagicMessage"].Invoke(ManipulationType.Set, this.SoraCureMagic);

            if (!string.IsNullOrEmpty(this.SoraMagnetMagic))
                this.messages.MessageMappings["Sora"]["SendMagnetMagicMessage"].Invoke(ManipulationType.Set, this.SoraMagnetMagic);
            
            if (!string.IsNullOrEmpty(this.SoraReflectMagic))
                this.messages.MessageMappings["Sora"]["SendReflectMagicMessage"].Invoke(ManipulationType.Set, this.SoraReflectMagic);
        }

        public async Task RefreshSoraEquipmentCache()
        {
            if (!string.IsNullOrEmpty(this.SoraKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipKeybladeMessage"].Invoke(ManipulationType.Set, this.SoraFireMagic);

            if (!string.IsNullOrEmpty(this.SoraValorKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipValorKeybladeMessage"].Invoke(ManipulationType.Set, this.SoraValorKeyblade);

            if (!string.IsNullOrEmpty(this.SoraMasterKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipMasterKeybladeMessage"].Invoke(ManipulationType.Set, this.SoraMasterKeyblade);

            if (!string.IsNullOrEmpty(this.SoraFinalKeyblade))
                this.messages.MessageMappings["Sora"]["SendEquipFinalKeybladeMessage"].Invoke(ManipulationType.Set, this.SoraFinalKeyblade);
        }

        public async Task RefreshSoraArmorCache()
        {
            if (!string.IsNullOrEmpty(this.SoraArmorSlots))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlotsMessage"].Invoke(ManipulationType.Set, this.SoraArmorSlots);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot1Message"].Invoke(ManipulationType.Set, this.SoraArmorSlot1);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot2Message"].Invoke(ManipulationType.Set, this.SoraArmorSlot2);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot3Message"].Invoke(ManipulationType.Set, this.SoraArmorSlot3);

            if (!string.IsNullOrEmpty(this.SoraArmorSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraArmorSlot4Message"].Invoke(ManipulationType.Set, this.SoraArmorSlot4);
        }

        public async Task RefreshSoraAccessoryCache()
        {
            if (!string.IsNullOrEmpty(this.SoraAccessorySlots))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlotsMessage"].Invoke(ManipulationType.Set, this.SoraAccessorySlots);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot1))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot1Message"].Invoke(ManipulationType.Set, this.SoraAccessorySlot1);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot2))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot2Message"].Invoke(ManipulationType.Set, this.SoraAccessorySlot2);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot3))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot3Message"].Invoke(ManipulationType.Set, this.SoraAccessorySlot3);

            if (!string.IsNullOrEmpty(this.SoraAccessorySlot4))
                this.messages.MessageMappings["Sora"]["SendSoraAccessorySlot4Message"].Invoke(ManipulationType.Set, this.SoraAccessorySlot4);
        }

        public async Task RefreshSoraItemsCache()
        {
            if (!string.IsNullOrEmpty(this.SoraItemSlots))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlotsMessage"].Invoke(ManipulationType.Set, this.SoraItemSlots);

            if (!string.IsNullOrEmpty(this.SoraItemSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot1Message"].Invoke(ManipulationType.Set, this.SoraItemSlot1);

            if (!string.IsNullOrEmpty(this.SoraItemSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot2Message"].Invoke(ManipulationType.Set, this.SoraItemSlot2);

            if (!string.IsNullOrEmpty(this.SoraItemSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot3Message"].Invoke(ManipulationType.Set, this.SoraItemSlot3);

            if (!string.IsNullOrEmpty(this.SoraItemSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot4Message"].Invoke(ManipulationType.Set, this.SoraItemSlot4);
            
            if (!string.IsNullOrEmpty(this.SoraItemSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot1Message"].Invoke(ManipulationType.Set, this.SoraItemSlot1);

            if (!string.IsNullOrEmpty(this.SoraItemSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot2Message"].Invoke(ManipulationType.Set, this.SoraItemSlot2);

            if (!string.IsNullOrEmpty(this.SoraItemSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot3Message"].Invoke(ManipulationType.Set, this.SoraItemSlot3);

            if (!string.IsNullOrEmpty(this.SoraItemSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraItemSlot4Message"].Invoke(ManipulationType.Set, this.SoraItemSlot4);
        }

        public async Task RefreshSoraQuickMenuCache()
        {
            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot1))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot1Message"].Invoke(ManipulationType.Set, this.SoraQuickMenuSlot1);

            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot2))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot2Message"].Invoke(ManipulationType.Set, this.SoraQuickMenuSlot2);

            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot3))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot3Message"].Invoke(ManipulationType.Set, this.SoraQuickMenuSlot3);

            if (!string.IsNullOrEmpty(this.SoraQuickMenuSlot4))
                this.messages.MessageMappings["Sora"]["SendSoraQuickMenuSlot4Message"].Invoke(ManipulationType.Set, this.SoraQuickMenuSlot4);
        }

        public async Task RefreshSoraAbilitiesCache()
        {
            foreach (var ability in this.SoraAbilities)
            {
                var abilityValue = AbilityMappings.SoraAbilities[ability];

                var memoryObject = new MemoryObject { Address = 0x2032E074, Type = DataType.Byte, ManipulationType = ManipulationType.Set, Value = abilityValue.Value.ToString(), IsValueHex = true };

                this.memoryProcessor.UpdateAbilityMemory(memoryObject, abilityValue.MaxNumber, abilityValue.ToggleValue, 148);
            }
        }

        #endregion Refresh Cache Sub-Methods
    }
}