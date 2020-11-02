using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Misc

        public static bool SendMunnyMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032DF70,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Misc
    }
}