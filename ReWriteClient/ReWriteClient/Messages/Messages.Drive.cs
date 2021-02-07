using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Drive

        public static bool SendCurrentDriveCounterMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C901,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMaxDriveCounterMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C902,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDriveTimeMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C904,
                Type = DataType.Float,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDisableDriveMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x20351EB8,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendValorWisdomMasterFinalAntiMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F1F0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendLimitMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F1FA,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAllDriveFormsMessage(ManipulationType manipulationType, string value)
        {
            SendValorWisdomMasterFinalAntiMessage(manipulationType, value);
            SendLimitMessage(manipulationType, value == "0" ? "8" : "8");

            return true;
        }

        public static bool SendActivateFormMessage(ManipulationType manipulationType, string value)
        {
            SendDriveTimeMessage(ManipulationType.Set, "0");

            // TODO Check that we don't already have an option up?

            // Display Popup
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x21C5FF48, Type = DataType.TwoBytes, ManipulationType = ManipulationType.Set, Value = "0" });
            // Set Reaction Command Option
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x21C5FF4E, Type = DataType.TwoBytes, ManipulationType = manipulationType, Value = value });
            // Enable Popup
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x21C5FF51, Type = DataType.Byte, ManipulationType = ManipulationType.Set, Value = "0" });
            // Press Triangle Reaction Command
            CreateInterval(new MemoryObject { Name = "Press Triangle Reaction Command", Address = 0x2034D45D, Type = DataType.Byte, ManipulationType = ManipulationType.Set, Value = ButtonMappings.Button["Triangle"], IsValueHex = true });

            return true; // TODO How would we tell if this triggered or not?
        }

        #endregion Drive
    }
}