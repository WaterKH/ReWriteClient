using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        public static bool SendSoraModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B68,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x2036C3E8, Type = DataType.FourBytes, ManipulationType = ManipulationType.Set, Value = "1503732" });

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDonaldEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x2036C3E8, Type = DataType.FourBytes, ManipulationType = ManipulationType.Set, Value = "1503612" });

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x2036C3E8, Type = DataType.FourBytes, ManipulationType = ManipulationType.Set, Value = "1503732" });

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendGoofyEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject { Address = 0x2036C3E8, Type = DataType.FourBytes, ManipulationType = ManipulationType.Set, Value = "1503612" });

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }
    }
}
