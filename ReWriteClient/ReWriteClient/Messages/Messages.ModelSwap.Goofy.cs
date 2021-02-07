using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Goofy

        public static bool SendGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyModel = value;

            if (value.Contains("Random"))
                return true;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(GoofyModelTimer, 0x21CE0B6C, "93", "Goofy");

            return true;
        }

        public static bool SendTortoiseGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyTortoiseModel = value;

            if (value.Contains("Random"))
                return true;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1254,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(GoofyModelTimer, 0x21CE1254, "1563", "TortoiseGoofy");

            return true;
        }

        public static bool SendTimelessRiverGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyTimelessRiverModel = value;

            if (value.Contains("Random"))
                return true;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1220,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(GoofyModelTimer, 0x21CE1220, "1269", "TimelessGoofy");

            return true;
        }

        public static bool SendHalloweenGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyHalloweenModel = value;

            if (value.Contains("Random"))
                return true;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FB0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(GoofyModelTimer, 0x21CE0FB0, "669", "HalloweenGoofy");

            return true;
        }

        public static bool SendChristmasGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyChristmasModel = value;

            if (value.Contains("Random"))
                return true;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(GoofyModelTimer, 0x21CE0FE4, "2396", "ChristmasGoofy");

            return true;
        }

        public static bool SendSpaceParanoidsGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofySpaceParanoidsModel = value;

            if (value.Contains("Random"))
                return true;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(GoofyModelTimer, 0x21CE11EC, "1364", "SpaceGoofy");

            return true;
        }

        #endregion Goofy
    }
}