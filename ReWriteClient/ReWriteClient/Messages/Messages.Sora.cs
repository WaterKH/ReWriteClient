using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Stats

        public static bool SendSoraLevelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E02F,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraCurrentHPMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C750,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMaxHPMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C754,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAPMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E028,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraStrengthMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E029,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E02A,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraDefenseMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E02B,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Stats

        #region Magic

        public static bool SendSoraCurrentMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C8D0,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMaxMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C8D4,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraRechargeMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C90C,
                Type = DataType.Float,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendFireMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C4,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBlizzardMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C5,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendThunderMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C6,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCureMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C7,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMagnetMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0FF,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendReflectMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F100,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Magic

        #region Equipment

        public static bool SendEquipKeybladeMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E020,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendEquipValorKeybladeMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EE24,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendEquipMasterKeybladeMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EECC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendEquipFinalKeybladeMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EF04,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Equipment

        #region Armor

        public static bool SendSoraArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E030,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E034,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot2Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E036,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot3Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E038,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot4Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E03A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendSoraAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E031,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E044,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot2Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E046,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot3Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E048,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot4Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E04A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendSoraItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E032,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot1Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E054,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot2Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E056,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot3Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E058,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot4Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E05A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot5Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E05C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot6Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E05E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot7Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E060,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot8Message(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E062,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Abilities

        public static bool SendSoraActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var memoryObject = new MemoryObject { Address = 0x2032E074, Type = DataType.Byte, ManipulationType = manipulationType, Value = value, IsValueHex = true };

            CheckMemoryForAbility(memoryObject, 1, 128); // Add Ability map to account for how max/ toggleValue are assigned

            return true;
        }

        public static bool SendSoraDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var memoryObject = new MemoryObject { Address = 0x2032E074, Type = DataType.Byte, ManipulationType = manipulationType, Value = value, IsValueHex = true };

            CheckMemoryForAbility(memoryObject, 1, 0); // Add Ability map to account for how max/ toggleValue are assigned

            return true;
        }

        #endregion Abilities
    }
}