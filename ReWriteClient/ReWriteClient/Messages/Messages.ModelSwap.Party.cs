using ReWriteClient.Data;
using ReWriteClient.Enums;
using System;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Party

        public static bool SendMulanModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.MulanModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10B6,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            // TODO May need to update this to be Ping or Mulan depending on flag
            SetupModelTimer(PartyModelTimer, 0x21CE10B6, "100", "Mulan");

            return true;
        }

        public static bool SendBeastModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BeastModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE104E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
            
            SetupModelTimer(PartyModelTimer, 0x21CE104E, "94", "Beast");

            return true;
        }

        public static bool SendAuronModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AuronModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0EE2,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(PartyModelTimer, 0x21CE0EE2, "101", "Auron");

            return true;
        }

        public static bool SendCaptainJackSparrowModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CaptainJackSparrowModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0DDE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(PartyModelTimer, 0x21CE0DDE, "2077", "Sparrow");

            return true;
        }

        public static bool SendAladdinModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.AladdinModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0F7E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(PartyModelTimer, 0x21CE0F7E, "98", "Aladdin");

            return true;
        }

        public static bool SendJackSkellingtonModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.JackSkellingtonModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE101A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            // TODO May need to update this to be Christmas or Halloween Jack depending on flag
            SetupModelTimer(PartyModelTimer, 0x21CE101A, "96", "Skellington");

            return true;
        }

        public static bool SendSimbaModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SimbaModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1256,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(PartyModelTimer, 0x21CE1256, "97", "Simba");

            return true;
        }

        public static bool SendTronModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TronModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11EE,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(PartyModelTimer, 0x21CE11EE, "724", "Tron");

            return true;
        }

        public static bool SendRikuModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RikuModel = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE10EA,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(PartyModelTimer, 0x21CE10EA, "2073", "Riku");

            return true;
        }

        #endregion Party
    }
}