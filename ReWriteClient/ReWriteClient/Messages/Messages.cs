using ReWriteClient.Data;
using ReWriteClient.Enums;
using ReWriteClient.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Waterkh.Common.Mappings;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        private static readonly MemoryProcessor memoryProcessor = MemoryProcessor.Instance;

        private static Messages instance;
        public static Messages Instance { get; set; } = instance ?? new Messages();

        #region Potential Values

        private List<string> MessageParams0to99 = new List<string> { "0", "99" };
        private List<string> MessageParams0to255 = new List<string> { "0", "255" };
        private List<string> MessageParams0to1 = new List<string> { "0", "1" };
        private List<string> MessageParams0to2 = new List<string> { "0", "2" };
        private List<string> MessageParams0to3 = new List<string> { "0", "3" }; 
        private List<string> MessageParams0to4 = new List<string> { "0", "4" };
        private List<string> MessageParams0to5 = new List<string> { "0", "5" };
        private List<string> MessageParams0to6 = new List<string> { "0", "6" };
        private List<string> MessageParams0to8 = new List<string> { "0", "8" };
        private List<string> MessageParams0to999999 = new List<string> { "0", "999999" };

        private List<string> MessageParamsOnOff = new List<string> { "Off", "On", "Off", "On" };
        private List<string> MessageParamsSpeed = new List<string> { "1086324736", "1078984704", "1073741824", "1090519040", "1103101952", "1112539136", "1121976320" };
        private List<string> MessageParamsRechargeMagic = new List<string> { "0", "3000" };
        private List<string> MessageParamsDriveTime = new List<string> { "0", "5000" };
        private List<string> MessageParamsDrives = new List<string> { "0", "2", "4", "6", "16", "18", "20", "22", "32", "34", "36", "38", "48", "50", "52", "54", "64", "66", "68", "70", "80", "82", "84", "86", "96", "98", "100", "102", "112", "114", "116", "118" };
        //private List<string> MessageParamsDrives = new List<string> { "2", "4", "16", "32", "64" };
        private List<string> MessageParamsLimitDrive = new List<string> { "0", "0", "8", "8" };
        private List<string> MessageParamsAllDrive = new List<string> { "0", "0", "118", "118" };
        private List<string> MessageParamsActivateDrive = new List<string> { "0", "6", "7", "11", "12", "13", "673" };
        private List<string> MessageParamsSummons = new List<string> { "1", "8", "16", "32" };
        private List<string> MessageParamsKeyblades = new List<string> { "41", "42", "43", "44", "45", "480", "481", "484", "485", "486", "487", "488", "489", "490", "491", "492", "493", "494", "495", "496", "498", "543", "497", "499", "500", "544" };
        private List<string> MessageParamsArmor = new List<string> { "0", "67", "68", "69", "70", "305", "78", "79", "111", "173", "174", "197", "284", "286", "287", "288", "289", "291", "292", "293", "294", "296", "297", "298", "299", "301", "302", "303", "307", "308", "132", "133", "306", "304", "157" };
        private List<string> MessageParamsAccessories = new List<string> { "0", "8", "9", "10", "11", "34", "599", "38", "39", "52", "12", "13", "14", "15", "16", "17", "18", "19", "20", "28", "40", "46", "47", "48", "53", "35", "36", "56", "57", "58", "64", "66", "64", "63" };
        private List<string> MessageParamsItems = new List<string> { "0", "7" };
        private List<string> MessageParamsQuickMenus = new List<string> { "0", "49", "51", "50", "52", "174", "177", "23", "20", "21", "22", "242", "243", "244" };
        
        private List<string> MessageParamsSoraModels = new List<string> { "54", "6C1", "601", "602", "28A", "5A", "323", "5B", "318", "5C", "5D", "5EF", "61B", "64", "63", "65", "62", "66", "5F", "60", "61", "2D4", "55", "56", "95D", "57", "58", "59" };
        private List<string> MessageParamsPartyModels = new List<string> { /*"RandomAlly", "RandomEnemy",*/ "5C", "5EF", "5D", "61B", "819", "4DC", "61C", "6B0", "6B3", "688", "5E", "64", "63", "65", "66", "5F", "60", "61", "2D4", "16A", "4BB", "8F8", "8FB", "8FA", "8F9", "B1F", "622", "3E5", "933", "934", "935", "97B", "6C9", "51", "31B", "8F6", "5F8", "923", "962", "951", "754", "886", "96F" };
        private List<string> MessageParamsStaves = new List<string> { "75", "148", "149", "151", "152", "153", "150", "154", "155", "156", "600", "482", "503", "545", "546", "547", "548", "549", "550", "551", "161" };
        private List<string> MessageParamsShields = new List<string> { "49", "139", "140", "142", "143", "144", "141", "145", "147", "146", "601", "483", "504", "552", "553", "554", "555", "556", "557", "558", "50" };
        private List<string> MessageParamsEnemyHealth = new List<string> { "Max", "Half", "One" };


        #endregion Potential Values


        public Dictionary<string, Dictionary<string, MessageValue>> MessageMappings;

        private Messages()
        {
            MessageParamsSoraModels.ForEach(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber).ToString());
            MessageParamsPartyModels.ForEach(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber).ToString());

            this.InitializeMessages();
        }

        private void InitializeMessages()
        {
            MessageMappings = new Dictionary<string, Dictionary<string, MessageValue>>
            {
                #region Sora
            
                { "Sora", new Dictionary<string, MessageValue>
                    {
                        #region Stats

                        { "SendSoraLevelMessage", new MessageValue { Method = SendSoraLevelMessage, Values = MessageParams0to99 } },
                        { "SendSoraCurrentHPMessage", new MessageValue { Method = SendSoraCurrentHPMessage, Values = MessageParams0to255 } },
                        { "SendSoraMaxHPMessage", new MessageValue { Method = SendSoraMaxHPMessage, Values = MessageParams0to255 } },
                        { "SendSoraHealthTimerMessage", new MessageValue { Method = SendSoraHealthTimerMessage, Values = MessageParamsOnOff } },
                        { "SendSoraCurrentMagicMessage", new MessageValue { Method = SendSoraCurrentMagicMessage, Values = MessageParams0to255 } },
                        { "SendSoraMaxMagicMessage", new MessageValue { Method = SendSoraMaxMagicMessage, Values = MessageParams0to255 } },
                        { "SendSoraMagicTimerMessage", new MessageValue { Method = SendSoraMagicTimerMessage, Values = MessageParamsOnOff } },
                        { "SendSoraStrengthStatMessage", new MessageValue { Method = SendSoraStrengthStatMessage, Values = MessageParams0to255 } },
                        { "SendSoraMagicStatMessage", new MessageValue { Method = SendSoraMagicStatMessage, Values = MessageParams0to255 } },
                        { "SendSoraDefenseStatMessage", new MessageValue { Method = SendSoraDefenseStatMessage, Values = MessageParams0to255 } },
                        { "SendSoraAPBoostMessage", new MessageValue { Method = SendSoraAPBoostMessage, Values = MessageParams0to99 } },
                        { "SendSoraStrengthBoostMessage", new MessageValue { Method = SendSoraStrengthBoostMessage, Values = MessageParams0to99 } },
                        { "SendSoraMagicBoostMessage", new MessageValue { Method = SendSoraMagicBoostMessage, Values = MessageParams0to99 } },
                        { "SendSoraDefenseBoostMessage", new MessageValue { Method = SendSoraDefenseBoostMessage, Values = MessageParams0to99 } },
                        { "SendSoraSpeedMessage", new MessageValue { Method = SendSoraSpeedMessage, Values = MessageParamsSpeed } },

                        #endregion Stats

                        #region Magic

                        { "SendSoraRechargeMagicMessage", new MessageValue { Method = SendSoraRechargeMagicMessage, Values = MessageParamsRechargeMagic } },
                        { "SendFireMagicMessage", new MessageValue { Method = SendFireMagicMessage, Values = MessageParams0to3 } },
                        { "SendBlizzardMagicMessage", new MessageValue { Method = SendBlizzardMagicMessage, Values = MessageParams0to3 } },
                        { "SendThunderMagicMessage", new MessageValue { Method = SendThunderMagicMessage, Values = MessageParams0to3 } },
                        { "SendCureMagicMessage", new MessageValue { Method = SendCureMagicMessage, Values = MessageParams0to3 } },
                        { "SendMagnetMagicMessage", new MessageValue { Method = SendMagnetMagicMessage, Values = MessageParams0to3 } },
                        { "SendReflectMagicMessage", new MessageValue { Method = SendReflectMagicMessage, Values = MessageParams0to3 } },

                        #region Cost

                        #region Spells

                        { "SendRandomizeMagicCostMessage", new MessageValue { Method = SendRandomizeMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendFireMagicCostMessage", new MessageValue { Method = SendFireMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendBlizzardMagicCostMessage", new MessageValue { Method = SendBlizzardMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendThunderMagicCostMessage", new MessageValue { Method = SendThunderMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendCureMagicCostMessage", new MessageValue { Method = SendCureMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendMagnetMagicCostMessage", new MessageValue { Method = SendMagnetMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendReflectMagicCostMessage", new MessageValue { Method = SendReflectMagicCostMessage, Values = MessageParams0to255 } },
                
                        #endregion Spells

                        #region Limits

                        { "SendTrinityLimitMagicCostMessage", new MessageValue { Method = SendTrinityLimitMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendDuckFlareMagicCostMessage", new MessageValue { Method = SendDuckFlareMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendCometMagicCostMessage", new MessageValue { Method = SendCometMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendWhirliGoofMagicCostMessage", new MessageValue { Method = SendWhirliGoofMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendKnocksmashMagicCostMessage", new MessageValue { Method = SendKnocksmashMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendRedRocketMagicCostMessage", new MessageValue { Method = SendRedRocketMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendTwinHowlMagicCostMessage", new MessageValue { Method = SendTwinHowlMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendBushidoMagicCostMessage", new MessageValue { Method = SendBushidoMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendBluffMagicCostMessage", new MessageValue { Method = SendBluffMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendDanceCallMagicCostMessage", new MessageValue { Method = SendDanceCallMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendSpeedsterMagicCostMessage", new MessageValue { Method = SendSpeedsterMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendWildcatMagicCostMessage", new MessageValue { Method = SendWildcatMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendSetupMagicCostMessage", new MessageValue { Method = SendSetupMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendSessionMagicCostMessage", new MessageValue { Method = SendSessionMagicCostMessage, Values = MessageParams0to255 } },

                        #endregion Limits

                        #region Limit Form
                    
                        { "SendStrikeRaidCostMessage", new MessageValue { Method = SendStrikeRaidMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendSonicBladeMagicCostMessage", new MessageValue { Method = SendSonicBladeMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendRagnarokMagicCostMessage", new MessageValue { Method = SendRagnarokMagicCostMessage, Values = MessageParams0to255 } },
                        { "SendArsArcanumMagicCostMessage", new MessageValue { Method = SendArsArcanumMagicCostMessage, Values = MessageParams0to255 } },

                        #endregion Limit Form

                        #endregion Cost

                        #endregion Magic

                        #region Drive

                        { "SendCurrentDriveCounterMessage", new MessageValue { Method = SendCurrentDriveCounterMessage, Values = MessageParams0to255 } },
                        { "SendMaxDriveCounterMessage", new MessageValue { Method = SendMaxDriveCounterMessage, Values = MessageParams0to255 } },
                        { "SendDriveTimeMessage", new MessageValue { Method = SendMaxDriveCounterMessage, Values = MessageParamsDriveTime } },
                        { "SendDisableDriveMessage", new MessageValue { Method = SendDisableDriveMessage, Values = MessageParams0to1 } },
                        { "SendValorWisdomMasterFinalAntiMessage", new MessageValue { Method = SendValorWisdomMasterFinalAntiMessage, Values = MessageParamsDrives } },
                        { "SendLimitMessage", new MessageValue { Method = SendLimitMessage, Values = MessageParamsLimitDrive } },
                        { "SendAllDriveFormsMessage", new MessageValue { Method = SendAllDriveFormsMessage, Values = MessageParamsAllDrive } },
                        { "SendActivateFormMessage", new MessageValue { Method = SendActivateFormMessage, Values = MessageParamsActivateDrive } },

                        #endregion Drive

                        #region Summon
                    
                        { "SendUkuleleBaseballMessage", new MessageValue { Method = SendUkuleleBaseballMessage, Values = MessageParamsSummons } },
                        { "SendLampFeatherMessage", new MessageValue { Method = SendLampFeatherMessage, Values = MessageParamsSummons } },

                        #endregion Summon

                        #region Equipment
            
                        { "SendEquipKeybladeMessage", new MessageValue { Method = SendEquipKeybladeMessage, Values = MessageParamsKeyblades } },
                        { "SendEquipValorKeybladeMessage", new MessageValue { Method = SendEquipValorKeybladeMessage, Values = MessageParamsKeyblades } },
                        { "SendEquipMasterKeybladeMessage", new MessageValue { Method = SendEquipMasterKeybladeMessage, Values = MessageParamsKeyblades } },
                        { "SendEquipFinalKeybladeMessage", new MessageValue { Method = SendEquipFinalKeybladeMessage, Values = MessageParamsKeyblades } },

                        #endregion Equipment

                        #region Armor

                        { "SendSoraArmorSlotsMessage", new MessageValue { Method = SendSoraArmorSlotsMessage, Values = MessageParams0to4 } },
                        { "SendSoraArmorSlot1Message", new MessageValue { Method = SendSoraArmorSlot1Message, Values = MessageParamsArmor } },
                        { "SendSoraArmorSlot2Message", new MessageValue { Method = SendSoraArmorSlot2Message, Values = MessageParamsArmor } },
                        { "SendSoraArmorSlot3Message", new MessageValue { Method = SendSoraArmorSlot3Message, Values = MessageParamsArmor } },
                        { "SendSoraArmorSlot4Message", new MessageValue { Method = SendSoraArmorSlot4Message, Values = MessageParamsArmor } },

                        #endregion Armor

                        #region Accessories

                        { "SendSoraAccessorySlotsMessage", new MessageValue { Method = SendSoraAccessorySlotsMessage, Values = MessageParams0to4 } },
                        { "SendSoraAccessorySlot1Message", new MessageValue { Method = SendSoraAccessorySlot1Message, Values = MessageParamsAccessories } },
                        { "SendSoraAccessorySlot2Message", new MessageValue { Method = SendSoraAccessorySlot2Message, Values = MessageParamsAccessories } },
                        { "SendSoraAccessorySlot3Message", new MessageValue { Method = SendSoraAccessorySlot3Message, Values = MessageParamsAccessories } },
                        { "SendSoraAccessorySlot4Message", new MessageValue { Method = SendSoraAccessorySlot4Message, Values = MessageParamsAccessories } },

                        #endregion Accessories

                        #region Items

                        { "SendSoraItemSlotsMessage", new MessageValue { Method = SendSoraItemSlotsMessage, Values = MessageParams0to8 } },
                        { "SendSoraItemSlot1Message", new MessageValue { Method = SendSoraItemSlot1Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot2Message", new MessageValue { Method = SendSoraItemSlot2Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot3Message", new MessageValue { Method = SendSoraItemSlot3Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot4Message", new MessageValue { Method = SendSoraItemSlot4Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot5Message", new MessageValue { Method = SendSoraItemSlot5Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot6Message", new MessageValue { Method = SendSoraItemSlot6Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot7Message", new MessageValue { Method = SendSoraItemSlot7Message, Values = MessageParamsItems } },
                        { "SendSoraItemSlot8Message", new MessageValue { Method = SendSoraItemSlot8Message, Values = MessageParamsItems } },

                        #endregion Items

                        #region Quick Menu

                        { "SendSoraQuickMenuSlot1Message", new MessageValue { Method = SendSoraQuickMenuSlot1Message, Values = MessageParamsQuickMenus } },
                        { "SendSoraQuickMenuSlot2Message", new MessageValue { Method = SendSoraQuickMenuSlot2Message, Values = MessageParamsQuickMenus } },
                        { "SendSoraQuickMenuSlot3Message", new MessageValue { Method = SendSoraQuickMenuSlot3Message, Values = MessageParamsQuickMenus } },
                        { "SendSoraQuickMenuSlot4Message", new MessageValue { Method = SendSoraQuickMenuSlot4Message, Values = MessageParamsQuickMenus } },

                        #endregion Quick Menu

                        #region Abilities
                        
                        { "SendSoraActivateAbilityMessage", new MessageValue { Method = SendSoraActivateAbilityMessage, Values = AbilityMapping.SoraAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendSoraDeactivateAbilityMessage", new MessageValue { Method = SendSoraDeactivateAbilityMessage, Values = AbilityMapping.SoraAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Abilities

                    }
                },

                #endregion Sora

                #region Items
            
                { "Items", new Dictionary<string, MessageValue>
                    {
                        #region Base Items

                        { "SendPotionMessage", new MessageValue { Method = SendPotionMessage, Values = MessageParams0to99 } },
                        { "SendHiPotionMessage", new MessageValue { Method = SendHiPotionMessage, Values = MessageParams0to99 } },
                        { "SendEtherMessage", new MessageValue { Method = SendEtherMessage, Values = MessageParams0to99 } },
                        { "SendElixirMessage", new MessageValue { Method = SendElixirMessage, Values = MessageParams0to99 } },
                        { "SendMegaPotionMessage", new MessageValue { Method = SendMegaPotionMessage, Values = MessageParams0to99 } },
                        { "SendMegaEtherMessage", new MessageValue { Method = SendMegaEtherMessage, Values = MessageParams0to99 } },
                        { "SendMegaElixirMessage", new MessageValue { Method = SendMegaElixirMessage, Values = MessageParams0to99 } },
                        { "SendTentMessage", new MessageValue { Method = SendTentMessage, Values = MessageParams0to99 } },
                        { "SendDriveRecoveryMessage", new MessageValue { Method = SendDriveRecoveryMessage, Values = MessageParams0to99 } },
                        { "SendHighDriveRecoveryMessage", new MessageValue { Method = SendHighDriveRecoveryMessage, Values = MessageParams0to99 } },
                        { "SendPowerBoostMessage", new MessageValue { Method = SendPowerBoostMessage, Values = MessageParams0to99 } },
                        { "SendMagicBoostMessage", new MessageValue { Method = SendMagicBoostMessage, Values = MessageParams0to99 } },
                        { "SendDefenseBoostMessage", new MessageValue { Method = SendDefenseBoostMessage, Values = MessageParams0to99 } },
                        { "SendAPBoostMessage", new MessageValue { Method = SendAPBoostMessage, Values = MessageParams0to99 } },

                        #endregion Base Items

                        #region Weapons

                        #region Sora

                        { "SendKingdomKeyMessage", new MessageValue { Method = SendKingdomKeyMessage, Values = MessageParams0to1 } },
                        { "SendOathkeeperMessage", new MessageValue { Method = SendOathkeeperMessage, Values = MessageParams0to1 } },
                        { "SendOblivionMessage", new MessageValue { Method = SendOblivionMessage, Values = MessageParams0to1 } },
                        { "SendStarSeekerMessage", new MessageValue { Method = SendStarSeekerMessage, Values = MessageParams0to1 } },
                        { "SendHiddenDragonMessage", new MessageValue { Method = SendHiddenDragonMessage, Values = MessageParams0to1 } },
                        { "SendHerosCrestMessage", new MessageValue { Method = SendHerosCrestMessage, Values = MessageParams0to1 } },
                        { "SendMonochromeMessage", new MessageValue { Method = SendMonochromeMessage, Values = MessageParams0to1 } },
                        { "SendFollowTheWindMessage", new MessageValue { Method = SendFollowTheWindMessage, Values = MessageParams0to1 } },
                        { "SendCircleOfLifeMessage", new MessageValue { Method = SendCircleOfLifeMessage, Values = MessageParams0to1 } },
                        { "SendPhotonDebuggerMessage", new MessageValue { Method = SendPhotonDebuggerMessage, Values = MessageParams0to1 } },
                        { "SendGullWingMessage", new MessageValue { Method = SendGullWingMessage, Values = MessageParams0to1 } },
                        { "SendRumblingRoseMessage", new MessageValue { Method = SendRumblingRoseMessage, Values = MessageParams0to1 } },
                        { "SendGuardianSoulMessage", new MessageValue { Method = SendGuardianSoulMessage, Values = MessageParams0to1 } },
                        { "SendWishingLampMessage", new MessageValue { Method = SendWishingLampMessage, Values = MessageParams0to1 } },
                        { "SendDecisivePumpkinMessage", new MessageValue { Method = SendDecisivePumpkinMessage, Values = MessageParams0to1 } },
                        { "SendSleepingLionMessage", new MessageValue { Method = SendSleepingLionMessage, Values = MessageParams0to1 } },
                        { "SendSweetMemoriesMessage", new MessageValue { Method = SendSweetMemoriesMessage, Values = MessageParams0to1 } },
                        { "SendMysteriousAbyssMessage", new MessageValue { Method = SendMysteriousAbyssMessage, Values = MessageParams0to1 } },
                        { "SendBondOfFlameMessage", new MessageValue { Method = SendBondOfFlameMessage, Values = MessageParams0to1 } },
                        { "SendFatalCrestMessage", new MessageValue { Method = SendFatalCrestMessage, Values = MessageParams0to1 } },
                        { "SendFenrirMessage", new MessageValue { Method = SendFenrirMessage, Values = MessageParams0to1 } },
                        { "SendUltimaWeaponMessage", new MessageValue { Method = SendUltimaWeaponMessage, Values = MessageParams0to1 } },
                        { "SendTwoBecomeOneMessage", new MessageValue { Method = SendTwoBecomeOneMessage, Values = MessageParams0to1 } },
                        { "SendWinnersProofMessage", new MessageValue { Method = SendWinnersProofMessage, Values = MessageParams0to1 } },
                        { "SendFrontierOfUltimaMessage", new MessageValue { Method = SendFrontierOfUltimaMessage, Values = MessageParams0to1 } },
                        { "SendDetectionSaberMessage", new MessageValue { Method = SendDetectionSaberMessage, Values = MessageParams0to1 } },

                        #endregion Sora

                        #region Donald

                        { "SendMagesStaffMessage", new MessageValue { Method = SendMagesStaffMessage, Values = MessageParams0to1 } },
                        { "SendHammerStaffMessage", new MessageValue { Method = SendHammerStaffMessage, Values = MessageParams0to1 } },
                        { "SendVictoryBellMessage", new MessageValue { Method = SendVictoryBellMessage, Values = MessageParams0to1 } },
                        { "SendMeteorStaffMessage", new MessageValue { Method = SendMeteorStaffMessage, Values = MessageParams0to1 } },
                        { "SendCometStaffMessage", new MessageValue { Method = SendCometStaffMessage, Values = MessageParams0to1 } },
                        { "SendLordsBroomMessage", new MessageValue { Method = SendLordsBroomMessage, Values = MessageParams0to1 } },
                        { "SendWisdomWandMessage", new MessageValue { Method = SendWisdomWandMessage, Values = MessageParams0to1 } },
                        { "SendRisingDragonMessage", new MessageValue { Method = SendRisingDragonMessage, Values = MessageParams0to1 } },
                        { "SendNobodyLanceMessage", new MessageValue { Method = SendNobodyLanceMessage, Values = MessageParams0to1 } },
                        { "SendShamansRelicMessage", new MessageValue { Method = SendShamansRelicMessage, Values = MessageParams0to1 } },
                        { "SendShamansRelicPlusMessage", new MessageValue { Method = SendShamansRelicPlusMessage, Values = MessageParams0to1 } },
                        { "SendSaveTheQueenMessage", new MessageValue { Method = SendSaveTheQueenMessage, Values = MessageParams0to1 } },
                        { "SendSaveTheQueenPlusMessage", new MessageValue { Method = SendSaveTheQueenPlusMessage, Values = MessageParams0to1 } },
                        { "SendCenturionMessage", new MessageValue { Method = SendCenturionMessage, Values = MessageParams0to1 } },
                        { "SendCenturionPlusMessage", new MessageValue { Method = SendCenturionPlusMessage, Values = MessageParams0to1 } },
                        { "SendPlainMushroomMessage", new MessageValue { Method = SendPlainMushroomMessage, Values = MessageParams0to1 } },
                        { "SendPlainMushroomPlusMessage", new MessageValue { Method = SendPlainMushroomPlusMessage, Values = MessageParams0to1 } },
                        { "SendPreciousMushroomMessage", new MessageValue { Method = SendPreciousMushroomMessage, Values = MessageParams0to1 } },
                        { "SendPreciousMushroomPlusMessage", new MessageValue { Method = SendPreciousMushroomPlusMessage, Values = MessageParams0to1 } },
                        { "SendPremiumMushroomMessage", new MessageValue { Method = SendPremiumMushroomMessage, Values = MessageParams0to1 } },
                        { "SendStaffOfDetectionMessage", new MessageValue { Method = SendStaffOfDetectionMessage, Values = MessageParams0to1 } },

                        #endregion Donald

                        #region Goofy

                        { "SendKnightsShieldMessage", new MessageValue { Method = SendKnightsShieldMessage, Values = MessageParams0to1 } },
                        { "SendAdamantShieldMessage", new MessageValue { Method = SendAdamantShieldMessage, Values = MessageParams0to1 } },
                        { "SendChainGearMessage", new MessageValue { Method = SendChainGearMessage, Values = MessageParams0to1 } },
                        { "SendOgreShieldMessage", new MessageValue { Method = SendOgreShieldMessage, Values = MessageParams0to1 } },
                        { "SendFallingStarMessage", new MessageValue { Method = SendFallingStarMessage, Values = MessageParams0to1 } },
                        { "SendDreamcloudMessage", new MessageValue { Method = SendDreamcloudMessage, Values = MessageParams0to1 } },
                        { "SendKnightDefenderMessage", new MessageValue { Method = SendKnightDefenderMessage, Values = MessageParams0to1 } },
                        { "SendGenjiShieldMessage", new MessageValue { Method = SendGenjiShieldMessage, Values = MessageParams0to1 } },
                        { "SendAkashicRecordMessage", new MessageValue { Method = SendAkashicRecordMessage, Values = MessageParams0to1 } },
                        { "SendAkashicRecordPlusMessage", new MessageValue { Method = SendAkashicRecordPlusMessage, Values = MessageParams0to1 } },
                        { "SendNobodyGuardMessage", new MessageValue { Method = SendNobodyGuardMessage, Values = MessageParams0to1 } },
                        { "SendSaveTheKingMessage", new MessageValue { Method = SendSaveTheKingMessage, Values = MessageParams0to1 } },
                        { "SendSaveTheKingPlusMessage", new MessageValue { Method = SendSaveTheKingPlusMessage, Values = MessageParams0to1 } },
                        { "SendFrozenPrideMessage", new MessageValue { Method = SendFrozenPrideMessage, Values = MessageParams0to1 } },
                        { "SendFrozenPridePlusMessage", new MessageValue { Method = SendFrozenPridePlusMessage, Values = MessageParams0to1 } },
                        { "SendJoyousMushroomMessage", new MessageValue { Method = SendJoyousMushroomMessage, Values = MessageParams0to1 } },
                        { "SendJoyousMushroomPlusMessage", new MessageValue { Method = SendJoyousMushroomPlusMessage, Values = MessageParams0to1 } },
                        { "SendMajesticMushroomMessage", new MessageValue { Method = SendMajesticMushroomMessage, Values = MessageParams0to1 } },
                        { "SendMajesticMushroomPlusMessage", new MessageValue { Method = SendMajesticMushroomPlusMessage, Values = MessageParams0to1 } },
                        { "SendUltimateMushroomMessage", new MessageValue { Method = SendUltimateMushroomMessage, Values = MessageParams0to1 } },
                        { "SendDetectionShieldMessage", new MessageValue { Method = SendDetectionShieldMessage, Values = MessageParams0to1 } },

                        #endregion Goofy

                        #endregion Weapons

                        #region Armor

                        { "SendElvenBandannaMessage", new MessageValue { Method = SendElvenBandannaMessage, Values = MessageParams0to3 } },
                        { "SendDivineBandannaMessage", new MessageValue { Method = SendDivineBandannaMessage, Values = MessageParams0to3 } },
                        { "SendPowerBandMessage", new MessageValue { Method = SendPowerBandMessage, Values = MessageParams0to3 } },
                        { "SendBusterBandMessage", new MessageValue { Method = SendBusterBandMessage, Values = MessageParams0to3 } },
                        { "SendProtectBeltMessage", new MessageValue { Method = SendProtectBeltMessage, Values = MessageParams0to3 } },
                        { "SendGaiaBeltMessage", new MessageValue { Method = SendGaiaBeltMessage, Values = MessageParams0to3 } },
                        { "SendCosmicBeltMessage", new MessageValue { Method = SendCosmicBeltMessage, Values = MessageParams0to3 } },
                        { "SendShockCharmMessage", new MessageValue { Method = SendShockCharmMessage, Values = MessageParams0to3 } },
                        { "SendShockCharmPlusMessage", new MessageValue { Method = SendShockCharmPlusMessage, Values = MessageParams0to3 } },
                        { "SendFireBangleMessage", new MessageValue { Method = SendFireBangleMessage, Values = MessageParams0to3 } },
                        { "SendFiraBangleMessage", new MessageValue { Method = SendFiraBangleMessage, Values = MessageParams0to3 } },
                        { "SendFiragaBangleMessage", new MessageValue { Method = SendFiragaBangleMessage, Values = MessageParams0to3 } },
                        { "SendFiragunBangleMessage", new MessageValue { Method = SendFiragunBangleMessage, Values = MessageParams0to3 } },
                        { "SendBlizzardArmletMessage", new MessageValue { Method = SendBlizzardArmletMessage, Values = MessageParams0to3 } },
                        { "SendBlizzaraArmletMessage", new MessageValue { Method = SendBlizzaraArmletMessage, Values = MessageParams0to3 } },
                        { "SendBlizzagaArmletMessage", new MessageValue { Method = SendBlizzagaArmletMessage, Values = MessageParams0to3 } },
                        { "SendBlizzagunArmletMessage", new MessageValue { Method = SendBlizzagunArmletMessage, Values = MessageParams0to3 } },
                        { "SendThunderTrinketMessage", new MessageValue { Method = SendThunderTrinketMessage, Values = MessageParams0to3 } },
                        { "SendThundaraTrinketMessage", new MessageValue { Method = SendThundaraTrinketMessage, Values = MessageParams0to3 } },
                        { "SendThundagaTrinketMessage", new MessageValue { Method = SendThundagaTrinketMessage, Values = MessageParams0to3 } },
                        { "SendThundagunTrinketMessage", new MessageValue { Method = SendThundagunTrinketMessage, Values = MessageParams0to3 } },
                        { "SendShadowAnkletMessage", new MessageValue { Method = SendShadowAnkletMessage, Values = MessageParams0to3 } },
                        { "SendDarkAnkletMessage", new MessageValue { Method = SendDarkAnkletMessage, Values = MessageParams0to3 } },
                        { "SendMidnightAnkletMessage", new MessageValue { Method = SendMidnightAnkletMessage, Values = MessageParams0to3 } },
                        { "SendChaosAnkletMessage", new MessageValue { Method = SendChaosAnkletMessage, Values = MessageParams0to3 } },
                        { "SendAbasChainMessage", new MessageValue { Method = SendAbasChainMessage, Values = MessageParams0to3 } },
                        { "SendAegisChainMessage", new MessageValue { Method = SendAegisChainMessage, Values = MessageParams0to3 } },
                        { "SendCosmicChainMessage", new MessageValue { Method = SendCosmicChainMessage, Values = MessageParams0to3 } },
                        { "SendAcrisiusMessage", new MessageValue { Method = SendAcrisiusMessage, Values = MessageParams0to3 } },
                        { "SendAcrisiusPlusMessage", new MessageValue { Method = SendAcrisiusPlusMessage, Values = MessageParams0to3 } },
                        { "SendPetiteRibbonMessage", new MessageValue { Method = SendPetiteRibbonMessage, Values = MessageParams0to3 } },
                        { "SendRibbonMessage", new MessageValue { Method = SendRibbonMessage, Values = MessageParams0to3 } },
                        { "SendGrandRibbonMessage", new MessageValue { Method = SendGrandRibbonMessage, Values = MessageParams0to3 } },
                        { "SendChampionBeltMessage", new MessageValue { Method = SendChampionBeltMessage, Values = MessageParams0to3 } },

                        #endregion Armor

                        #region Accessories
            
                        { "SendMedalMessage", new MessageValue { Method = SendMedalMessage, Values = MessageParams0to3 } },
                        { "SendAbilityRingMessage", new MessageValue { Method = SendAbilityRingMessage, Values = MessageParams0to3 } },
                        { "SendEngineersRingMessage", new MessageValue { Method = SendEngineersRingMessage, Values = MessageParams0to3 } },
                        { "SendTechniciansRingMessage", new MessageValue { Method = SendTechniciansRingMessage, Values = MessageParams0to3 } },
                        { "SendExpertsRingMessage", new MessageValue { Method = SendExpertsRingMessage, Values = MessageParams0to3 } },
                        { "SendExecutivesRingMessage", new MessageValue { Method = SendExecutivesRingMessage, Values = MessageParams0to3 } },
                        { "SendSardonyxRingMessage", new MessageValue { Method = SendSardonyxRingMessage, Values = MessageParams0to3 } },
                        { "SendTourmalineRingMessage", new MessageValue { Method = SendTourmalineRingMessage, Values = MessageParams0to3 } },
                        { "SendAquamarineRingMessage", new MessageValue { Method = SendAquamarineRingMessage, Values = MessageParams0to3 } },
                        { "SendGarnetRingMessage", new MessageValue { Method = SendGarnetRingMessage, Values = MessageParams0to3 } },
                        { "SendDiamondRingMessage", new MessageValue { Method = SendDiamondRingMessage, Values = MessageParams0to3 } },
                        { "SendSilverRingMessage", new MessageValue { Method = SendSilverRingMessage, Values = MessageParams0to3 } },
                        { "SendGoldRingMessage", new MessageValue { Method = SendGoldRingMessage, Values = MessageParams0to3 } },
                        { "SendPlatinumRingMessage", new MessageValue { Method = SendPlatinumRingMessage, Values = MessageParams0to3 } },
                        { "SendMythrilRingMessage", new MessageValue { Method = SendMythrilRingMessage, Values = MessageParams0to3 } },
                        { "SendOrichalcumRingMessage", new MessageValue { Method = SendOrichalcumRingMessage, Values = MessageParams0to3 } },
                        { "SendMastersRingMessage", new MessageValue { Method = SendMastersRingMessage, Values = MessageParams0to3 } },
                        { "SendMoonAmuletMessage", new MessageValue { Method = SendMoonAmuletMessage, Values = MessageParams0to3 } },
                        { "SendStarCharmMessage", new MessageValue { Method = SendStarCharmMessage, Values = MessageParams0to3 } },
                        { "SendSkillRingMessage", new MessageValue { Method = SendSkillRingMessage, Values = MessageParams0to3 } },
                        { "SendSkillfulRingMessage", new MessageValue { Method = SendSkillfulRingMessage, Values = MessageParams0to3 } },
                        { "SendSoldierEarringMessage", new MessageValue { Method = SendSoldierEarringMessage, Values = MessageParams0to3 } },
                        { "SendFencerEarringMessage", new MessageValue { Method = SendFencerEarringMessage, Values = MessageParams0to3 } },
                        { "SendMageEarringMessage", new MessageValue { Method = SendMageEarringMessage, Values = MessageParams0to3 } },
                        { "SendSlayerEarringMessage", new MessageValue { Method = SendSlayerEarringMessage, Values = MessageParams0to3 } },
                        { "SendCosmicRingMessage", new MessageValue { Method = SendCosmicRingMessage, Values = MessageParams0to3 } },
                        { "SendCosmicArtsMessage", new MessageValue { Method = SendCosmicArtsMessage, Values = MessageParams0to3 } },
                        { "SendShadowArchiveMessage", new MessageValue { Method = SendShadowArchiveMessage, Values = MessageParams0to3 } },
                        { "SendShadowArchivePlusMessage", new MessageValue { Method = SendShadowArchivePlusMessage, Values = MessageParams0to3 } },
                        { "SendFullBloomMessage", new MessageValue { Method = SendFullBloomMessage, Values = MessageParams0to3 } },
                        { "SendFullBloomPlusMessage", new MessageValue { Method = SendFullBloomPlusMessage, Values = MessageParams0to3 } },
                        { "SendDrawRingMessage", new MessageValue { Method = SendDrawRingMessage, Values = MessageParams0to3 } },
                        { "SendLuckyRingMessage", new MessageValue { Method = SendLuckyRingMessage, Values = MessageParams0to3 } },

                        #endregion Accessories

                        { "SendMunnyMessage", new MessageValue { Method = SendMunnyMessage, Values = MessageParams0to999999 } },
                    }
                },

                #endregion Items

                #region Model Swap
            
                { "ModelSwap", new Dictionary<string, MessageValue>
                    {
                        { "SendResetModelSwapsMessage", new MessageValue { Method = SendResetModelSwapsMessage, Values = new List<string>() } },

                        { "SendSoraModelMessage", new MessageValue { Method = SendSoraModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraLionModelMessage", new MessageValue { Method = SendSoraLionModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraTimelessRiverModelMessage", new MessageValue { Method = SendSoraTimelessRiverModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraHalloweenModelMessage", new MessageValue { Method = SendSoraHalloweenModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraChristmasModelMessage", new MessageValue { Method = SendSoraChristmasModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraSpaceParanoidsModelMessage", new MessageValue { Method = SendSoraSpaceParanoidsModelMessage, Values = MessageParamsSoraModels } },

                        { "SendSoraValorFormModelMessage", new MessageValue { Method = SendSoraValorFormModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraWisdomFormModelMessage", new MessageValue { Method = SendSoraWisdomFormModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraLimitFormModelMessage", new MessageValue { Method = SendSoraLimitFormModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraMasterFormModelMessage", new MessageValue { Method = SendSoraMasterFormModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraFinalFormModelMessage", new MessageValue { Method = SendSoraFinalFormModelMessage, Values = MessageParamsSoraModels } },
                        { "SendSoraAntiFormModelMessage", new MessageValue { Method = SendSoraAntiFormModelMessage, Values = MessageParamsSoraModels } },

                        { "SendDonaldModelMessage", new MessageValue { Method = SendDonaldModelMessage, Values = MessageParamsPartyModels } },
                        { "SendGoofyModelMessage", new MessageValue { Method = SendGoofyModelMessage, Values = MessageParamsPartyModels } },

                        { "SendHalloweenGoofyModelMessage", new MessageValue { Method = SendHalloweenGoofyModelMessage, Values = MessageParamsPartyModels } },
                        { "SendChristmasGoofyModelMessage", new MessageValue { Method = SendChristmasGoofyModelMessage, Values = MessageParamsPartyModels } },
                        { "SendTortoiseGoofyModelMessage", new MessageValue { Method = SendTortoiseGoofyModelMessage, Values = MessageParamsPartyModels } },
                        { "SendSpaceParanoidsGoofyModelMessage", new MessageValue { Method = SendSpaceParanoidsGoofyModelMessage, Values = MessageParamsPartyModels } },
                        { "SendTimelessRiverGoofyModelMessage", new MessageValue { Method = SendTimelessRiverGoofyModelMessage, Values = MessageParamsPartyModels } },

                        { "SendHalloweenDonaldModelMessage", new MessageValue { Method = SendHalloweenDonaldModelMessage, Values = MessageParamsPartyModels } },
                        { "SendChristmasDonaldModelMessage", new MessageValue { Method = SendChristmasDonaldModelMessage, Values = MessageParamsPartyModels } },
                        { "SendBirdDonaldModelMessage", new MessageValue { Method = SendBirdDonaldModelMessage, Values = MessageParamsPartyModels } },
                        { "SendSpaceParanoidsDonaldModelMessage", new MessageValue { Method = SendSpaceParanoidsDonaldModelMessage, Values = MessageParamsPartyModels } },
                        { "SendTimelessRiverDonaldModelMessage", new MessageValue { Method = SendTimelessRiverDonaldModelMessage, Values = MessageParamsPartyModels } },

                        { "SendMulanModelMessage", new MessageValue { Method = SendMulanModelMessage, Values = MessageParamsPartyModels } },
                        { "SendBeastModelMessage", new MessageValue { Method = SendBeastModelMessage, Values = MessageParamsPartyModels } },
                        { "SendAuronModelMessage", new MessageValue { Method = SendAuronModelMessage, Values = MessageParamsPartyModels } },
                        { "SendCaptainJackSparrowModelMessage", new MessageValue { Method = SendCaptainJackSparrowModelMessage, Values = MessageParamsPartyModels } },
                        { "SendAladdinModelMessage", new MessageValue { Method = SendAladdinModelMessage, Values = MessageParamsPartyModels } },
                        { "SendJackSkellingtonModelMessage", new MessageValue { Method = SendJackSkellingtonModelMessage, Values = MessageParamsPartyModels } },
                        { "SendSimbaModelMessage", new MessageValue { Method = SendSimbaModelMessage, Values = MessageParamsPartyModels } },
                        { "SendTronModelMessage", new MessageValue { Method = SendTronModelMessage, Values = MessageParamsPartyModels } },
                        { "SendRikuModelMessage", new MessageValue { Method = SendRikuModelMessage, Values = MessageParamsPartyModels } },
                    }
                },

                #endregion Model Swap

                #region Party

                { "Party", new Dictionary<string, MessageValue>
                    {
                        #region Donald

                        { "SendEquipStaffMessage", new MessageValue { Method = SendEquipStaffMessage, Values = MessageParamsStaves } },

                        { "SendDonaldArmorSlotsMessage", new MessageValue { Method = SendDonaldArmorSlotsMessage, Values = MessageParams0to2 } },
                        { "SendDonaldArmorSlot1Message", new MessageValue { Method = SendDonaldArmorSlot1Message, Values = MessageParamsArmor } },
                        { "SendDonaldArmorSlot2Message", new MessageValue { Method = SendDonaldArmorSlot2Message, Values = MessageParamsArmor } },

                        { "SendDonaldAccessorySlotsMessage", new MessageValue { Method = SendDonaldAccessorySlotsMessage, Values = MessageParams0to3 } },
                        { "SendDonaldAccessorySlot1Message", new MessageValue { Method = SendDonaldAccessorySlot1Message, Values = MessageParamsAccessories } },
                        { "SendDonaldAccessorySlot2Message", new MessageValue { Method = SendDonaldAccessorySlot2Message, Values = MessageParamsAccessories } },
                        { "SendDonaldAccessorySlot3Message", new MessageValue { Method = SendDonaldAccessorySlot3Message, Values = MessageParamsAccessories } },

                        { "SendDonaldItemSlotsMessage", new MessageValue { Method = SendDonaldItemSlotsMessage, Values = MessageParams0to2 } },
                        { "SendDonaldItemSlot1Message", new MessageValue { Method = SendDonaldItemSlot1Message, Values = MessageParamsItems } },
                        { "SendDonaldItemSlot2Message", new MessageValue { Method = SendDonaldItemSlot2Message, Values = MessageParamsItems } },

                        { "SendDonaldActivateAbilityMessage", new MessageValue { Method = SendDonaldActivateAbilityMessage, Values = AbilityMapping.DonaldAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendDonaldDeactivateAbilityMessage", new MessageValue { Method = SendDonaldDeactivateAbilityMessage, Values = AbilityMapping.DonaldAbilities.Values.Select(x => x.Name).ToList() }  },

                        #endregion Donald

                        #region Goofy

                        { "SendEquipShieldMessage", new MessageValue { Method = SendEquipShieldMessage, Values = MessageParamsShields } },

                        { "SendGoofyArmorSlotsMessage", new MessageValue { Method = SendGoofyArmorSlotsMessage, Values = MessageParams0to3 } },
                        { "SendGoofyArmorSlot1Message", new MessageValue { Method = SendGoofyArmorSlot1Message, Values = MessageParamsArmor } },
                        { "SendGoofyArmorSlot2Message", new MessageValue { Method = SendGoofyArmorSlot2Message, Values = MessageParamsArmor } },
                        { "SendGoofyArmorSlot3Message", new MessageValue { Method = SendGoofyArmorSlot3Message, Values = MessageParamsArmor } },

                        { "SendGoofyAccessorySlotsMessage", new MessageValue { Method = SendGoofyAccessorySlotsMessage, Values = MessageParams0to2 } },
                        { "SendGoofyAccessorySlot1Message", new MessageValue { Method = SendGoofyAccessorySlot1Message, Values = MessageParamsAccessories } },
                        { "SendGoofyAccessorySlot2Message", new MessageValue { Method = SendGoofyAccessorySlot2Message, Values = MessageParamsAccessories } },

                        { "SendGoofyItemSlotsMessage", new MessageValue { Method = SendGoofyItemSlotsMessage, Values = MessageParams0to4 } },
                        { "SendGoofyItemSlot1Message", new MessageValue { Method = SendGoofyItemSlot1Message, Values = MessageParamsItems } },
                        { "SendGoofyItemSlot2Message", new MessageValue { Method = SendGoofyItemSlot2Message, Values = MessageParamsItems } },
                        { "SendGoofyItemSlot3Message", new MessageValue { Method = SendGoofyItemSlot3Message, Values = MessageParamsItems } },
                        { "SendGoofyItemSlot4Message", new MessageValue { Method = SendGoofyItemSlot4Message, Values = MessageParamsItems } },

                        { "SendGoofyActivateAbilityMessage", new MessageValue { Method = SendGoofyActivateAbilityMessage, Values = AbilityMapping.GoofyAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendGoofyDeactivateAbilityMessage", new MessageValue { Method = SendGoofyDeactivateAbilityMessage, Values = AbilityMapping.GoofyAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Goofy

                        #region Mulan

                        { "SendMulanArmorSlotsMessage", new MessageValue { Method = SendMulanArmorSlotsMessage, Values = MessageParams0to1 } },
                        { "SendMulanArmorSlot1Message", new MessageValue { Method = SendMulanArmorSlot1Message, Values = MessageParamsArmor } },

                        { "SendMulanAccessorySlotsMessage", new MessageValue { Method = SendMulanAccessorySlotsMessage, Values = MessageParams0to1 } },
                        { "SendMulanAccessorySlot1Message", new MessageValue { Method = SendMulanAccessorySlot1Message, Values = MessageParamsAccessories } },

                        { "SendMulanItemSlotsMessage", new MessageValue { Method = SendMulanItemSlotsMessage, Values = MessageParams0to3 } },
                        { "SendMulanItemSlot1Message", new MessageValue { Method = SendMulanItemSlot1Message, Values = MessageParamsItems } },
                        { "SendMulanItemSlot2Message", new MessageValue { Method = SendMulanItemSlot1Message, Values = MessageParamsItems } },
                        { "SendMulanItemSlot3Message", new MessageValue { Method = SendMulanItemSlot1Message, Values = MessageParamsItems } },

                        { "SendMulanActivateAbilityMessage", new MessageValue { Method = SendMulanActivateAbilityMessage, Values = AbilityMapping.MulanAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendMulanDeactivateAbilityMessage", new MessageValue { Method = SendMulanDeactivateAbilityMessage, Values = AbilityMapping.MulanAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Mulan

                        #region Beast

                        { "SendBeastAccessorySlotsMessage", new MessageValue { Method = SendBeastAccessorySlotsMessage, Values = MessageParams0to1 } },
                        { "SendBeastAccessorySlot1Message", new MessageValue { Method = SendBeastAccessorySlot1Message, Values = MessageParamsAccessories } },

                        { "SendBeastItemSlotsMessage", new MessageValue { Method = SendBeastItemSlotsMessage, Values = MessageParams0to4 } },
                        { "SendBeastItemSlot1Message", new MessageValue { Method = SendBeastItemSlot1Message, Values = MessageParamsItems } },
                        { "SendBeastItemSlot2Message", new MessageValue { Method = SendBeastItemSlot2Message, Values = MessageParamsItems } },
                        { "SendBeastItemSlot3Message", new MessageValue { Method = SendBeastItemSlot3Message, Values = MessageParamsItems } },
                        { "SendBeastItemSlot4Message", new MessageValue { Method = SendBeastItemSlot4Message, Values = MessageParamsItems } },

                        { "SendBeastActivateAbilityMessage", new MessageValue { Method = SendBeastActivateAbilityMessage, Values = AbilityMapping.BeastAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendBeastDeactivateAbilityMessage", new MessageValue { Method = SendBeastDeactivateAbilityMessage, Values = AbilityMapping.BeastAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Beast

                        #region Auron

                        { "SendAuronArmorSlotsMessage", new MessageValue { Method = SendAuronArmorSlotsMessage, Values = MessageParams0to1 } },
                        { "SendAuronArmorSlot1Message", new MessageValue { Method = SendAuronArmorSlot1Message, Values = MessageParamsArmor } },

                        { "SendAuronItemSlotsMessage", new MessageValue { Method = SendAuronItemSlotsMessage, Values = MessageParams0to2 }  },
                        { "SendAuronItemSlot1Message", new MessageValue { Method = SendAuronItemSlot1Message, Values = MessageParamsItems } },
                        { "SendAuronItemSlot2Message", new MessageValue { Method = SendAuronItemSlot2Message, Values = MessageParamsItems } },

                        { "SendAuronActivateAbilityMessage", new MessageValue { Method = SendAuronActivateAbilityMessage, Values = AbilityMapping.AuronAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendAuronDeactivateAbilityMessage", new MessageValue { Method = SendAuronDeactivateAbilityMessage, Values = AbilityMapping.AuronAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Auron

                        #region Captain Jack Sparrow

                        { "SendCaptainJackSparrowArmorSlotsMessage", new MessageValue { Method = SendCaptainJackSparrowArmorSlotsMessage, Values = MessageParams0to1 }  },
                        { "SendCaptainJackSparrowArmorSlot1Message", new MessageValue { Method = SendCaptainJackSparrowArmorSlot1Message, Values = MessageParamsArmor } },
                    
                        { "SendCaptainJackSparrowAccessorySlotsMessage", new MessageValue { Method = SendCaptainJackSparrowAccessorySlotsMessage, Values = MessageParams0to1 } },
                        { "SendCaptainJackSparrowAccessorySlot1Message", new MessageValue { Method = SendCaptainJackSparrowAccessorySlot1Message, Values = MessageParamsAccessories } },
                    
                        { "SendCaptainJackSparrowItemSlotsMessage", new MessageValue { Method = SendCaptainJackSparrowItemSlotsMessage, Values = MessageParams0to4 }  },
                        { "SendCaptainJackSparrowItemSlot1Message", new MessageValue { Method = SendCaptainJackSparrowItemSlot1Message, Values = MessageParamsItems } },
                        { "SendCaptainJackSparrowItemSlot2Message", new MessageValue { Method = SendCaptainJackSparrowItemSlot2Message, Values = MessageParamsItems } },
                        { "SendCaptainJackSparrowItemSlot3Message", new MessageValue { Method = SendCaptainJackSparrowItemSlot3Message, Values = MessageParamsItems } },
                        { "SendCaptainJackSparrowItemSlot4Message", new MessageValue { Method = SendCaptainJackSparrowItemSlot4Message, Values = MessageParamsItems } },

                        { "SendCaptainJackSparrowActivateAbilityMessage", new MessageValue { Method = SendCaptainJackSparrowActivateAbilityMessage, Values = AbilityMapping.CaptainJackSparrowAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendCaptainJackSparrowDeactivateAbilityMessage", new MessageValue { Method = SendCaptainJackSparrowDeactivateAbilityMessage, Values = AbilityMapping.CaptainJackSparrowAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Captain Jack Sparrow

                        #region Aladdin

                        { "SendAladdinArmorSlotsMessage", new MessageValue { Method = SendAladdinArmorSlotsMessage, Values = MessageParams0to2 }  },
                        { "SendAladdinArmorSlot1Message", new MessageValue { Method = SendAladdinArmorSlot1Message, Values = MessageParamsArmor } },
                        { "SendAladdinArmorSlot2Message", new MessageValue { Method = SendAladdinArmorSlot2Message, Values = MessageParamsArmor } },

                        { "SendAladdinItemSlotsMessage", new MessageValue { Method = SendAladdinItemSlotsMessage, Values = MessageParams0to5 }  },
                        { "SendAladdinItemSlot1Message", new MessageValue { Method = SendAladdinItemSlot1Message, Values = MessageParamsItems } },
                        { "SendAladdinItemSlot2Message", new MessageValue { Method = SendAladdinItemSlot2Message, Values = MessageParamsItems } },
                        { "SendAladdinItemSlot3Message", new MessageValue { Method = SendAladdinItemSlot3Message, Values = MessageParamsItems } },
                        { "SendAladdinItemSlot4Message", new MessageValue { Method = SendAladdinItemSlot4Message, Values = MessageParamsItems } },
                        { "SendAladdinItemSlot5Message", new MessageValue { Method = SendAladdinItemSlot5Message, Values = MessageParamsItems } },

                        { "SendAladdinActivateAbilityMessage", new MessageValue { Method = SendAladdinActivateAbilityMessage, Values = AbilityMapping.AladdinAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendAladdinDeactivateAbilityMessage", new MessageValue { Method = SendAladdinDeactivateAbilityMessage, Values = AbilityMapping.AladdinAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Aladdin

                        #region Jack Skellington

                        { "SendJackSkellingtonAccessorySlotsMessage", new MessageValue { Method = SendJackSkellingtonAccessorySlotsMessage, Values = MessageParams0to2 } },
                        { "SendJackSkellingtonAccessorySlot1Message", new MessageValue { Method = SendJackSkellingtonAccessorySlot1Message, Values = MessageParamsAccessories } },
                        { "SendJackSkellingtonAccessorySlot2Message", new MessageValue { Method = SendJackSkellingtonAccessorySlot2Message, Values = MessageParamsAccessories } },

                        { "SendJackSkellingtonItemSlotsMessage", new MessageValue { Method = SendJackSkellingtonItemSlotsMessage, Values = MessageParams0to3 }  },
                        { "SendJackSkellingtonItemSlot1Message", new MessageValue { Method = SendJackSkellingtonItemSlot1Message, Values = MessageParamsItems } },
                        { "SendJackSkellingtonItemSlot2Message", new MessageValue { Method = SendJackSkellingtonItemSlot2Message, Values = MessageParamsItems } },
                        { "SendJackSkellingtonItemSlot3Message", new MessageValue { Method = SendJackSkellingtonItemSlot3Message, Values = MessageParamsItems } },

                        { "SendJackSkellingtonActivateAbilityMessage", new MessageValue { Method = SendJackSkellingtonActivateAbilityMessage, Values = AbilityMapping.JackSkellingtonAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendJackSkellingtonDeactivateAbilityMessage", new MessageValue { Method = SendJackSkellingtonDeactivateAbilityMessage, Values = AbilityMapping.JackSkellingtonAbilities.Values.Select(x => x.Name).ToList() } },


                        #endregion Jack Skellington

                        #region Simba

                        { "SendSimbaAccessorySlotsMessage", new MessageValue { Method = SendSimbaAccessorySlotsMessage, Values = MessageParams0to2 } },
                        { "SendSimbaAccessorySlot1Message", new MessageValue { Method = SendSimbaAccessorySlot1Message, Values = MessageParamsAccessories } },
                        { "SendSimbaAccessorySlot2Message", new MessageValue { Method = SendSimbaAccessorySlot2Message, Values = MessageParamsAccessories } },

                        { "SendSimbaItemSlotsMessage", new MessageValue { Method = SendSimbaItemSlotsMessage, Values = MessageParams0to3 }  },
                        { "SendSimbaItemSlot1Message", new MessageValue { Method = SendSimbaItemSlot1Message, Values = MessageParamsItems } },
                        { "SendSimbaItemSlot2Message", new MessageValue { Method = SendSimbaItemSlot2Message, Values = MessageParamsItems } },
                        { "SendSimbaItemSlot3Message", new MessageValue { Method = SendSimbaItemSlot3Message, Values = MessageParamsItems } },

                        { "SendSimbaActivateAbilityMessage", new MessageValue { Method = SendSimbaActivateAbilityMessage, Values = AbilityMapping.SimbaAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendSimbaDeactivateAbilityMessage", new MessageValue { Method = SendSimbaDeactivateAbilityMessage, Values = AbilityMapping.SimbaAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Simba

                        #region Tron

                        { "SendTronArmorSlotsMessage", new MessageValue { Method = SendTronArmorSlotsMessage, Values = MessageParams0to1 } },
                        { "SendTronArmorSlot1Message", new MessageValue { Method = SendTronArmorSlot1Message, Values = MessageParamsArmor } },

                        { "SendTronAccessorySlotsMessage", new MessageValue { Method = SendTronAccessorySlotsMessage, Values = MessageParams0to1 } },
                        { "SendTronAccessorySlot1Message", new MessageValue { Method = SendTronAccessorySlot1Message, Values = MessageParamsAccessories } },

                        { "SendTronItemSlotsMessage", new MessageValue { Method = SendTronItemSlotsMessage, Values = MessageParams0to2 }  },
                        { "SendTronItemSlot1Message", new MessageValue { Method = SendTronItemSlot1Message, Values = MessageParamsItems } },
                        { "SendTronItemSlot2Message", new MessageValue { Method = SendTronItemSlot2Message, Values = MessageParamsItems } },

                        { "SendTronActivateAbilityMessage", new MessageValue { Method = SendTronActivateAbilityMessage, Values = AbilityMapping.TronAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendTronDeactivateAbilityMessage", new MessageValue { Method = SendTronDeactivateAbilityMessage, Values = AbilityMapping.TronAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Tron

                        #region Riku

                        { "SendRikuArmorSlotsMessage", new MessageValue { Method = SendRikuArmorSlotsMessage, Values = MessageParams0to2 } },
                        { "SendRikuArmorSlot1Message", new MessageValue { Method = SendRikuArmorSlot1Message, Values = MessageParamsArmor } },
                        { "SendRikuArmorSlot2Message", new MessageValue { Method = SendRikuArmorSlot2Message, Values = MessageParamsArmor } },

                        { "SendRikuAccessorySlotsMessage", new MessageValue { Method = SendRikuAccessorySlotsMessage, Values = MessageParams0to2 } },
                        { "SendRikuAccessorySlot1Message", new MessageValue { Method = SendRikuAccessorySlot1Message, Values = MessageParamsAccessories } },

                        { "SendRikuItemSlotsMessage", new MessageValue { Method = SendRikuItemSlotsMessage, Values = MessageParams0to6 }  },
                        { "SendRikuItemSlot1Message", new MessageValue { Method = SendRikuItemSlot1Message, Values = MessageParamsItems } },
                        { "SendRikuItemSlot2Message", new MessageValue { Method = SendRikuItemSlot2Message, Values = MessageParamsItems } },
                        { "SendRikuItemSlot3Message", new MessageValue { Method = SendRikuItemSlot3Message, Values = MessageParamsItems } },
                        { "SendRikuItemSlot4Message", new MessageValue { Method = SendRikuItemSlot4Message, Values = MessageParamsItems } },
                        { "SendRikuItemSlot5Message", new MessageValue { Method = SendRikuItemSlot5Message, Values = MessageParamsItems } },
                        { "SendRikuItemSlot6Message", new MessageValue { Method = SendRikuItemSlot6Message, Values = MessageParamsItems } },

                        { "SendRikuActivateAbilityMessage", new MessageValue { Method = SendRikuActivateAbilityMessage, Values = AbilityMapping.RikuAbilities.Values.Select(x => x.Name).ToList() } },
                        { "SendRikuDeactivateAbilityMessage", new MessageValue { Method = SendRikuDeactivateAbilityMessage, Values = AbilityMapping.RikuAbilities.Values.Select(x => x.Name).ToList() } },

                        #endregion Riku
                    }
                },

                #endregion Party

                #region Enemy

                { "Enemy", new Dictionary<string, MessageValue>
                    {
                        { "SendBossChangeMessage", new MessageValue { Method = SendBossChangeMessage, Values = new List<string>() } },    

                        #region Timers
                
                        { "SendBossActivateHealthTimerMessage", new MessageValue { Method = SendBossActivateHealthTimerMessage, Values = EnemyMapping.Enemies.Values.Select(x => x.Name).ToList() } },
                        { "SendBossDeactivateHealthTimerMessage", new MessageValue { Method = SendBossDeactivateHealthTimerMessage, Values = EnemyMapping.Enemies.Values.Select(x => x.Name).ToList() } },
                        { "SendBossActivateStrengthTimerMessage", new MessageValue { Method = SendBossActivateStrengthTimerMessage, Values = EnemyMapping.Enemies.Values.Select(x => x.Name).ToList() } },
                        { "SendBossDeactivateStrengthTimerMessage", new MessageValue { Method = SendBossDeactivateStrengthTimerMessage, Values = EnemyMapping.Enemies.Values.Select(x => x.Name).ToList() } },
                        { "SendBossActivateDefenseTimerMessage", new MessageValue { Method = SendBossActivateDefenseTimerMessage, Values = EnemyMapping.Enemies.Values.Select(x => x.Name).ToList() } },
                        { "SendBossDeactivateDefenseTimerMessage", new MessageValue { Method = SendBossDeactivateDefenseTimerMessage, Values = EnemyMapping.Enemies.Values.Select(x => x.Name).ToList() } },

                        #endregion Timers

                        #region Set Changes
                    
                        { "SendBossMaxHealthChangeMessage", new MessageValue { Method = SendBossMaxHealthChangeMessage, Values = new List<string>() } },
                        { "SendBossHealthChangeMessage", new MessageValue { Method = SendBossHealthChangeMessage, Values = new List<string>() } },
                        { "SendBossStrengthChangeMessage", new MessageValue { Method = SendBossStrengthChangeMessage, Values = new List<string>() } },
                        { "SendBossDefenseChangeMessage", new MessageValue { Method = SendBossDefenseChangeMessage, Values = new List<string>() } },

                        #endregion Set Changes
                    }
                },

                #endregion Enemy

                #region Environment

                { "Environment", new Dictionary<string, MessageValue>
                    {
                        { "SendRoomChangeMessage", new MessageValue { Method = SendRoomChangeMessage, Values = new List<string>() } },
                    }
                },

                #endregion Environment
            };
        }

        private static void CreateInterval(MemoryObject obj, int interval = 1)
        {
            var timer = new Timer(interval)
            {
                Enabled = true,
                AutoReset = true
            };

            switch (obj.Name)
            {
                case "Press Triangle Reaction Command":

                    CheckMemoryForTrianglePress(memoryProcessor.UpdateMemory, obj, timer);

                    Console.WriteLine($"{obj.Name} updated to {obj.Value} - Type: {obj.Type} - Address: {obj.Address}");

                    break;
                default:

                    memoryProcessor.UpdateMemory(obj);

                    Console.WriteLine($"{obj.Name} updated to {obj.Value} - Type: {obj.Type} - Address: {obj.Address}");

                    break;
            }
        }

        private static void CheckMemoryForTrianglePress(Func<MemoryObject, bool> action, MemoryObject obj, Timer timer)
        {
            timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                if (memoryProcessor.CheckMemory(0x21C5FF4E, DataType.TwoBytes, "0", false))
                    timer.Stop();

                action.Invoke(obj);
            };
        }

        public void SelectRandomMessage()
        {
            try
            {
                var message = this.RandomValues(this.RandomValues(this.MessageMappings).Item2).Item2;

                var values = message.Values;

                if (values.Count > 0)
                {
                    Random rand = new Random();

                    if (values.Count == 2)
                    {
                        var value = rand.Next(int.Parse(values[0]), int.Parse(values[1]) + 1);

                        message.Method(ManipulationType.Set, value.ToString());

                        Logger.Instance.Info($"Selected Message {nameof(message.Method)} with value: {value}", "SelectRandomMessage");

                        MessageHub.SendServerLogReceived(this, new MessageHubArgs { Viewer = "Solo", MethodName = nameof(message.Method), Value = value.ToString() });
                    }
                    else
                    {
                        var value = values[rand.Next(values.Count)];

                        message.Method(ManipulationType.Set, value);

                        Logger.Instance.Info($"Selected Message {nameof(message.Method)} with value: {value}", "SelectRandomMessage");

                        MessageHub.SendServerLogReceived(this, new MessageHubArgs { Viewer = "Solo", MethodName = nameof(message.Method), Value = value });
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Instance.Error($"Error Selecting Random Message: {ex.Message}", "SelectRandomMessage");
            }
        }

        private Tuple<int, TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();

            List<TValue> values = Enumerable.ToList(dict.Values);

            var index = rand.Next(dict.Count);
            
            return new Tuple<int, TValue>(index, values[index]);
        }
    }
}