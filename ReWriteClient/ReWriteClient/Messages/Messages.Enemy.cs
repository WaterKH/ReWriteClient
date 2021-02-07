using ReWriteClient.Data;
using ReWriteClient.Enums;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        public static Timer EnemyHealthTimer = new Timer
        {
            AutoReset = true,
            Interval = 60000
        };

        public static Timer EnemyStrengthTimer = new Timer
        {
            AutoReset = true,
            Interval = 60000
        };

        public static Timer EnemyDefenseTimer = new Timer
        {
            AutoReset = true,
            Interval = 60000
        };

        #region Enemy

        public static bool SendBossChangeMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.ChangeBoss = value;

            var change = value.Split(':')[1];
            var changeTo = value.Split(':')[0];

            var enemyChange = EnemyMappings.Enemies[change];
            var enemyChangeTo = EnemyMappings.Enemies[changeTo];

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = enemyChange.ValueAddress,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = enemyChangeTo.Value.ToString(), 
                IsValueHex = true
            });
        }

        #region Timers

        public static bool SendBossActivateHealthTimerMessage(ManipulationType manipulationType, string value)
        {
            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[value].EntitySlot];

            EnemyHealthTimer.Elapsed += (sender, obj) =>
            {
                memoryProcessor.UpdateEntitySlotMemory(new MemoryObject
                {
                    Address = entitySlot.Health,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                }, true);
            };

            EnemyHealthTimer.Start();

            return true;
        }

        public static bool SendBossDeactivateHealthTimerMessage(ManipulationType manipulationType, string value)
        {
            EnemyHealthTimer.Stop();
            EnemyHealthTimer.Stop();

            return true;
        }

        public static bool SendBossActivateStrengthTimerMessage(ManipulationType manipulationType, string value)
        {
            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[value].EntitySlot];

            EnemyStrengthTimer.Elapsed += (sender, obj) =>
            {
                memoryProcessor.UpdateEntitySlotMemory(new MemoryObject
                {
                    Address = entitySlot.Strength,
                    Type = DataType.TwoBytes,
                    ManipulationType = manipulationType,
                    Value = "5"
                }, false);
            };

            EnemyStrengthTimer.Start();

            return true;
        }

        public static bool SendBossDeactivateStrengthTimerMessage(ManipulationType manipulationType, string value)
        {
            EnemyStrengthTimer.Stop();
            EnemyStrengthTimer.Stop();

            return true;
        }

        public static bool SendBossActivateDefenseTimerMessage(ManipulationType manipulationType, string value)
        {
            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[value].EntitySlot];

            EnemyDefenseTimer.Elapsed += (sender, obj) =>
            {
                memoryProcessor.UpdateEntitySlotMemory(new MemoryObject
                {
                    Address = entitySlot.Defense,
                    Type = DataType.TwoBytes,
                    ManipulationType = manipulationType,
                    Value = "5"
                }, false);
            };

            EnemyDefenseTimer.Start();

            return true;
        }

        public static bool SendBossDeactivateDefenseTimerMessage(ManipulationType manipulationType, string value)
        {
            EnemyDefenseTimer.Stop();
            EnemyDefenseTimer.Stop();

            return true;
        }

        #endregion Timers

        #region Set Changes

        public static bool SendBossMaxHealthChangeMessage(ManipulationType manipulationType, string value)
        {
            var change = value.Split(':')[0];
            var changeValue = value.Split(':')[1];

            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[change].EntitySlot];

            var maxHealth = 0;
            switch (changeValue)
            {
                case "Max":
                    maxHealth = 3400;
                    break;
                case "Half":
                    maxHealth = 1700;
                    break;
                case "One":
                    maxHealth = 1;
                    break;
                default:
                    break;
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = entitySlot.MaxHealth,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = maxHealth.ToString()
            });
        }

        public static bool SendBossHealthChangeMessage(ManipulationType manipulationType, string value)
        {
            var change = value.Split(':')[0];
            var changeValue = value.Split(':')[1];

            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[change].EntitySlot];

            var health = 0;
            switch(changeValue)
            {
                case "Max":
                    health = 3400;
                    break;
                case "Half":
                    health = 1700;
                    break;
                case "One":
                    health = 1;
                    break;
                default:
                    break;
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = entitySlot.Health,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = health.ToString()
            });
        }

        public static bool SendBossStrengthChangeMessage(ManipulationType manipulationType, string value)
        {
            var change = value.Split(':')[0];
            var changeValue = value.Split(':')[1];

            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[change].EntitySlot];

            var strength = 0;
            switch (changeValue)
            {
                case "Max":
                    strength = 255;
                    break;
                case "Half":
                    strength = 122;
                    break;
                case "Zero":
                    strength = 0;
                    break;
                default:
                    break;
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = entitySlot.Strength,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = strength.ToString()
            });
        }

        public static bool SendBossDefenseChangeMessage(ManipulationType manipulationType, string value)
        {
            var change = value.Split(':')[0];
            var changeValue = value.Split(':')[1];

            var entitySlot = EntitySlotMappings.EntitySlots[EnemyMappings.Enemies[change].EntitySlot];

            var defense = 0;
            switch (changeValue)
            {
                case "Max":
                    defense = 255;
                    break;
                case "Half":
                    defense = 122;
                    break;
                case "Zero":
                    defense = 0;
                    break;
                default:
                    break;
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = entitySlot.Defense,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = defense.ToString()
            });
        }

        #endregion Set Changes

        #endregion Enemy
    }
}