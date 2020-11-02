using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Equipment

        public static bool SendEquipStaffMessage(ManipulationType manipulationType, string value)
        {
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
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E16A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items
    }
}