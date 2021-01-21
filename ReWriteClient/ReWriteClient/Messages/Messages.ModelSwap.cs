using ReWriteClient.Data;
using ReWriteClient.Enums;
using System;
using System.Timers;
using Waterkh.Common.Memory;

namespace ReWriteClient.Messages
{
    public partial class Messages
    {
        #region Timers

        public static Timer SoraModelTimer = new Timer
        {
            AutoReset = false,
            Interval = 45000
        };

        public static Timer DonaldModelTimer = new Timer
        {
            AutoReset = false,
            Interval = 45000
        };

        public static Timer GoofyModelTimer = new Timer
        {
            AutoReset = false,
            Interval = 45000,
        };

        public static Timer PartyModelTimer = new Timer 
        {
            AutoReset = false,
            Interval = 45000,
        };

        #endregion Timers

        public static bool SendResetModelSwapsMessage(ManipulationType manipulationType, string value)
        {
            try
            {
                #region Sora

                SendSoraModelMessage(manipulationType, "84");
                SendSoraLionModelMessage(manipulationType, "650");
                SendSoraTimelessRiverModelMessage(manipulationType, "1623");
                SendSoraHalloweenModelMessage(manipulationType, "693");
                SendSoraChristmasModelMessage(manipulationType, "2389");
                SendSoraSpaceParanoidsModelMessage(manipulationType, "1622");

                #endregion Sora

                #region Donald

                SendDonaldModelMessage(manipulationType, "92");
                SendBirdDonaldModelMessage(manipulationType, "1519");
                SendTimelessRiverDonaldModelMessage(manipulationType, "1487");
                SendHalloweenDonaldModelMessage(manipulationType, "670");
                SendChristmasDonaldModelMessage(manipulationType, "2395");
                SendSpaceParanoidsDonaldModelMessage(manipulationType, "1370");

                #endregion Donald

                #region Goofy

                SendGoofyModelMessage(manipulationType, "93");
                SendTortoiseGoofyModelMessage(manipulationType, "1563");
                SendTimelessRiverGoofyModelMessage(manipulationType, "1269");
                SendHalloweenGoofyModelMessage(manipulationType, "669");
                SendChristmasGoofyModelMessage(manipulationType, "2396");
                SendSpaceParanoidsGoofyModelMessage(manipulationType, "1364");

                #endregion Goofy

                #region Party

                SendMulanModelMessage(manipulationType, "99");
                ClientCache.Instance.MulanModel = string.Empty; // Is this needed?
                SendBeastModelMessage(manipulationType, "94");
                SendAuronModelMessage(manipulationType, "101");
                SendAladdinModelMessage(manipulationType, "98");
                SendJackSkellingtonModelMessage(manipulationType, "96");
                ClientCache.Instance.JackSkellingtonModel = ""; // Is this needed?
                SendSimbaModelMessage(manipulationType, "97");
                SendTronModelMessage(manipulationType, "724");
                SendRikuModelMessage(manipulationType, "2073");

                #endregion Party
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "SendResetModelSwapsMessage");

                return false;
            }

            return true;
        }

        #region Helper Functions

        public static void SetupModelTimer(Timer timer, int address, string value, string cacheName)
        {
            timer.Stop();
            timer.Dispose();

            timer = new Timer
            {
                AutoReset = false,
                Interval = 45000
            };

            // TODO is there a way to unsubscribe from an Elapsed event? Or delete all Events subscribed?
            timer.Elapsed += (sender, obj) =>
            {
                SetCache(cacheName, value);

                memoryProcessor.UpdateMemory(new MemoryObject
                {
                    Address = address,
                    Type = DataType.TwoBytes,
                    ManipulationType = ManipulationType.Set,
                    Value = value // TODO Update this with Character mappings later
                });
            };

            timer.Start();
        }

        public static void SetCache(string cacheName, string value)
        {
            switch (cacheName)
            {
                #region Sora

                case "Sora": ClientCache.Instance.SoraModel = value; break;
                case "LionSora": ClientCache.Instance.SoraLionModel = value; break;
                case "TimelessSora": ClientCache.Instance.SoraTimelessRiverModel = value; break;
                case "HalloweenSora": ClientCache.Instance.SoraHalloweenModel = value; break;
                case "ChristmasSora": ClientCache.Instance.SoraChristmasModel = value; break;
                case "SpaceSora": ClientCache.Instance.SoraSpaceParanoidsModel = value; break;

                #endregion Sora

                #region Donald

                case "Donald": ClientCache.Instance.DonaldModel = value; break;
                case "BirdDonald": ClientCache.Instance.DonaldBirdModel = value; break;
                case "TimelessDonald": ClientCache.Instance.DonaldTimelessRiverModel = value; break;
                case "HalloweenDonald": ClientCache.Instance.DonaldHalloweenModel = value; break;
                case "ChristmasDonald": ClientCache.Instance.DonaldChristmasModel = value; break;
                case "SpaceDonald": ClientCache.Instance.DonaldSpaceParanoidsModel = value; break;

                #endregion Donald

                #region Goofy

                case "Goofy": ClientCache.Instance.GoofyModel = value; break;
                case "TortoiseGoofy": ClientCache.Instance.GoofyTortoiseModel = value; break;
                case "TimelessGoofy": ClientCache.Instance.GoofyTimelessRiverModel = value; break;
                case "HalloweenGoofy": ClientCache.Instance.GoofyHalloweenModel = value; break;
                case "ChristmasGoofy": ClientCache.Instance.GoofyChristmasModel = value; break;
                case "SpaceGoofy": ClientCache.Instance.GoofySpaceParanoidsModel = value; break;

                #endregion Goofy

                #region Party

                case "Mulan": ClientCache.Instance.MulanModel = value; break;
                case "Beast": ClientCache.Instance.BeastModel = value; break;
                case "Auron": ClientCache.Instance.AuronModel = value; break;
                case "Sparrow": ClientCache.Instance.CaptainJackSparrowModel = value; break;
                case "Aladdin": ClientCache.Instance.AladdinModel = value; break;
                case "Skellington": ClientCache.Instance.JackSkellingtonModel = value; break;
                case "Simba": ClientCache.Instance.SimbaModel = value; break;
                case "Tron": ClientCache.Instance.TronModel = value; break;
                case "Riku": ClientCache.Instance.RikuModel = value; break;

                #endregion Party

                default: break;
            }
        }

        #endregion Helper Functions
    }
}