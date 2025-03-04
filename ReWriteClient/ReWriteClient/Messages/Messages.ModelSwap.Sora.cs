﻿using ReWriteClient.Data;
using ReWriteClient.Enums;
using System;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Sora

        public static bool SendSoraModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraModel = value;
            
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B68,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraModelTimer, 0x21CE0B68, "84", "Sora");

            return true;
        }

        public static bool SendSoraLionModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraLionModel = value;
            
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE1250,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraModelTimer, 0x21CE1250, "650", "LionSora");

            return true;
        }

        public static bool SendSoraTimelessRiverModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraTimelessRiverModel = value;
            
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE121C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraModelTimer, 0x21CE121C, "1623", "TimelessSora");

            return true;
        }

        public static bool SendSoraHalloweenModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraHalloweenModel = value;
            
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FAC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraModelTimer, 0x21CE0FAC, "693", "HalloweenSora");

            return true;
        }

        public static bool SendSoraChristmasModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraChristmasModel = value;
            
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0FE0,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraModelTimer, 0x21CE0FE0, "2389", "ChristmasSora");

            return true;
        }

        public static bool SendSoraSpaceParanoidsModelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraSpaceParanoidsModel = value;
            
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE11E8,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraModelTimer, 0x21CE11E8, "1622", "SpaceSora");

            return true;
        }

        #region Forms

        public static bool SendSoraValorFormModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B70,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraFormModelTimer, 0x21CE0B70, "85", "ValorSora");

            return true;
        }

        public static bool SendSoraWisdomFormModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B72,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraFormModelTimer, 0x21CE0B72, "86", "WisdomSora");

            return true;
        }

        public static bool SendSoraLimitFormModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B74,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraFormModelTimer, 0x21CE0B74, "2397", "LimitSora");

            return true;
        }

        public static bool SendSoraMasterFormModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B76,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraFormModelTimer, 0x21CE0B76, "87", "MasterSora");

            return true;
        }

        public static bool SendSoraFinalFormModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B78,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraFormModelTimer, 0x21CE0B78, "88", "FinalSora");

            return true;
        }

        public static bool SendSoraAntiFormModelMessage(ManipulationType manipulationType, string value)
        {
            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE0B7A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });

            SetupModelTimer(SoraFormModelTimer, 0x21CE0B7A, "89", "AntiSora");

            return true;
        }

        #endregion Forms

        #endregion Sora
    }
}