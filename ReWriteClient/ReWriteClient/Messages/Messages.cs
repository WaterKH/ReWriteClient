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

        private static Messages instance;
        public static Messages Instance { get; set; } = instance ?? new Messages();

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
                    { "SendSoraHealthTimerMessage", SendSoraHealthTimerMessage },
                    { "SendSoraCurrentMagicMessage", SendSoraCurrentMagicMessage },
                    { "SendSoraMaxMagicMessage", SendSoraMaxMagicMessage },
                    { "SendSoraMagicTimerMessage", SendSoraMagicTimerMessage },
                    { "SendSoraStrengthStatMessage", SendSoraStrengthStatMessage },
                    { "SendSoraMagicStatMessage", SendSoraMagicStatMessage },
                    { "SendSoraDefenseStatMessage", SendSoraDefenseStatMessage },
                    { "SendSoraAPBoostMessage", SendSoraAPBoostMessage },
                    { "SendSoraStrengthBoostMessage", SendSoraStrengthBoostMessage },
                    { "SendSoraMagicBoostMessage", SendSoraMagicBoostMessage },
                    { "SendSoraDefenseBoostMessage", SendSoraDefenseBoostMessage },
                    { "SendSoraSpeedMessage", SendSoraSpeedMessage },

                    #endregion Stats

                    #region Magic

                    { "SendSoraRechargeMagicMessage", SendSoraRechargeMagicMessage },
                    { "SendFireMagicMessage", SendFireMagicMessage },
                    { "SendBlizzardMagicMessage", SendBlizzardMagicMessage },
                    { "SendThunderMagicMessage", SendThunderMagicMessage },
                    { "SendCureMagicMessage", SendCureMagicMessage },
                    { "SendMagnetMagicMessage", SendMagnetMagicMessage },
                    { "SendReflectMagicMessage", SendReflectMagicMessage },

                    #region Cost

                    #region Spells

                    { "SendRandomizeMagicCostMessage", SendRandomizeMagicCostMessage },
                    { "SendFireMagicCostMessage", SendFireMagicCostMessage },
                    { "SendBlizzardMagicCostMessage", SendBlizzardMagicCostMessage },
                    { "SendThunderMagicCostMessage", SendThunderMagicCostMessage },
                    { "SendCureMagicCostMessage", SendCureMagicCostMessage },
                    { "SendMagnetMagicCostMessage", SendMagnetMagicCostMessage },
                    { "SendReflectMagicCostMessage", SendReflectMagicCostMessage },
                
                    #endregion Spells

                    #region Limits

                    { "SendTrinityLimitMagicCostMessage", SendTrinityLimitMagicCostMessage },
                    { "SendDuckFlareMagicCostMessage", SendDuckFlareMagicCostMessage },
                    { "SendCometMagicCostMessage", SendCometMagicCostMessage },
                    { "SendWhirliGoofMagicCostMessage", SendWhirliGoofMagicCostMessage },
                    { "SendKnocksmashMagicCostMessage", SendKnocksmashMagicCostMessage },
                    { "SendRedRocketMagicCostMessage", SendRedRocketMagicCostMessage },
                    { "SendTwinHowlMagicCostMessage", SendTwinHowlMagicCostMessage },
                    { "SendBushidoMagicCostMessage", SendBushidoMagicCostMessage },
                    { "SendBluffMagicCostMessage", SendBluffMagicCostMessage },
                    { "SendDanceCallMagicCostMessage", SendDanceCallMagicCostMessage },
                    { "SendSpeedsterMagicCostMessage", SendSpeedsterMagicCostMessage },
                    { "SendWildcatMagicCostMessage", SendWildcatMagicCostMessage },
                    { "SendSetupMagicCostMessage", SendSetupMagicCostMessage },
                    { "SendSessionMagicCostMessage", SendSessionMagicCostMessage },

                    #endregion Limits

                    #region Limit Form
                    
                    { "SendStrikeRaidCostMessage", SendStrikeRaidMagicCostMessage },
                    { "SendSonicBladeMagicCostMessage", SendSonicBladeMagicCostMessage },
                    { "SendRagnarokMagicCostMessage", SendRagnarokMagicCostMessage },
                    { "SendArsArcanumMagicCostMessage", SendArsArcanumMagicCostMessage },

                    #endregion Limit Form

                    #endregion Cost

                    #endregion Magic

                    #region Drive

                    { "SendCurrentDriveCounterMessage", SendCurrentDriveCounterMessage },
                    { "SendMaxDriveCounterMessage", SendMaxDriveCounterMessage },
                    { "SendDriveTimeMessage", SendDriveTimeMessage },
                    { "SendDisableDriveMessage", SendDisableDriveMessage },
                    { "SendValorWisdomMasterFinalAntiMessage", SendValorWisdomMasterFinalAntiMessage },
                    { "SendLimitMessage", SendLimitMessage },
                    { "SendAllDriveFormsMessage", SendAllDriveFormsMessage },
                    { "SendActivateFormMessage", SendActivateFormMessage },

                    #endregion Drive

                    #region Summon
                    
                    { "SendUkuleleBaseballMessage", SendUkuleleBaseballMessage },
                    { "SendLampFeatherMessage", SendLampFeatherMessage },

                    #endregion Summon

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

                    #region Quick Menu

                    { "SendSoraQuickMenuSlot1Message", SendSoraQuickMenuSlot1Message },
                    { "SendSoraQuickMenuSlot2Message", SendSoraQuickMenuSlot2Message },
                    { "SendSoraQuickMenuSlot3Message", SendSoraQuickMenuSlot3Message },
                    { "SendSoraQuickMenuSlot4Message", SendSoraQuickMenuSlot4Message },

                    #endregion Quick Menu

                    #region Abilities

                    { "SendSoraActivateAbilityMessage", SendSoraActivateAbilityMessage },
                    { "SendSoraDeactivateAbilityMessage", SendSoraDeactivateAbilityMessage },

                #endregion Abilities

                }
            },

            #endregion Sora

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

                    
                    { "SendMunnyMessage", SendMunnyMessage },
                }
            },

            #endregion Items

            #region Model Swap
            
            { "ModelSwap", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendResetModelSwapsMessage", SendResetModelSwapsMessage },

                    { "SendSoraModelMessage", SendSoraModelMessage },
                    { "SendSoraLionModelMessage", SendSoraLionModelMessage },
                    { "SendSoraTimelessRiverModelMessage", SendSoraTimelessRiverModelMessage },
                    { "SendSoraHalloweenModelMessage", SendSoraHalloweenModelMessage },
                    { "SendSoraChristmasModelMessage", SendSoraChristmasModelMessage },
                    { "SendSoraSpaceParanoidsModelMessage", SendSoraSpaceParanoidsModelMessage },

                    { "SendSoraValorFormModelMessage", SendSoraValorFormModelMessage },
                    { "SendSoraWisdomFormModelMessage", SendSoraWisdomFormModelMessage },
                    { "SendSoraLimitFormModelMessage", SendSoraLimitFormModelMessage },
                    { "SendSoraMasterFormModelMessage", SendSoraMasterFormModelMessage },
                    { "SendSoraFinalFormModelMessage", SendSoraFinalFormModelMessage },
                    { "SendSoraAntiFormModelMessage", SendSoraAntiFormModelMessage },

                    { "SendDonaldModelMessage", SendDonaldModelMessage },
                    { "SendGoofyModelMessage", SendGoofyModelMessage },

                    { "SendHalloweenGoofyModelMessage", SendHalloweenGoofyModelMessage },
                    { "SendChristmasGoofyModelMessage", SendChristmasGoofyModelMessage },
                    { "SendTortoiseGoofyModelMessage", SendTortoiseGoofyModelMessage },
                    { "SendSpaceParanoidsGoofyModelMessage", SendSpaceParanoidsGoofyModelMessage },
                    { "SendTimelessRiverGoofyModelMessage", SendTimelessRiverGoofyModelMessage },
                    
                    { "SendHalloweenDonaldModelMessage", SendHalloweenDonaldModelMessage },
                    { "SendChristmasDonaldModelMessage", SendChristmasDonaldModelMessage },
                    { "SendBirdDonaldModelMessage", SendBirdDonaldModelMessage },
                    { "SendSpaceParanoidsDonaldModelMessage", SendSpaceParanoidsDonaldModelMessage },
                    { "SendTimelessRiverDonaldModelMessage", SendTimelessRiverDonaldModelMessage },
                    
                    { "SendMulanModelMessage", SendMulanModelMessage },
                    { "SendBeastModelMessage", SendBeastModelMessage },
                    { "SendAuronModelMessage", SendAuronModelMessage },
                    { "SendCaptainJackSparrowModelMessage", SendCaptainJackSparrowModelMessage },
                    { "SendAladdinModelMessage", SendAladdinModelMessage },
                    { "SendJackSkellingtonModelMessage", SendJackSkellingtonModelMessage },
                    { "SendSimbaModelMessage", SendSimbaModelMessage },
                    { "SendTronModelMessage", SendTronModelMessage },
                    { "SendRikuModelMessage", SendRikuModelMessage },
                }
            },

            #endregion Model Swap

            #region Party

            { "Party", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    #region Donald

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

                    #region Abilities

                    { "SendDonaldActivateAbilityMessage", SendDonaldActivateAbilityMessage },
                    { "SendDonaldDeactivateAbilityMessage", SendDonaldDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Donald

                    #region Goofy

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

                    #region Abilities

                    { "SendGoofyActivateAbilityMessage", SendGoofyActivateAbilityMessage },
                    { "SendGoofyDeactivateAbilityMessage", SendGoofyDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Goofy

                    #region Mulan

                    #region Weapons


                    #endregion Weapons

                    #region Armor

                    { "SendMulanArmorSlotsMessage", SendMulanArmorSlotsMessage },
                    { "SendMulanArmorSlot1Message", SendMulanArmorSlot1Message },

                    #endregion Armor

                    #region Accessories

                    { "SendMulanAccessorySlotsMessage", SendMulanAccessorySlotsMessage },
                    { "SendMulanAccessorySlot1Message", SendMulanAccessorySlot1Message },

                    #endregion Accessories

                    #region Items

                    { "SendMulanItemSlotsMessage", SendMulanItemSlotsMessage },
                    { "SendMulanItemSlot1Message", SendMulanItemSlot1Message },
                    { "SendMulanItemSlot2Message", SendMulanItemSlot2Message },
                    { "SendMulanItemSlot3Message", SendMulanItemSlot3Message },

                    #endregion Items

                    #region Abilities

                    { "SendMulanActivateAbilityMessage", SendMulanActivateAbilityMessage },
                    { "SendMulanDeactivateAbilityMessage", SendMulanDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Mulan

                    #region Beast

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    #endregion Armor

                    #region Accessories

                    { "SendBeastAccessorySlotsMessage", SendBeastAccessorySlotsMessage },
                    { "SendBeastAccessorySlot1Message", SendBeastAccessorySlot1Message },

                    #endregion Accessories

                    #region Items

                    { "SendBeastItemSlotsMessage", SendBeastItemSlotsMessage },
                    { "SendBeastItemSlot1Message", SendBeastItemSlot1Message },
                    { "SendBeastItemSlot2Message", SendBeastItemSlot2Message },
                    { "SendBeastItemSlot3Message", SendBeastItemSlot3Message },
                    { "SendBeastItemSlot4Message", SendBeastItemSlot4Message },

                    #endregion Items

                    #region Abilities

                    { "SendBeastActivateAbilityMessage", SendBeastActivateAbilityMessage },
                    { "SendBeastDeactivateAbilityMessage", SendBeastDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Beast

                    #region Auron

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    { "SendAuronArmorSlotsMessage", SendAuronArmorSlotsMessage },
                    { "SendAuronArmorSlot1Message", SendAuronArmorSlot1Message },

                    #endregion Armor

                    #region Accessories

                    #endregion Accessories

                    #region Items

                    { "SendAuronItemSlotsMessage", SendAuronItemSlotsMessage },
                    { "SendAuronItemSlot1Message", SendAuronItemSlot1Message },
                    { "SendAuronItemSlot2Message", SendAuronItemSlot2Message },

                    #endregion Items

                    #region Abilities

                    { "SendAuronActivateAbilityMessage", SendAuronActivateAbilityMessage },
                    { "SendAuronDeactivateAbilityMessage", SendAuronDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Auron

                    #region Captain Jack Sparrow

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    { "SendCaptainJackSparrowArmorSlotsMessage", SendCaptainJackSparrowArmorSlotsMessage },
                    { "SendCaptainJackSparrowArmorSlot1Message", SendCaptainJackSparrowArmorSlot1Message },
                    
                    #endregion Armor

                    #region Accessories

                    { "SendCaptainJackSparrowAccessorySlotsMessage", SendCaptainJackSparrowAccessorySlotsMessage },
                    { "SendCaptainJackSparrowAccessorySlot1Message", SendCaptainJackSparrowAccessorySlot1Message },
                    
                    #endregion Accessories

                    #region Items

                    { "SendCaptainJackSparrowItemSlotsMessage", SendCaptainJackSparrowItemSlotsMessage },
                    { "SendCaptainJackSparrowItemSlot1Message", SendCaptainJackSparrowItemSlot1Message },
                    { "SendCaptainJackSparrowItemSlot2Message", SendCaptainJackSparrowItemSlot2Message },
                    { "SendCaptainJackSparrowItemSlot3Message", SendCaptainJackSparrowItemSlot3Message },
                    { "SendCaptainJackSparrowItemSlot4Message", SendCaptainJackSparrowItemSlot4Message },

                    #endregion Items

                    #region Abilities

                    { "SendCaptainJackSparrowActivateAbilityMessage", SendCaptainJackSparrowActivateAbilityMessage },
                    { "SendCaptainJackSparrowDeactivateAbilityMessage", SendCaptainJackSparrowDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Captain Jack Sparrow

                    #region Aladdin

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    { "SendAladdinArmorSlotsMessage", SendAladdinArmorSlotsMessage },
                    { "SendAladdinArmorSlot1Message", SendAladdinArmorSlot1Message },
                    { "SendAladdinArmorSlot2Message", SendAladdinArmorSlot2Message },

                    #endregion Armor

                    #region Accessories

                    #endregion Accessories

                    #region Items

                    { "SendAladdinItemSlotsMessage", SendAladdinItemSlotsMessage },
                    { "SendAladdinItemSlot1Message", SendAladdinItemSlot1Message },
                    { "SendAladdinItemSlot2Message", SendAladdinItemSlot2Message },
                    { "SendAladdinItemSlot3Message", SendAladdinItemSlot3Message },
                    { "SendAladdinItemSlot4Message", SendAladdinItemSlot4Message },
                    { "SendAladdinItemSlot5Message", SendAladdinItemSlot5Message },

                    #endregion Items

                    #region Abilities

                    { "SendAladdinActivateAbilityMessage", SendAladdinActivateAbilityMessage },
                    { "SendAladdinDeactivateAbilityMessage", SendAladdinDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Aladdin

                    #region Jack Skellington

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    #endregion Armor

                    #region Accessories

                    { "SendJackSkellingtonAccessorySlotsMessage", SendJackSkellingtonAccessorySlotsMessage },
                    { "SendJackSkellingtonAccessorySlot1Message", SendJackSkellingtonAccessorySlot1Message },
                    { "SendJackSkellingtonAccessorySlot2Message", SendJackSkellingtonAccessorySlot2Message },

                    #endregion Accessories

                    #region Items

                    { "SendJackSkellingtonItemSlotsMessage", SendJackSkellingtonItemSlotsMessage },
                    { "SendJackSkellingtonItemSlot1Message", SendJackSkellingtonItemSlot1Message },
                    { "SendJackSkellingtonItemSlot2Message", SendJackSkellingtonItemSlot2Message },
                    { "SendJackSkellingtonItemSlot3Message", SendJackSkellingtonItemSlot3Message },

                    #endregion Items

                    #region Abilities

                    { "SendJackSkellingtonActivateAbilityMessage", SendJackSkellingtonActivateAbilityMessage },
                    { "SendJackSkellingtonDeactivateAbilityMessage", SendJackSkellingtonDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Jack Skellington

                    #region Simba

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    #endregion Armor

                    #region Accessories

                    { "SendSimbaAccessorySlotsMessage", SendSimbaAccessorySlotsMessage },
                    { "SendSimbaAccessorySlot1Message", SendSimbaAccessorySlot1Message },
                    { "SendSimbaAccessorySlot2Message", SendSimbaAccessorySlot2Message },

                    #endregion Accessories

                    #region Items

                    { "SendSimbaItemSlotsMessage", SendSimbaItemSlotsMessage },
                    { "SendSimbaItemSlot1Message", SendSimbaItemSlot1Message },
                    { "SendSimbaItemSlot2Message", SendSimbaItemSlot2Message },
                    { "SendSimbaItemSlot3Message", SendSimbaItemSlot3Message },

                    #endregion Items

                    #region Abilities

                    { "SendSimbaActivateAbilityMessage", SendSimbaActivateAbilityMessage },
                    { "SendSimbaDeactivateAbilityMessage", SendSimbaDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Simba

                    #region Tron

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    { "SendTronArmorSlotsMessage", SendTronArmorSlotsMessage },
                    { "SendTronArmorSlot1Message", SendTronArmorSlot1Message },

                    #endregion Armor

                    #region Accessories

                    { "SendTronAccessorySlotsMessage", SendTronAccessorySlotsMessage },
                    { "SendTronAccessorySlot1Message", SendTronAccessorySlot1Message },

                    #endregion Accessories

                    #region Items

                    { "SendTronItemSlotsMessage", SendTronItemSlotsMessage },
                    { "SendTronItemSlot1Message", SendTronItemSlot1Message },
                    { "SendTronItemSlot2Message", SendTronItemSlot2Message },

                    #endregion Items

                    #region Abilities

                    { "SendTronActivateAbilityMessage", SendTronActivateAbilityMessage },
                    { "SendTronDeactivateAbilityMessage", SendTronDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Tron

                    #region Riku

                    #region Weapons

                    #endregion Weapons

                    #region Armor

                    { "SendRikuArmorSlotsMessage", SendRikuArmorSlotsMessage },
                    { "SendRikuArmorSlot1Message", SendRikuArmorSlot1Message },
                    { "SendRikuArmorSlot2Message", SendRikuArmorSlot2Message },

                    #endregion Armor

                    #region Accessories

                    { "SendRikuAccessorySlotsMessage", SendRikuAccessorySlotsMessage },
                    { "SendRikuAccessorySlot1Message", SendRikuAccessorySlot1Message },

                    #endregion Accessories

                    #region Items

                    { "SendRikuItemSlotsMessage", SendRikuItemSlotsMessage },
                    { "SendRikuItemSlot1Message", SendRikuItemSlot1Message },
                    { "SendRikuItemSlot2Message", SendRikuItemSlot2Message },
                    { "SendRikuItemSlot3Message", SendRikuItemSlot3Message },
                    { "SendRikuItemSlot4Message", SendRikuItemSlot4Message },
                    { "SendRikuItemSlot5Message", SendRikuItemSlot5Message },
                    { "SendRikuItemSlot6Message", SendRikuItemSlot6Message },

                    #endregion Items

                    #region Abilities
                    
                    { "SendRikuActivateAbilityMessage", SendRikuActivateAbilityMessage },
                    { "SendRikuDeactivateAbilityMessage", SendRikuDeactivateAbilityMessage },

                    #endregion Abilities

                    #endregion Riku
                }
            },

            #endregion Party

            #region Enemy

            { "Enemy", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendBossChangeMessage", SendBossChangeMessage },    

                    #region Timers
                
                    { "SendBossActivateHealthTimerMessage", SendBossActivateHealthTimerMessage },
                    { "SendBossDeactivateHealthTimerMessage", SendBossDeactivateHealthTimerMessage },
                    { "SendBossActivateStrengthTimerMessage", SendBossActivateStrengthTimerMessage },
                    { "SendBossDeactivateStrengthTimerMessage", SendBossDeactivateStrengthTimerMessage },
                    { "SendBossActivateDefenseTimerMessage", SendBossActivateDefenseTimerMessage },
                    { "SendBossDeactivateDefenseTimerMessage", SendBossDeactivateDefenseTimerMessage },

                    #endregion Timers

                    #region Set Changes
                    
                    { "SendBossMaxHealthChangeMessage", SendBossMaxHealthChangeMessage },
                    { "SendBossHealthChangeMessage", SendBossHealthChangeMessage },
                    { "SendBossStrengthChangeMessage", SendBossStrengthChangeMessage },
                    { "SendBossDefenseChangeMessage", SendBossDefenseChangeMessage },

                    #endregion Set Changes
                }
            },

            #endregion Enemy

            #region Environment

            { "Environment", new Dictionary<string, Func<ManipulationType, string, bool>>
                {
                    { "SendRoomChangeMessage", SendRoomChangeMessage },    
                }
            },

            #endregion Environment
        };

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
    }
}