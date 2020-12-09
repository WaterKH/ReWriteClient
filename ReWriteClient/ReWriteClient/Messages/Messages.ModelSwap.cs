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

        public static bool SendDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
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
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendHalloweenDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FAE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendHalloweenDonaldEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FAE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendChristmasDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendChristmasDonaldEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpaceParanoidsDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpaceParanoidsDonaldEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTimelessRiverDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE121E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTimelessRiverDonaldEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE121E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBirdDonaldAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1252,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBirdDonaldEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1252,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Donald

        #region Goofy

        public static bool SendGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
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
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B6C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendHalloweenGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FB0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendHalloweenGoofyEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FB0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendChristmasGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendChristmasGoofyEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE4,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpaceParanoidsGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpaceParanoidsGoofyEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTimelessRiverGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1220,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTimelessRiverGoofyEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1220,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTortoiseGoofyAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1254,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTortoiseGoofyEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1254,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Goofy

        #region Mulan

        public static bool SendMulanAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10B6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMulanEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10B6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Mulan

        #region Beast

        public static bool SendBeastAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE104E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBeastEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE104E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Beast

        #region Auron

        public static bool SendAuronAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0EE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAuronEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0EE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Auron

        #region Captain Jack Sparrow

        public static bool SendCaptainJackSparrowAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0DDE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCaptainJackSparrowEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0DDE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Captain Jack Sparrow

        #region Aladdin

        public static bool SendAladdinAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0F7E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendAladdinEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0F7E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Aladdin

        #region Jack Skellington

        public static bool SendJackSkellingtonAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE101A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendJackSkellingtonEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE101A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Jack Skellington

        #region Simba

        public static bool SendSimbaAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1256,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSimbaEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1256,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Simba

        #region Tron

        public static bool SendTronAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendTronEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Tron

        #region Riku

        public static bool SendRikuAllyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRikuEnemyModelMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Riku
    }
}