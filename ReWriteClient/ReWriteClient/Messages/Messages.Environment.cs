using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Environment

        public static bool SendRoomChangeMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032BAE0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value.Split(':')[1]
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032BAE1,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value.Split(':')[0]
            });

            return true;
        }

        #endregion Environment
    }
}