using ReWriteClient.Data;
using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Sora

        public static bool SendSoraModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B68,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraLionModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraLionModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1250,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraTimelessRiverModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraTimelessRiverModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE121C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraHalloweenModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraHalloweenModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FAC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraChristmasModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraChristmasModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraSpaceParanoidsModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraSpaceParanoidsModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11E8,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Sora

        #region Donald

        public static bool SendDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }
        public static bool SendBirdDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldBirdModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1252,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTimelessRiverDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldTimelessRiverModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE121E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendHalloweenDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldHalloweenModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FAE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendChristmasDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldChristmasModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpaceParanoidsDonaldModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DonaldSpaceParanoidsModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Donald

        #region Goofy

        public static bool SendGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTortoiseGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyTortoiseModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1254,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTimelessRiverGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyTimelessRiverModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1220,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendHalloweenGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyHalloweenModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FB0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendChristmasGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofyChristmasModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpaceParanoidsGoofyModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.GoofySpaceParanoidsModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Goofy

        #region Party

        public static bool SendMulanModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10B6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE104E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAuronModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0EE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0DDE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0F7E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE101A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1256,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTronModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuModel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Party
    }
}