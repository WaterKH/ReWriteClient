using ReWriteClient.Data;
using ReWriteClient.Enums;
using System;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        public static Timer SoraStrengthStatTimer = new Timer
        {
            AutoReset = true,
            Interval = 1000
        };

        public static Timer SoraMagicStatTimer = new Timer
        {
            AutoReset = true,
            Interval = 1000
        };

        public static Timer SoraDefenseStatTimer = new Timer
        {
            AutoReset = true,
            Interval = 1000
        };

        public static Timer SoraHealthTimer = new Timer
        {
            AutoReset = true,
            Interval = 2000
        };

        public static Timer SoraMagicTimer = new Timer
        {
            AutoReset = true,
            Interval = 2000
        };

        public static Timer SoraMagicCostTimer = new Timer
        {
            AutoReset = true,
            Interval = 5000
        };

        #region Stats

        public static bool SendSoraLevelMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraLevel = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E02F,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraCurrentHPMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraCurrentHP = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C750,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMaxHPMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraMaxHP = value;

            if (value == "0")
            {
                return SendSoraInvulnerabilityMessage(ManipulationType.Set, "true");
            }
            else
            {
                SendSoraInvulnerabilityMessage(ManipulationType.Set, "false");

                return memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x21C6C754,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = value
                });
            }
        }

        public static bool SendSoraInvulnerabilityMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.IsSoraInvincible = value == "true";

            if (value == "true")
            {
                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x200F7000,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "2357329924"
                });

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x200F7004,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "134646046"
                });

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x200F7008,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "2894200832"
                });

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x201666F8,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "201586688"
                });

                return true;
            }
            else
            {
                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x200F7000,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "0"
                });

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x200F7004,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "0"
                });

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x200F7008,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "0"
                });

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = 0x201666F8,
                    Type = DataType.FourBytes,
                    ManipulationType = manipulationType,
                    Value = "820510719"
                });

                return true;
            }
        }

        public static bool SendSoraHealthTimerMessage(ManipulationType manipulationType, string value)
        {
            if (value == "Off")
            {
                SoraHealthTimer.Stop();
                SoraHealthTimer.Dispose();
            }
            else
            {

                SoraHealthTimer.Elapsed += (sender, obj) =>
                {
                    memoryProcessor.UpdateSoraMemory(new MemoryObject
                    {
                        Address = 0x21C6C750,
                        Type = DataType.FourBytes,
                        ManipulationType = manipulationType,
                    });
                };

                SoraHealthTimer.Start();
            }

            return true;
        }

        public static bool SendSoraCurrentMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraCurrentMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C8D0,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMaxMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraMaxMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C8D4,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMagicTimerMessage(ManipulationType manipulationType, string value)
        {
            if (value == "Off")
            {
                SoraMagicTimer.Stop();
                SoraMagicTimer.Dispose();
            }
            else
            {
                SoraMagicTimer.Elapsed += (sender, obj) =>
                {
                    memoryProcessor.UpdateSoraMemory(new MemoryObject
                    {
                        Address = 0x21C6C8D0,
                        Type = DataType.FourBytes,
                        ManipulationType = manipulationType,
                    });
                };

                SoraMagicTimer.Start();
            }

            return true;
        }

        public static bool SendSoraStrengthStatMessage(ManipulationType manipulationType, string value)
        {
            if (value == "1")
            {
                SoraStrengthStatTimer.Stop();
                SoraStrengthStatTimer.Dispose();
            }
            else
            {
                SoraStrengthStatTimer.Elapsed += (sender, obj) =>
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21C6C8D8,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = value
                    });
                };

                SoraStrengthStatTimer.Start();
            }

            return true;
        }

        public static bool SendSoraMagicStatMessage(ManipulationType manipulationType, string value)
        {
            if (value == "1")
            {
                SoraMagicStatTimer.Stop();
                SoraMagicStatTimer.Dispose();
            }
            else
            {
                SoraMagicStatTimer.Elapsed += (sender, obj) =>
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21C6C8DA,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = value
                    });
                };

                SoraMagicStatTimer.Start();
            }

            return true;
        }

        public static bool SendSoraDefenseStatMessage(ManipulationType manipulationType, string value)
        {
            if (value == "1")
            {
                SoraDefenseStatTimer.Stop();
                SoraDefenseStatTimer.Dispose();
            }
            else
            {
                SoraDefenseStatTimer.Elapsed += (sender, obj) =>
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21C6C8DC,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = value
                    });
                };

                SoraDefenseStatTimer.Start();
            }

            return true;
        }

        public static bool SendSoraAPBoostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraAPBoost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E028,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraStrengthBoostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraStrengthBoost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E029,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraMagicBoostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraMagicBoost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E02A,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraDefenseBoostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraDefenseBoost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E02B,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraSpeedMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraSpeed = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CE2FE4,
                Type = DataType.FourBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Stats

        #region Magic

        public static bool SendSoraRechargeMagicMessage(ManipulationType manipulationType, string value)
        {
            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21C6C90C,
                Type = DataType.Float,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendFireMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraFireMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C4,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBlizzardMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraBlizzardMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C5,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendThunderMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraThunderMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C6,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCureMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraCureMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0C7,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendMagnetMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraMagnetMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F0FF,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendReflectMagicMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraReflectMagic = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F100,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #region Cost

        #region Spells

        public static bool SendRandomizeMagicCostMessage(ManipulationType manipulationType, string value)
        {
            if (value == "Off")
            {
                SoraMagicCostTimer.Stop();
                SoraMagicCostTimer.Dispose();
            }
            else
            {
                var random = new Random();

                SoraMagicCostTimer.Elapsed += (sender, obj) =>
                {
                    SendFireMagicCostMessage(manipulationType, random.Next(0, 256).ToString());
                    SendBlizzardMagicCostMessage(manipulationType, random.Next(0, 256).ToString());
                    SendThunderMagicCostMessage(manipulationType, random.Next(0, 256).ToString());
                    SendCureMagicCostMessage(manipulationType, random.Next(0, 256).ToString());
                    SendMagnetMagicCostMessage(manipulationType, random.Next(0, 256).ToString());
                    SendReflectMagicCostMessage(manipulationType, random.Next(0, 256).ToString());
                };

                SoraMagicCostTimer.Start();
            }

            return true;
        }

        public static bool SendFireMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraFireMagicCost = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCBCE0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC8E0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC910,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            return true;
        }

        public static bool SendBlizzardMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraBlizzardMagicCost = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCBD40,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC940,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC970,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            return true;
        }

        public static bool SendThunderMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraThunderMagicCost = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCBD10,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC9A0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC9D0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            return true;
        }

        public static bool SendCureMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraCureMagicCost = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCBD70,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCCA00,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCCA30,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            return true;
        }

        public static bool SendMagnetMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraMagnetMagicCost = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCD240,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCD270,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCD2A0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            return true;
        }

        public static bool SendReflectMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraReflectMagicCost = value;

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCD2D0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCD300,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCD330,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });

            return true;
        }

        #endregion Spells

        #region Limits

        public static bool SendTrinityLimitMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TrinityLimitMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CD0B40,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDuckFlareMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DuckFlareMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCF160,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendCometMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.CometMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCE620,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendWhirliGoofMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.WhirliGoofMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCE110,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendKnocksmashMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.KnocksmashMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCF040,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRedRocketMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RedRocketMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCCC40,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }


        public static bool SendTwinHowlMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.TwinHowlMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC130,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBushidoMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BushidoMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCC2B0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendBluffMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.BluffMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCF3A0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendDanceCallMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.DanceCallMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCFCA0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSpeedsterMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SpeedsterMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCF280,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendWildcatMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.WildcatMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCF730,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSetupMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SetupMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CCFE80,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSessionMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SessionMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CD1AD0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Limits

        #region Limit Form

        public static bool SendStrikeRaidMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.StrikeRaidMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CD3150,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSonicBladeMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SonicBladeMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CD3030,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendRagnarokMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.RagnarokMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CD2F10,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendArsArcanumMagicCostMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.ArsArcanumMagicCost = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x21CD30C0,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Limit Form

        #endregion Cost

        #endregion Magic

        #region Equipment

        public static bool SendEquipKeybladeMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraKeyblade = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E020,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendEquipValorKeybladeMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraValorKeyblade = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EE24,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendEquipMasterKeybladeMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraMasterKeyblade = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EECC,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendEquipFinalKeybladeMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraFinalKeyblade = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032EF04,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Equipment

        #region Armor

        public static bool SendSoraArmorSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraArmorSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E030,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraArmorSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E034,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraArmorSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E036,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraArmorSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E038,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraArmorSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraArmorSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E03A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Armor

        #region Accessory

        public static bool SendSoraAccessorySlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraAccessorySlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E031,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraAccessorySlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E044,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraAccessorySlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E046,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraAccessorySlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E048,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraAccessorySlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraAccessorySlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E04A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Accessory

        #region Items

        public static bool SendSoraItemSlotsMessage(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlots = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E032,
                Type = DataType.Byte,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot1 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E054,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot2 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E056,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot3 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E058,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot4 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E05A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot5Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot5 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E05C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot6Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot6 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E05E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot7Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot7 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E060,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraItemSlot8Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraItemSlot8 = value;

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032E062,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Items

        #region Quick Menu

        public static bool SendSoraQuickMenuSlot1Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraQuickMenuSlot1 = value;

            if (Conversions.QuickMenuToItem.TryGetValue(value, out var convertedValue))
            {
                SendSoraItemSlot1Message(ManipulationType.Set, convertedValue);
            }
            else if (Conversions.QuickMenuToMagicAddress.TryGetValue(value, out var convertedMagicValue))
            {
                if (memoryProcessor.GetMemory(convertedMagicValue, 1) == 0)
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = convertedMagicValue,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = "1"
                    });
                }
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F228,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraQuickMenuSlot2Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraQuickMenuSlot2 = value;

            if (Conversions.QuickMenuToItem.TryGetValue(value, out var convertedValue))
            {
                SendSoraItemSlot2Message(ManipulationType.Set, convertedValue);
            }
            else if (Conversions.QuickMenuToMagicAddress.TryGetValue(value, out var convertedMagicValue))
            {
                if (memoryProcessor.GetMemory(convertedMagicValue, 1) == 0)
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = convertedMagicValue,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = "1"
                    });
                }
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F22A,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraQuickMenuSlot3Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraQuickMenuSlot3 = value;

            if (Conversions.QuickMenuToItem.TryGetValue(value, out var convertedValue))
            {
                SendSoraItemSlot3Message(ManipulationType.Set, convertedValue);
            }
            else if (Conversions.QuickMenuToMagicAddress.TryGetValue(value, out var convertedMagicValue))
            {
                if (memoryProcessor.GetMemory(convertedMagicValue, 1) == 0)
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = convertedMagicValue,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = "1"
                    });
                }
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F22C,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        public static bool SendSoraQuickMenuSlot4Message(ManipulationType manipulationType, string value)
        {
            ClientCache.Instance.SoraQuickMenuSlot4 = value;

            if (Conversions.QuickMenuToItem.TryGetValue(value, out var convertedValue))
            {
                SendSoraItemSlot4Message(ManipulationType.Set, convertedValue);
            }
            else if (Conversions.QuickMenuToMagicAddress.TryGetValue(value, out var convertedMagicValue))
            {
                if (memoryProcessor.GetMemory(convertedMagicValue, 1) == 0)
                {
                    memoryProcessor.UpdateMemory(new MemoryObject
                    {
                        Address = convertedMagicValue,
                        Type = DataType.Byte,
                        ManipulationType = manipulationType,
                        Value = "1"
                    });
                }
            }

            return memoryProcessor.UpdateMemory(new MemoryObject
            {
                Address = 0x2032F22E,
                Type = DataType.TwoBytes,
                ManipulationType = manipulationType,
                Value = value
            });
        }

        #endregion Quick Menu

        #region Abilities

        public static bool SendSoraActivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.SoraAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E074, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            if(memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue, 148)) // Add Ability map to account for how max/ toggleValue are assigned
            {
                ClientCache.Instance.SoraAbilities.Add(value);
            }

            return true;
        }

        public static bool SendSoraDeactivateAbilityMessage(ManipulationType manipulationType, string value)
        {
            var ability = AbilityMappings.SoraAbilities[value];

            var memoryObject = new MemoryObject { Address = 0x2032E074, Type = DataType.Byte, ManipulationType = manipulationType, Value = ability.Value.ToString(), IsValueHex = true };

            if(memoryProcessor.UpdateAbilityMemory(memoryObject, ability.MaxNumber, ability.ToggleValue - 128, 148)) // Add Ability map to account for how max/ toggleValue are assigned
            {
                ClientCache.Instance.SoraAbilities.Remove(value);
            }

            return true;
        }

        #endregion Abilities
    }
}