using ReWriteClient.Data;
using ReWriteClient.Enums;
using System;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Donald

        public static bool SendDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(DonaldModelTimer, 0x21CE0B6A, "92", "Donald");

            return true;
        }

        public static bool SendBirdDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldBirdModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1252,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(DonaldModelTimer, 0x21CE1252, "1519", "BirdDonald");

            return true;
        }

        public static bool SendTimelessRiverDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldTimelessRiverModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE121E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(DonaldModelTimer, 0x21CE121E, "1487", "TimelessDonald");

            return true;
        }

        public static bool SendHalloweenDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldHalloweenModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FAE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(DonaldModelTimer, 0x21CE0FAE, "670", "HalloweenDonald");

            return true;
        }

        public static bool SendChristmasDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldChristmasModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(DonaldModelTimer, 0x21CE0FE2, "2395", "ChristmasDonald");

            return true;
        }

        public static bool SendSpaceParanoidsDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldSpaceParanoidsModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(DonaldModelTimer, 0x21CE11EA, "1370", "SpaceDonald");

            return true;
        }

        #endregion Donald
    }
}