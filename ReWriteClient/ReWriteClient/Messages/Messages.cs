using ReWriteClient.Data;
using ReWriteClient.Enums;
using System;
using System.Collections.Generic;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        private static readonly MemoryProcessor memoryProcessor = MemoryProcessor.Instance;

        public static Messages Instance { get; set; } = new Messages();

        private Messages()
        { }

        public Dictionary<string, Dictionary<string, Func<ManipulationType, string, bool>>> MessageMappings = new Dictionary<string, Dictionary<string, Func<ManipulationType, string, bool>>>
        {
            #region Sora
            
            { "Sora", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    #region Stats

                    { "SendSoraLevelMessage", SendSoraLevelMessage },
                    { "SendSoraCurrentHPMessage", SendSoraCurrentHPMessage },
                    { "SendSoraMaxHPMessage", SendSoraMaxHPMessage },
                    { "SendSoraAPMessage", SendSoraAPMessage },
                    { "SendSoraStrengthMessage", SendSoraStrengthMessage },
                    { "SendSoraMagicMessage", SendSoraMagicMessage },
                    { "SendSoraDefenseMessage", SendSoraDefenseMessage },

                    #endregion Stats

                    #region Magic

                    { "SendSoraCurrentMagicMessage", SendSoraCurrentMagicMessage },
                    { "SendSoraMaxMagicMessage", SendSoraMaxMagicMessage },
                    { "SendSoraRechargeMagicMessage", SendSoraRechargeMagicMessage },
                    { "SendFireMagicMessage", SendFireMagicMessage },
                    { "SendBlizzardMagicMessage", SendBlizzardMagicMessage },
                    { "SendCureMagicMessage", SendCureMagicMessage },
                    { "SendMagnetMagicMessage", SendMagnetMagicMessage },
                    { "SendReflectMagicMessage", SendReflectMagicMessage },

                    #endregion Magic

                    #region Equipment
            
                    { "SendEquipKeybladeMessage", SendEquipKeybladeMessage },
                    { "SendEquipValorKeybladeMessage", SendEquipValorKeybladeMessage },
                    { "SendEquipMasterKeybladeMessage", SendEquipMasterKeybladeMessage },
                    { "SendEquipFinalKeybladeMessage", SendEquipFinalKeybladeMessage },

                    #endregion Equipment

                    #region Armor

                    { "SendSoraArmorSlotsMessage", SendSoraArmorSlotsMessage },
                    { "SendSoraArmorSlot1Message", SendSoraArmorSlot1Message },
                    { "SendSoraArmorSlot2Message", SendSoraArmorSlot2Message },
                    { "SendSoraArmorSlot3Message", SendSoraArmorSlot3Message },
                    { "SendSoraArmorSlot4Message", SendSoraArmorSlot4Message },

                    #endregion Armor

                    #region Accessories

                    { "SendSoraAccessorySlotsMessage", SendSoraAccessorySlotsMessage },
                    { "SendSoraAccessorySlot1Message", SendSoraAccessorySlot1Message },
                    { "SendSoraAccessorySlot2Message", SendSoraAccessorySlot2Message },
                    { "SendSoraAccessorySlot3Message", SendSoraAccessorySlot3Message },
                    { "SendSoraAccessorySlot4Message", SendSoraAccessorySlot4Message },

                    #endregion Accessories

                    #region Items

                    { "SendSoraItemSlotsMessage", SendSoraItemSlotsMessage },
                    { "SendSoraItemSlot1Message", SendSoraItemSlot1Message },
                    { "SendSoraItemSlot2Message", SendSoraItemSlot2Message },
                    { "SendSoraItemSlot3Message", SendSoraItemSlot3Message },
                    { "SendSoraItemSlot4Message", SendSoraItemSlot4Message },
                    { "SendSoraItemSlot5Message", SendSoraItemSlot5Message },
                    { "SendSoraItemSlot6Message", SendSoraItemSlot6Message },
                    { "SendSoraItemSlot7Message", SendSoraItemSlot7Message },
                    { "SendSoraItemSlot8Message", SendSoraItemSlot8Message },

                    #endregion Items

                    #region Abilities

                    { "SendSoraActivateAbilityMessage", SendSoraActivateAbilityMessage },
                    { "SendSoraDeactivateAbilityMessage", SendSoraDeactivateAbilityMessage },

                    #endregion Abilities
                }
            },

            #endregion Sora

            #region Drive
            
            { "Drive", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendCurrentDriveCounterMessage", SendCurrentDriveCounterMessage },
                    { "SendMaxDriveCounterMessage", SendMaxDriveCounterMessage },
                    { "SendDriveTimeMessage", SendDriveTimeMessage },
                    { "SendDisableDriveMessage", SendDisableDriveMessage },
                    { "SendValorWisdomMasterFinalAntiMessage", SendValorWisdomMasterFinalAntiMessage },
                    { "SendLimitMessage", SendLimitMessage },
                    { "SendActivateFormMessage", SendActivateFormMessage },
                }
            },

            #endregion Drive

            #region Summon

            { "Summon", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendUkuleleBaseballMessage", SendUkuleleBaseballMessage },
                    { "SendLampFeatherMessage", SendLampFeatherMessage },
                }
            },

            #endregion Summon

            #region Donald

            { "Donald", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    #region Weapons

                    { "SendEquipStaffMessage", SendEquipStaffMessage },

                    #endregion Weapons

                    #region Armor

                    { "SendDonaldArmorSlotsMessage", SendDonaldArmorSlotsMessage },
                    { "SendDonaldArmorSlot1Message", SendDonaldArmorSlot1Message },
                    { "SendDonaldArmorSlot2Message", SendDonaldArmorSlot2Message },

                    #endregion Armor

                    #region Accessories

                    { "SendDonaldAccessorySlotsMessage", SendDonaldAccessorySlotsMessage },
                    { "SendDonaldAccessorySlot1Message", SendDonaldAccessorySlot1Message },
                    { "SendDonaldAccessorySlot2Message", SendDonaldAccessorySlot2Message },
                    { "SendDonaldAccessorySlot3Message", SendDonaldAccessorySlot3Message },

                    #endregion Accessories

                    #region Items

                    { "SendDonaldItemSlotsMessage", SendDonaldItemSlotsMessage },
                    { "SendDonaldItemSlot1Message", SendDonaldItemSlot1Message },
                    { "SendDonaldItemSlot2Message", SendDonaldItemSlot2Message },

                    #endregion Items
                }
            },

            #endregion Donald

            #region Goofy 
            
            { "Goofy", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    #region Weapons

                    { "SendEquipShieldMessage", SendEquipShieldMessage },

                    #endregion Weapons

                    #region Armor

                    { "SendGoofyArmorSlotsMessage", SendGoofyArmorSlotsMessage },
                    { "SendGoofyArmorSlot1Message", SendGoofyArmorSlot1Message },
                    { "SendGoofyArmorSlot2Message", SendGoofyArmorSlot2Message },
                    { "SendGoofyArmorSlot3Message", SendGoofyArmorSlot3Message },

                    #endregion Armor

                    #region Accessories

                    { "SendGoofyAccessorySlotsMessage", SendGoofyAccessorySlotsMessage },
                    { "SendGoofyAccessorySlot1Message", SendGoofyAccessorySlot1Message },
                    { "SendGoofyAccessorySlot2Message", SendGoofyAccessorySlot2Message },

                    #endregion Accessories

                    #region Items

                    { "SendGoofyItemSlotsMessage", SendGoofyItemSlotsMessage },
                    { "SendGoofyItemSlot1Message", SendGoofyItemSlot1Message },
                    { "SendGoofyItemSlot2Message", SendGoofyItemSlot2Message },
                    { "SendGoofyItemSlot3Message", SendGoofyItemSlot3Message },
                    { "SendGoofyItemSlot4Message", SendGoofyItemSlot4Message },

                    #endregion Items
                }
            },

            #endregion Goofy

            #region Items
            
            { "Items", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    #region Base Items

                    { "SendPotionMessage", SendPotionMessage },
                    { "SendHiPotionMessage", SendHiPotionMessage },
                    { "SendEtherMessage", SendEtherMessage },
                    { "SendElixirMessage", SendElixirMessage },
                    { "SendMegaPotionMessage", SendMegaPotionMessage },
                    { "SendMegaEtherMessage", SendMegaEtherMessage },
                    { "SendMegaElixirMessage", SendMegaElixirMessage },
                    { "SendTentMessage", SendTentMessage },
                    { "SendDriveRecoveryMessage", SendDriveRecoveryMessage },
                    { "SendHighDriveRecoveryMessage", SendHighDriveRecoveryMessage },
                    { "SendPowerBoostMessage", SendPowerBoostMessage },
                    { "SendMagicBoostMessage", SendMagicBoostMessage },
                    { "SendDefenseBoostMessage", SendDefenseBoostMessage },
                    { "SendAPBoostMessage", SendAPBoostMessage },

                    #endregion Base Items

                    #region Weapons

                    #region Sora

                    { "SendKingdomKeyMessage", SendKingdomKeyMessage },
                    { "SendOathkeeperMessage", SendOathkeeperMessage },
                    { "SendOblivionMessage", SendOblivionMessage },
                    { "SendStarSeekerMessage", SendStarSeekerMessage },
                    { "SendHiddenDragonMessage", SendHiddenDragonMessage },
                    { "SendHerosCrestMessage", SendHerosCrestMessage },
                    { "SendMonochromeMessage", SendMonochromeMessage },
                    { "SendFollowTheWindMessage", SendFollowTheWindMessage },
                    { "SendCircleOfLifeMessage", SendCircleOfLifeMessage },
                    { "SendPhotonDebuggerMessage", SendPhotonDebuggerMessage },
                    { "SendGullWingMessage", SendGullWingMessage },
                    { "SendRumblingRoseMessage", SendRumblingRoseMessage },
                    { "SendGuardianSoulMessage", SendGuardianSoulMessage },
                    { "SendWishingLampMessage", SendWishingLampMessage },
                    { "SendDecisivePumpkinMessage", SendDecisivePumpkinMessage },
                    { "SendSleepingLionMessage", SendSleepingLionMessage },
                    { "SendSweetMemoriesMessage", SendSweetMemoriesMessage },
                    { "SendMysteriousAbyssMessage", SendMysteriousAbyssMessage },
                    { "SendBondOfFlameMessage", SendBondOfFlameMessage },
                    { "SendFatalCrestMessage", SendFatalCrestMessage },
                    { "SendFenrirMessage", SendFenrirMessage },
                    { "SendUltimaWeaponMessage", SendUltimaWeaponMessage },
                    { "SendTwoBecomeOneMessage", SendTwoBecomeOneMessage },
                    { "SendWinnersProofMessage", SendWinnersProofMessage },
                    { "SendFrontierOfUltimaMessage", SendFrontierOfUltimaMessage },
                    { "SendDetectionSaberMessage", SendDetectionSaberMessage },

                    #endregion Sora

                    #region Donald

                    { "SendMagesStaffMessage", SendMagesStaffMessage },
                    { "SendHammerStaffMessage", SendHammerStaffMessage },
                    { "SendVictoryBellMessage", SendVictoryBellMessage },
                    { "SendMeteorStaffMessage", SendMeteorStaffMessage },
                    { "SendCometStaffMessage", SendCometStaffMessage },
                    { "SendLordsBroomMessage", SendLordsBroomMessage },
                    { "SendWisdomWandMessage", SendWisdomWandMessage },
                    { "SendRisingDragonMessage", SendRisingDragonMessage },
                    { "SendNobodyLanceMessage", SendNobodyLanceMessage },
                    { "SendShamansRelicMessage", SendShamansRelicMessage },
                    { "SendShamansRelicPlusMessage", SendShamansRelicPlusMessage },
                    { "SendSaveTheQueenMessage", SendSaveTheQueenMessage },
                    { "SendSaveTheQueenPlusMessage", SendSaveTheQueenPlusMessage },
                    { "SendCenturionMessage", SendCenturionMessage },
                    { "SendCenturionPlusMessage", SendCenturionPlusMessage },
                    { "SendPlainMushroomMessage", SendPlainMushroomMessage },
                    { "SendPlainMushroomPlusMessage", SendPlainMushroomPlusMessage },
                    { "SendPreciousMushroomMessage", SendPreciousMushroomMessage },
                    { "SendPreciousMushroomPlusMessage", SendPreciousMushroomPlusMessage },
                    { "SendPremiumMushroomMessage", SendPremiumMushroomMessage },
                    { "SendStaffOfDetectionMessage", SendStaffOfDetectionMessage },

                    #endregion Donald

                    #region Goofy

                    { "SendKnightsShieldMessage", SendKnightsShieldMessage },
                    { "SendAdamantShieldMessage", SendAdamantShieldMessage },
                    { "SendChainGearMessage", SendChainGearMessage },
                    { "SendOgreShieldMessage", SendOgreShieldMessage },
                    { "SendFallingStarMessage", SendFallingStarMessage },
                    { "SendDreamcloudMessage", SendDreamcloudMessage },
                    { "SendKnightDefenderMessage", SendKnightDefenderMessage },
                    { "SendGenjiShieldMessage", SendGenjiShieldMessage },
                    { "SendAkashicRecordMessage", SendAkashicRecordMessage },
                    { "SendAkashicRecordPlusMessage", SendAkashicRecordPlusMessage },
                    { "SendNobodyGuardMessage", SendNobodyGuardMessage },
                    { "SendSaveTheKingMessage", SendSaveTheKingMessage },
                    { "SendSaveTheKingPlusMessage", SendSaveTheKingPlusMessage },
                    { "SendFrozenPrideMessage", SendFrozenPrideMessage },
                    { "SendFrozenPridePlusMessage", SendFrozenPridePlusMessage },
                    { "SendJoyousMushroomMessage", SendJoyousMushroomMessage },
                    { "SendJoyousMushroomPlusMessage", SendJoyousMushroomPlusMessage },
                    { "SendMajesticMushroomMessage", SendMajesticMushroomMessage },
                    { "SendMajesticMushroomPlusMessage", SendMajesticMushroomPlusMessage },
                    { "SendUltimateMushroomMessage", SendUltimateMushroomMessage },
                    { "SendDetectionShieldMessage", SendDetectionShieldMessage },

                    #endregion Goofy

                    #endregion Weapons

                    #region Armor

                    { "SendElvenBandannaMessage", SendElvenBandannaMessage },
                    { "SendDivineBandannaMessage", SendDivineBandannaMessage },
                    { "SendPowerBandMessage", SendPowerBandMessage },
                    { "SendBusterBandMessage", SendBusterBandMessage },
                    { "SendProtectBeltMessage", SendProtectBeltMessage },
                    { "SendGaiaBeltMessage", SendGaiaBeltMessage },
                    { "SendCosmicBeltMessage", SendCosmicBeltMessage },
                    { "SendShockCharmMessage", SendShockCharmMessage },
                    { "SendShockCharmPlusMessage", SendShockCharmPlusMessage },
                    { "SendFireBangleMessage", SendFireBangleMessage },
                    { "SendFiraBangleMessage", SendFiraBangleMessage },
                    { "SendFiragaBangleMessage", SendFiragaBangleMessage },
                    { "SendFiragunBangleMessage", SendFiragunBangleMessage },
                    { "SendBlizzardArmletMessage", SendBlizzardArmletMessage },
                    { "SendBlizzaraArmletMessage", SendBlizzaraArmletMessage },
                    { "SendBlizzagaArmletMessage", SendBlizzagaArmletMessage },
                    { "SendBlizzagunArmletMessage", SendBlizzagunArmletMessage },
                    { "SendThunderTrinketMessage", SendThunderTrinketMessage },
                    { "SendThundaraTrinketMessage", SendThundaraTrinketMessage },
                    { "SendThundagaTrinketMessage", SendThundagaTrinketMessage },
                    { "SendThundagunTrinketMessage", SendThundagunTrinketMessage },
                    { "SendShadowAnkletMessage", SendShadowAnkletMessage },
                    { "SendDarkAnkletMessage", SendDarkAnkletMessage },
                    { "SendMidnightAnkletMessage", SendMidnightAnkletMessage },
                    { "SendChaosAnkletMessage", SendChaosAnkletMessage },
                    { "SendAbasChainMessage", SendAbasChainMessage },
                    { "SendAegisChainMessage", SendAegisChainMessage },
                    { "SendCosmicChainMessage", SendCosmicChainMessage },
                    { "SendAcrisiusMessage", SendAcrisiusMessage },
                    { "SendAcrisiusPlusMessage", SendAcrisiusPlusMessage },
                    { "SendPetiteRibbonMessage", SendPetiteRibbonMessage },
                    { "SendRibbonMessage", SendRibbonMessage },
                    { "SendGrandRibbonMessage", SendGrandRibbonMessage },
                    { "SendChampionBeltMessage", SendChampionBeltMessage },

                    #endregion Armor

                    #region Accessories
            
                    { "SendMedalMessage", SendMedalMessage },
                    { "SendAbilityRingMessage", SendAbilityRingMessage },
                    { "SendEngineersRingMessage", SendEngineersRingMessage },
                    { "SendTechniciansRingMessage", SendTechniciansRingMessage },
                    { "SendExpertsRingMessage", SendExpertsRingMessage },
                    { "SendExecutivesRingMessage", SendExecutivesRingMessage },
                    { "SendSardonyxRingMessage", SendSardonyxRingMessage },
                    { "SendTourmalineRingMessage", SendTourmalineRingMessage },
                    { "SendAquamarineRingMessage", SendAquamarineRingMessage },
                    { "SendGarnetRingMessage", SendGarnetRingMessage },
                    { "SendDiamondRingMessage", SendDiamondRingMessage },
                    { "SendSilverRingMessage", SendSilverRingMessage },
                    { "SendGoldRingMessage", SendGoldRingMessage },
                    { "SendPlatinumRingMessage", SendPlatinumRingMessage },
                    { "SendMythrilRingMessage", SendMythrilRingMessage },
                    { "SendOrichalcumRingMessage", SendOrichalcumRingMessage },
                    { "SendMastersRingMessage", SendMastersRingMessage },
                    { "SendMoonAmuletMessage", SendMoonAmuletMessage },
                    { "SendStarCharmMessage", SendStarCharmMessage },
                    { "SendSkillRingMessage", SendSkillRingMessage },
                    { "SendSkillfulRingMessage", SendSkillfulRingMessage },
                    { "SendSoldierEarringMessage", SendSoldierEarringMessage },
                    { "SendFencerEarringMessage", SendFencerEarringMessage },
                    { "SendMageEarringMessage", SendMageEarringMessage },
                    { "SendSlayerEarringMessage", SendSlayerEarringMessage },
                    { "SendCosmicRingMessage", SendCosmicRingMessage },
                    { "SendCosmicArtsMessage", SendCosmicArtsMessage },
                    { "SendShadowArchiveMessage", SendShadowArchiveMessage },
                    { "SendShadowArchivePlusMessage", SendShadowArchivePlusMessage },
                    { "SendFullBloomMessage", SendFullBloomMessage },
                    { "SendFullBloomPlusMessage", SendFullBloomPlusMessage },
                    { "SendDrawRingMessage", SendDrawRingMessage },
                    { "SendLuckyRingMessage", SendLuckyRingMessage },

                    #endregion Accessories
                }
            },

            #endregion Items

            #region Model Swap
            
            { "ModelSwap", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendSoraModelMessage", SendSoraModelMessage },
                    { "SendDonaldAllyModelMessage", SendDonaldAllyModelMessage },
                    { "SendDonaldEnemyModelMessage", SendDonaldEnemyModelMessage },
                    { "SendGoofyAllyModelMessage", SendGoofyAllyModelMessage },
                    { "SendGoofyEnemyModelMessage", SendGoofyEnemyModelMessage },
                }
            },

            #endregion Model Swap

            #region Misc
            
            { "Misc", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendMunnyMessage", SendMunnyMessage },
                }
            }

            #endregion Misc
        };

        private static void CreateInterval(MemoryObject obj, int interval = 1)
        {
            var timer = new Timer(interval)
            {
                Enabled = true,
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

        private static void CheckMemoryForAbility(MemoryObject obj, int maxNumber, int toggleValue)
        {
            switch (obj.Address)
            {
                // Ability start location
                case 0x2032E074:

                    // TODO Update this because we don't use Console.Write
                    if (memoryProcessor.UpdateAbilityMemory(obj, maxNumber, toggleValue))
                        Console.WriteLine($"{obj.Name} updated to {obj.Value} - Type: {obj.Type} - Address: {obj.Address}");
                    else
                        Console.WriteLine($"{obj.Name} Failed to update to {obj.Value} - Address: {obj.Address}");

                    break;
                default:
                    break;
            }
        }
    }
}