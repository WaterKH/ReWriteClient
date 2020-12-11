using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Donald

        #region Equipment

        public static bool SendEquipStaffMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldStaff = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E134,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Equipment

        #region Armor

        public static bool SendDonaldArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E144,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E148,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldArmorSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldArmorSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E14A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendDonaldAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E145,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E158,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldAccessorySlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldAccessorySlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E15A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldAccessorySlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldAccessorySlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E15A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendDonaldItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E146,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E168,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E16A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendDonaldActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.DonaldAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E188, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 34);

            return true;
        }

        public static bool SendDonaldDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.DonaldAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E188, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 34);

            return true;
        }

        #endregion Abilities

        #endregion Donald

        #region Goofy

        #region Equipment

        public static bool SendEquipShieldMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyShield = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E248,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Equipment

        #region Armor

        public static bool SendGoofyArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E258,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E25C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyArmorSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyArmorSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E25E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyArmorSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyArmorSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E260,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendGoofyAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E259,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E26C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyAccessorySlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyAccessorySlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E26E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendGoofyItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E25A,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E27C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E27E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E280,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyItemSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyItemSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E282,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendGoofyActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.GoofyAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E29C, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 34);

            return true;
        }

        public static bool SendGoofyDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.GoofyAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E29C, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 34);

            return true;
        }

        #endregion Abilities

        #endregion Goofy

        #region Mulan

        #region Armor

        public static bool SendMulanArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E594,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMulanArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E598,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendMulanAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E595,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMulanAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E5A8,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendMulanItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E596,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMulanItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E5B8,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMulanItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E5BA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMulanItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E5BC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendMulanActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.MulanAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E5D8, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 16);

            return true;
        }

        public static bool SendMulanDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.MulanAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E5D8, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 16);

            return true;
        }

        #endregion Abilities

        #endregion Mulan

        #region Beast

        #region Accessory

        public static bool SendBeastAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8D1,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8E4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendBeastItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8D2,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8F4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8F6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8F8,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastItemSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastItemSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E8FA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendBeastActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.BeastAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E914, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 16);

            return true;
        }

        public static bool SendBeastDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.BeastAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E914, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 16);

            return true;
        }

        #endregion Abilities

        #endregion Beast

        #region Auron

        #region Armor

        public static bool SendAuronArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E480,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAuronArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E484,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Items

        public static bool SendAuronItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E482,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAuronItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E4A4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAuronItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E4A6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abiltiies

        public static bool SendAuronActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.AuronAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E4C4, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 14);

            return true;
        }

        public static bool SendAuronDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.AuronAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E4C4, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 14);

            return true;
        }

        #endregion Abilities

        #endregion Auron

        #region Captain Jack Sparrow

        #region Armor

        public static bool SendCaptainJackSparrowArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7BC,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7C0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendCaptainJackSparrowAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7BD,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7D0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendCaptainJackSparrowItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7BE,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7E0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7E2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7E4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowItemSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowItemSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E7E6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendCaptainJackSparrowActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.CaptainJackSparrowAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E800, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 24);

            return true;
        }

        public static bool SendCaptainJackSparrowDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.CaptainJackSparrowAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E800, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 24);

            return true;
        }

        #endregion Abilities

        #endregion Captain Jack Sparrow

        #region Aladdin

        #region Armor

        public static bool SendAladdinArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6A8,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6AC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinArmorSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinArmorSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6AE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Items

        public static bool SendAladdinItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6A8,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6CC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6CE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6D0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinItemSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinItemSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6D2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinItemSlot5Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinItemSlot5 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E6D4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendAladdinActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.AladdinAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E6EC, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 18);

            return true;
        }

        public static bool SendAladdinDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.AladdinAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E6EC, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 18);

            return true;
        }

        #endregion Abilities

        #endregion Aladdin

        #region Jack Skellington

        #region Accessory

        public static bool SendJackSkellingtonAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E9E5,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E9F8,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonAccessorySlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonAccessorySlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E9FA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendJackSkellingtonItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E9E5,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EA08,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EA0A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EA0C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendJackSkellingtonActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.JackSkellingtonAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032EA28, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 22);

            return true;
        }

        public static bool SendJackSkellingtonDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.JackSkellingtonAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032EA28, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 22);

            return true;
        }

        #endregion Abilities

        #endregion Jack Skellington

        #region Simba

        #region Accessory

        public static bool SendSimbaAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EAF9,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EB0C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaAccessorySlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaAccessorySlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EB0E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendSimbaItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EAFA,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EB1C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EB1E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EB20,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendSimbaActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.SimbaAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032EB3C, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 18);

            return true;
        }

        public static bool SendSimbaDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.SimbaAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032EB3C, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 18);

            return true;
        }

        #endregion Abilities

        #endregion Simba

        #region Tron

        #region Armor

        public static bool SendTronArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC0C,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTronArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC10,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendTronAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC0D,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTronAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC20,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendTronItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC0E,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTronItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC30,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTronItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EC32,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendTronActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.TronAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032EC50, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 18);

            return true;
        }

        public static bool SendTronDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.TronAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032EC50, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 18);

            return true;
        }

        #endregion Abiltiies

        #endregion Tron

        #region Riku

        #region Armor

        public static bool SendRikuArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED20,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED24,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuArmorSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuArmorSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED26,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendRikuAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED21,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED34,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendRikuItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED22,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED44,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED46,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED48,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuItemSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED4A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuItemSlot5Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlot5 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED4C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuItemSlot6Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuItemSlot6 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032ED4E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendRikuActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.RikuAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032ED64, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 22);

            return true;
        }

        public static bool SendRikuDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.RikuAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032ED64, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 22);

            return true;
        }

        #endregion Abilities

        #endregion Riku
    }
}