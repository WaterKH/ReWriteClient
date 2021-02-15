using ReWriteClient.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Waterkh.Common.Mappings;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public class MemoryProcessor
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        public static MemoryProcessor Instance { get; set; } = new MemoryProcessor();

        public Process Process;
        private IntPtr ProcessHandle;

        private Random random = new Random();
        private List<string> allies = new List<string> { "92", "1519", "93", "1563", "2073", "1244", "1564", "1712", "1715", "1672", "94", "100", "99", "101", "98", "102", "95", "96", "97", "724", "362", "1211" };
        private List<string> enemies = new List<string> { "2296", "2299", "2298", "2297", "2079", "1570", "997", "2355", "2356", "2357", "2427", "1737", "81", "795", "2294", "1528", "2339", "2402", "2385", "1876", "2998", "2415" };

        private MemoryProcessor()
        { }

        public bool ConnectToProcess()
        {
            try
            {
                Process = Process.GetProcessesByName("pcsx2")[0];
                ProcessHandle = OpenProcess(0x001F0FFF, false, Process.Id);

                Process.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "ConnectToProcess");

                return false;
            }

            return true;
        }

        public bool UpdateMemory(MemoryObject obj)
        {
            if (ProcessHandle == IntPtr.Zero)
                return false;

            // TODO Add it a queue
            // TODO Send a queue loaded message
            // TODO In the message sent, check the memory addresses for cutscene/ room transition and keep checking until it's able to

            try
            {
                byte[] data;

                data = ConvertToBytes(obj.Type, obj.Value, obj.IsValueHex);

                byte[] readMemory = new byte[data.Length];

                switch (obj.ManipulationType)
                {
                    case ManipulationType.Set:
                        break;
                    case ManipulationType.Add:

                        ReadProcessMemory(ProcessHandle, (IntPtr)obj.Address, readMemory, data.Length, out _);

                        data = this.AddBytes(obj.Type, readMemory, data);

                        break;
                    case ManipulationType.Subtract:

                        ReadProcessMemory(ProcessHandle, (IntPtr)obj.Address, readMemory, data.Length, out _);

                        data = this.SubtractBytes(obj.Type, readMemory, data);

                        break;
                }

                WriteProcessMemory(ProcessHandle, (IntPtr)obj.Address, data, data.Length, out _);
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "UpdateMemory");

                return false;
            }

            return true;
        }

        public bool UpdateAbilityMemory(MemoryObject obj, int maxNumber, int toggleValue, int abilitySlots)
        {
            if (ProcessHandle == IntPtr.Zero)
                return false;

            int firstInstance = 0;
            int lastReference = 0;
            int currNumber = 0;
            byte[] data;

            data = new byte[] { byte.Parse(int.Parse(obj.Value).ToString()) };

            byte[] readMemory = new byte[data.Length];

            for (int i = 0; i < abilitySlots; i += 2)
            {
                if (i != 0)
                    obj.Address += 2;


                ReadProcessMemory(ProcessHandle, (IntPtr)obj.Address, readMemory, data.Length, out _);

                switch (obj.ManipulationType)
                {
                    case ManipulationType.Set:
                        break;
                    case ManipulationType.Add:

                        data = this.AddBytes(obj.Type, readMemory, data);

                        break;
                    case ManipulationType.Subtract:

                        data = this.SubtractBytes(obj.Type, readMemory, data);

                        break;
                }

                if (firstInstance == 0 && readMemory[0] == 0)
                {
                    firstInstance = obj.Address;
                }
                else if (readMemory[0] == data[0])
                {
                    lastReference = obj.Address;

                    if (maxNumber == currNumber)
                        break;

                    ++currNumber;
                }
            }

            if (toggleValue == 0)
                data = new byte[] { 0 };

            if (firstInstance != 0 && currNumber < maxNumber)
            {
                WriteProcessMemory(ProcessHandle, (IntPtr)firstInstance, data, data.Length, out _);
                WriteProcessMemory(ProcessHandle, (IntPtr)(firstInstance + 1), new byte[] { byte.Parse(toggleValue.ToString()) }, data.Length, out _);

                return true;
            }
            else if (lastReference != 0)
            {
                WriteProcessMemory(ProcessHandle, (IntPtr)lastReference, data, data.Length, out _);
                WriteProcessMemory(ProcessHandle, (IntPtr)(lastReference + 1), new byte[] { byte.Parse(toggleValue.ToString()) }, data.Length, out _);

                return true;
            }

            return false;
        }

        public bool UpdateEntitySlotMemory(MemoryObject obj, bool isHealth)
        {
            try
            {
                if (ProcessHandle == IntPtr.Zero)
                    return false;

                byte[] data;

                byte[] readMemory = isHealth ? new byte[8] : new byte[2];

                ReadProcessMemory(ProcessHandle, (IntPtr)obj.Address, readMemory, readMemory.Length, out _);

                if (isHealth)
                {
                    data = readMemory[^4..];

                    WriteProcessMemory(ProcessHandle, (IntPtr)obj.Address, data, data.Length, out _);
                }
                else
                {
                    data = ConvertToBytes(obj.Type, obj.Value, obj.IsValueHex);

                    WriteProcessMemory(ProcessHandle, (IntPtr)obj.Address, data, data.Length, out _);
                }

                return true;
            }
            catch(Exception e)
            {
                Logger.Instance.Error(e.Message, "UpdateEntitySlotMemory");

                return false;
            }
        }

        public bool UpdateSoraMemory(MemoryObject obj)
        {
            try
            {
                if (ProcessHandle == IntPtr.Zero)
                    return false;

                byte[] readMemory = new byte[4];

                ReadProcessMemory(ProcessHandle, (IntPtr)obj.Address, readMemory, readMemory.Length, out _);

                byte[] data = this.SubtractBytes(DataType.FourBytes, readMemory, new byte[4] { 1, 0, 0, 0 });

                if (data[0] == 0 && data[1] == 0 && data[2] == 0 && data[3] == 0)
                    data = new byte[4] { 1, 0, 0, 0 };

                WriteProcessMemory(ProcessHandle, (IntPtr)obj.Address, data, data.Length, out _);
                
                return true;
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "UpdateSoraMemory");

                return false;
            }
        }

        public void CheckForEvent()
        {
            try
            {
                if (ProcessHandle == IntPtr.Zero)
                    return;

                byte[] world = new byte[1];
                byte[] room = new byte[1];

                ReadProcessMemory(ProcessHandle, (IntPtr)0x2032BAE0, world, 1, out _);
                ReadProcessMemory(ProcessHandle, (IntPtr)0x2032BAE1, room, 1, out _);

                EventMapping.Instance.Events.TryGetValue((int)world[0], out var rooms);

                if (rooms == null)
                    return;

                rooms.TryGetValue((int)room[0], out var values);

                if (values == null)
                    return;

                byte[] event1 = new byte[1];
                byte[] event2 = new byte[1];
                byte[] event3 = new byte[1];

                ReadProcessMemory(ProcessHandle, (IntPtr)0x2032BAE4, event1, 1, out _);
                ReadProcessMemory(ProcessHandle, (IntPtr)0x2032BAE6, event2, 1, out _);
                ReadProcessMemory(ProcessHandle, (IntPtr)0x2032BAE8, event3, 1, out _);

                bool isEvent = false;

                foreach (var value in values)
                {
                    if (value.Count == 1)
                    {
                        // event 3
                        if (isEvent = (value[0] == (int)event3[0]))
                            break;
                    }
                    else if (value.Count == 2)
                    {
                        // event 2, event 3
                        if (isEvent = (value[0] == (int)event2[0] && value[1] == (int)event3[0]))
                            break;
                    }
                    else if (value.Count == 3)
                    {
                        // event 1, event 2, event 3
                        if (isEvent = (value[0] == (int)event1[0] && value[1] == (int)event2[0] && value[2] == (int)event3[0]))
                            break;
                    }
                }

                //var isEvent = values.Item1 == (int)event1[0] && values.Item2 == (int)event2[0] && values.Item3 == (int)event3[0];

                // TODO Is there a better way to do this?
                // TODO boss fights trigger this too - within same room/ world
                if (ClientCache.Instance.CurrentWorld != (int)world[0] || ClientCache.Instance.CurrentRoom != (int)room[0])
                {
                    ClientCache.Instance.CurrentWorld = (int)world[0];
                    ClientCache.Instance.CurrentRoom = (int)room[0];

                    #region Model Swaps

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B68,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "84" : (string.IsNullOrEmpty(ClientCache.Instance.SoraModel)) ? "84" : ClientCache.Instance.SoraModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B6A,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "92" : (string.IsNullOrEmpty(ClientCache.Instance.DonaldModel)) ? "92" : 
                                    ClientCache.Instance.DonaldModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.DonaldModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.DonaldModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B6C,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "93" : (string.IsNullOrEmpty(ClientCache.Instance.GoofyModel)) ? "93" :
                                    ClientCache.Instance.GoofyModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.GoofyModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.GoofyModel
                    });

                    #region Forms

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B70,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "85" : (string.IsNullOrEmpty(ClientCache.Instance.SoraValorFormModel)) ? "85" : ClientCache.Instance.SoraValorFormModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B72,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "86" : (string.IsNullOrEmpty(ClientCache.Instance.SoraWisdomFormModel)) ? "86" : ClientCache.Instance.SoraWisdomFormModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B74,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "2397" : (string.IsNullOrEmpty(ClientCache.Instance.SoraLimitFormModel)) ? "2397" : ClientCache.Instance.SoraLimitFormModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B76,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "87" : (string.IsNullOrEmpty(ClientCache.Instance.SoraMasterFormModel)) ? "87" : ClientCache.Instance.SoraMasterFormModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B78,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "88" : (string.IsNullOrEmpty(ClientCache.Instance.SoraFinalFormModel)) ? "88" : ClientCache.Instance.SoraFinalFormModel
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21CE0B7A,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = isEvent ? "89" : (string.IsNullOrEmpty(ClientCache.Instance.SoraAntiFormModel)) ? "89" : ClientCache.Instance.SoraAntiFormModel
                    });

                    #endregion Forms

                    switch (world[0])
                    {
                        case 2: // Twilight Town

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE0B68,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "90" : (string.IsNullOrEmpty(ClientCache.Instance.SoraModel)) ? "90" : ClientCache.Instance.SoraModel
                            });

                            break;

                        case 5: // Beast's Castle

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE104E,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "94" : (string.IsNullOrEmpty(ClientCache.Instance.BeastModel)) ? "94" :
                                    ClientCache.Instance.BeastModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.BeastModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.BeastModel
                            });

                            break;

                        case 6: // Olympus Coliseum

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE0EE2,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "101" : (string.IsNullOrEmpty(ClientCache.Instance.AuronModel)) ? "101" :
                                    ClientCache.Instance.AuronModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.AuronModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.AuronModel
                            });

                            break;

                        case 7: // Agrabah

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE0F7E,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "98" : (string.IsNullOrEmpty(ClientCache.Instance.AladdinModel)) ? "98" :
                                    ClientCache.Instance.AladdinModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.AladdinModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.AladdinModel
                            });

                            break;

                        case 8: // The Land of Dragons

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE10B6,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "100" : (string.IsNullOrEmpty(ClientCache.Instance.MulanModel)) ? "100" :
                                    ClientCache.Instance.MulanModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.MulanModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.MulanModel
                            });

                            break;

                        case 10: // Pride Lands

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE1250,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "650" : (string.IsNullOrEmpty(ClientCache.Instance.SoraLionModel)) ? "650" : ClientCache.Instance.SoraLionModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE1252,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1519" : (string.IsNullOrEmpty(ClientCache.Instance.DonaldBirdModel)) ? "1519" :
                                    ClientCache.Instance.DonaldBirdModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.DonaldBirdModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.DonaldBirdModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE1254,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1563" : (string.IsNullOrEmpty(ClientCache.Instance.GoofyTortoiseModel)) ? "1563" :
                                    ClientCache.Instance.GoofyTortoiseModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.GoofyTortoiseModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.GoofyTortoiseModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE1256,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "97" : (string.IsNullOrEmpty(ClientCache.Instance.SimbaModel)) ? "97" :
                                    ClientCache.Instance.SimbaModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.SimbaModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.SimbaModel
                            });

                            break;
                        //case 11: // Atlantica

                        //    this.UpdateMemory(new MemoryObject
                        //    {
                        //        Address = 0x21C6CC20,
                        //        ManipulationType = ManipulationType.Set,
                        //        Type = DataType.TwoBytes,
                        //        Value = isEvent ? "" : MemoryCache.SoraModelSwap.ToString()
                        //    });

                        //    break;
                        case 13: // Timeless River

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE121C,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1623" : (string.IsNullOrEmpty(ClientCache.Instance.SoraTimelessRiverModel)) ? "1623" : ClientCache.Instance.SoraTimelessRiverModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE121E,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1487" : (string.IsNullOrEmpty(ClientCache.Instance.DonaldTimelessRiverModel)) ? "1487" :
                                    ClientCache.Instance.DonaldTimelessRiverModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.DonaldTimelessRiverModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.DonaldTimelessRiverModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE1220,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1269" : (string.IsNullOrEmpty(ClientCache.Instance.GoofyTimelessRiverModel)) ? "1269" :
                                    ClientCache.Instance.GoofyTimelessRiverModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.GoofyTimelessRiverModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.GoofyTimelessRiverModel
                            });

                            break;
                        case 14: // Halloween / Christmas Town

                            if (room[0] < 5)
                            {
                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FAC,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "693" : (string.IsNullOrEmpty(ClientCache.Instance.SoraHalloweenModel)) ? "693" : ClientCache.Instance.SoraHalloweenModel
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FAE,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "670" : (string.IsNullOrEmpty(ClientCache.Instance.DonaldHalloweenModel)) ? "670" :
                                        ClientCache.Instance.DonaldHalloweenModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.DonaldHalloweenModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.DonaldHalloweenModel
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FB0,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "669" : (string.IsNullOrEmpty(ClientCache.Instance.GoofyHalloweenModel)) ? "669" :
                                        ClientCache.Instance.GoofyHalloweenModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.GoofyHalloweenModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.GoofyHalloweenModel
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE101A,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "95" : (string.IsNullOrEmpty(ClientCache.Instance.JackSkellingtonModel)) ? "95" :
                                        ClientCache.Instance.JackSkellingtonModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.JackSkellingtonModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.JackSkellingtonModel
                                });
                            }
                            else
                            {
                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FE0,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "2389" : (string.IsNullOrEmpty(ClientCache.Instance.SoraChristmasModel)) ? "2389" : ClientCache.Instance.SoraChristmasModel
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FE2,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "2395" : (string.IsNullOrEmpty(ClientCache.Instance.DonaldChristmasModel)) ? "2395" :
                                        ClientCache.Instance.DonaldChristmasModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.DonaldChristmasModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.DonaldChristmasModel
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FE4,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "2396" : (string.IsNullOrEmpty(ClientCache.Instance.GoofyChristmasModel)) ? "2396" :
                                        ClientCache.Instance.GoofyChristmasModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.GoofyChristmasModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.GoofyChristmasModel
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE101A,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "96" : (string.IsNullOrEmpty(ClientCache.Instance.JackSkellingtonModel)) ? "96" :
                                        ClientCache.Instance.JackSkellingtonModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.JackSkellingtonModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.JackSkellingtonModel
                                });
                            }

                            break;
                        case 16: // Port Royal

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE0DDE,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "2077" : (string.IsNullOrEmpty(ClientCache.Instance.CaptainJackSparrowModel)) ? "2077" :
                                        ClientCache.Instance.CaptainJackSparrowModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.CaptainJackSparrowModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.CaptainJackSparrowModel
                            });

                            break;
                        case 17: // Space Paranoids

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE11E8,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1622" : (string.IsNullOrEmpty(ClientCache.Instance.SoraSpaceParanoidsModel)) ? "1622" : ClientCache.Instance.SoraSpaceParanoidsModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE11EA,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1370" : (string.IsNullOrEmpty(ClientCache.Instance.DonaldSpaceParanoidsModel)) ? "1370" :
                                        ClientCache.Instance.DonaldSpaceParanoidsModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.DonaldSpaceParanoidsModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.DonaldSpaceParanoidsModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE11EC,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1364" : (string.IsNullOrEmpty(ClientCache.Instance.GoofySpaceParanoidsModel)) ? "1364" :
                                        ClientCache.Instance.GoofySpaceParanoidsModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.GoofySpaceParanoidsModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.GoofySpaceParanoidsModel
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE11EE,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "724" : (string.IsNullOrEmpty(ClientCache.Instance.TronModel)) ? "724" :
                                        ClientCache.Instance.TronModel == "RandomAlly" ? allies[random.Next(allies.Count)] : ClientCache.Instance.TronModel == "RandomEnemy" ? enemies[random.Next(enemies.Count)] : ClientCache.Instance.TronModel
                            });

                            break;
                        default:

                            break;
                    }

                    #endregion

                    // TODO Move this to a Pause monitor to just update this on Pause...?

                    #region Party Screen Fix

                    Thread.Sleep(4000);

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21C6CC20,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = "84"
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21C6CC22,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = "92"
                    });

                    this.UpdateMemory(new MemoryObject
                    {
                        Address = 0x21C6CC24,
                        ManipulationType = ManipulationType.Set,
                        Type = DataType.TwoBytes,
                        Value = "93"
                    });

                    switch (world[0])
                    {
                        case 2: // Twilight Town

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC20,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "90"
                            });

                            break;
                        case 5: // Beast's Castle
                            
                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "94"
                            });

                            break;
                        case 6: // Olympus Coliseum

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "101"
                            });

                            break;
                        case 7: // Agrabah

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "98"
                            });

                            break;
                        case 8: // The Land of Dragons

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "99"
                            });

                            break;
                        case 10: // Pride Lands

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC20,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "650"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC22,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1519"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC24,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1563"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "97"
                            });

                            break;
                        //case 11: // Atlantica

                        //    this.UpdateMemory(new MemoryObject
                        //    {
                        //        Address = 0x21C6CC20,
                        //        ManipulationType = ManipulationType.Set,
                        //        Type = DataType.TwoBytes,
                        //        Value = isEvent ? "" : MemoryCache.SoraModelSwap.ToString()
                        //    });

                        //    break;
                        case 13: // Timeless River

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC20,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1623"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC22,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1487"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC24,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1269"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "2073"
                            });

                            break;
                        case 14: // Halloween / Christmas Town

                            if (room[0] < 5)
                            {
                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC20,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "693"
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC22,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "670"
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC24,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "669"
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC26,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "95"
                                });
                            }
                            else
                            {
                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC20,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "2389"
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC22,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "2395"
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC24,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "2396"
                                });

                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21C6CC26,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = "96"
                                });
                            }

                            break;
                        case 16: // Port Royal

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "2077"
                            });

                            break;
                        case 17: // Space Paranoids

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC20,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1622"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC22,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1370"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC24,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1364"
                            });

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "1623"
                            });

                            break;
                        default:

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC26,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = "2073"
                            });

                            break;
                    }

                    #endregion Party Screen Fix
                }
            }
            catch(Exception e)
            {
                Logger.Instance.Error(e.Message, "CheckForEvent");
            }
        }

        public bool CheckAnimationState(string value)
        {
            byte[] readMemory = new byte[8];
            
            ReadProcessMemory(ProcessHandle, (IntPtr)0x20341708, readMemory, readMemory.Length, out _);
            
            return CheckMemory(BitConverter.ToInt32(readMemory) + 0x2000000C, DataType.TwoBytes, value, false);
        }

        public bool CheckMemory(int address, DataType type, string value, bool isValueHex)
        {
            // TODO Figure out a less janky way of doing this
            if (ProcessHandle == IntPtr.Zero)
                return false;

            byte[] data;

            data = ConvertToBytes(type, value, isValueHex);

            byte[] readMemory = new byte[data.Length];

            ReadProcessMemory(ProcessHandle, (IntPtr)address, readMemory, data.Length, out _);

            if (readMemory.SequenceEqual(data))
                return true;

            return false;
        }

        public int GetMemory(int address, int length)
        {
            // TODO Figure out a less janky way of doing this
            if (ProcessHandle == IntPtr.Zero)
                return -1;

            byte[] readMemory = new byte[length];

            ReadProcessMemory(ProcessHandle, (IntPtr)address, readMemory, readMemory.Length, out _);

            if(length == 1)
            {
                return readMemory[0];
            }

            return BitConverter.ToInt32(readMemory);
        }

        public bool CheckTPose()
        {
            try
            {
                if (ProcessHandle == IntPtr.Zero)
                    return false;

                byte[] readMemory = new byte[8];
                byte[] tPose = new byte[2];

                // TODO Make a Pointer Handler
                ReadProcessMemory(ProcessHandle, (IntPtr)0x20341708, readMemory, readMemory.Length, out _);
                ReadProcessMemory(ProcessHandle, (IntPtr)(BitConverter.ToInt32(readMemory) + 0x2000014C), tPose, tPose.Length, out _);

                if (tPose[0] == 0 && tPose[1] == 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "CheckTPose");

                return false;
            }
        }

        public bool FixTPose()
        {
            try
            {
                byte[] readMemory = new byte[8];

                var cameraLock = new byte[1];
                //var cameraRotation = new byte[16]; 
                
                // TODO Make a Pointer Handler
                ReadProcessMemory(ProcessHandle, (IntPtr)0x20341708, readMemory, readMemory.Length, out _);

                ReadProcessMemory(ProcessHandle, (IntPtr)0x2033CC38, cameraLock, cameraLock.Length, out _);
                //ReadProcessMemory(ProcessHandle, (IntPtr)0x2034D3E0, cameraRotation, cameraRotation.Length, out _);

                //var isCameraRotated = false;
                //foreach (var b in cameraRotation)
                //{
                //    if (b != 0)
                //    {
                //        isCameraRotated = true;

                //        break;
                //    }
                //}

                if(cameraLock[0] == 0)// && !isCameraRotated)
                {
                    var animationState = new byte[2];
                    ReadProcessMemory(ProcessHandle, (IntPtr)(BitConverter.ToInt32(readMemory) + 0x2000000C), animationState, animationState.Length, out _);

                    if (BitConverter.ToUInt16(animationState) != 32769)
                    {
                        WriteProcessMemory(ProcessHandle, (IntPtr)(BitConverter.ToInt32(readMemory) + 0x2000000C), new byte[2] { 64, 0 }, 2, out _);
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Logger.Instance.Error(e.Message, "CheckTPose");

                return false;
            }
        }

        //public byte[] GetPlayerIdleAnimation()
        //{
        //    byte[] readMemory = new byte[8];
        //    byte[] readPlayerPointerMemory = new byte[8];
        //    byte[] playerNameMemory = new byte[7];

        //    // TODO Make a Pointer Handler
        //    ReadProcessMemory(ProcessHandle, (IntPtr)0x20341708, readMemory, readMemory.Length, out _);
        //    ReadProcessMemory(ProcessHandle, (IntPtr)(BitConverter.ToInt32(readMemory) + 0x2000000C), readPlayerPointerMemory, readPlayerPointerMemory.Length, out _);
        //    ReadProcessMemory(ProcessHandle, (IntPtr)(BitConverter.ToInt32(readPlayerPointerMemory) + 0x20000008), playerNameMemory, playerNameMemory.Length, out _);

        //    var playerName = Encoding.ASCII.GetString(playerNameMemory);

        //    var idleAnimation = IdleAnimationMappings.IdleAnimations[playerName];

        //    return ConvertToBytes(DataType.FourBytes, idleAnimation, false);
        //}

        #region Conversions

        public byte[] ConvertToBytes(DataType type, string value, bool isValueHex) => type switch
        {
            DataType.Binary => BitConverter.GetBytes(byte.Parse(value)), // ?
            DataType.Byte => new byte[] { isValueHex ? byte.Parse(Convert.ToInt32(value, 16).ToString()) : byte.Parse(Convert.ToInt32(value).ToString()) },
            DataType.TwoBytes => BitConverter.GetBytes(short.Parse(value)),
            DataType.FourBytes => BitConverter.GetBytes(uint.Parse(value)),
            DataType.EightBytes => BitConverter.GetBytes(long.Parse(value)),
            DataType.Float => BitConverter.GetBytes(float.Parse(value)),
            DataType.Double => BitConverter.GetBytes(double.Parse(value)),
            DataType.String => Encoding.UTF8.GetBytes(value),
            DataType.ByteArray => Encoding.UTF8.GetBytes(value), // ?
            _ => new byte[0]
        };

        public byte[] SubtractBytes(DataType type, byte[] arr1, byte[] arr2) => type switch
        {
            DataType.Byte => BitConverter.GetBytes(arr1[0] - arr2[0]),
            DataType.TwoBytes => BitConverter.GetBytes(BitConverter.ToInt16(arr1) - BitConverter.ToInt16(arr2)),
            DataType.FourBytes => BitConverter.GetBytes(BitConverter.ToInt32(arr1) - BitConverter.ToInt32(arr2)),
            DataType.EightBytes => BitConverter.GetBytes(BitConverter.ToInt64(arr1) - BitConverter.ToInt64(arr2)),
            DataType.Float => BitConverter.GetBytes(BitConverter.ToDouble(arr1) - BitConverter.ToDouble(arr2)),
            DataType.Double => BitConverter.GetBytes(BitConverter.ToDouble(arr1) - BitConverter.ToDouble(arr2)),
        };

        public byte[] AddBytes(DataType type, byte[] arr1, byte[] arr2) => type switch
        {
            DataType.Byte => BitConverter.GetBytes(arr1[0] + arr2[0]),
            DataType.TwoBytes => BitConverter.GetBytes(BitConverter.ToInt16(arr1) + BitConverter.ToInt16(arr2)),
            DataType.FourBytes => BitConverter.GetBytes(BitConverter.ToInt32(arr1) + BitConverter.ToInt32(arr2)),
            DataType.EightBytes => BitConverter.GetBytes(BitConverter.ToInt64(arr1) + BitConverter.ToInt64(arr2)),
            DataType.Float => BitConverter.GetBytes(BitConverter.ToDouble(arr1) + BitConverter.ToDouble(arr2)),
            DataType.Double => BitConverter.GetBytes(BitConverter.ToDouble(arr1) + BitConverter.ToDouble(arr2)),
        };

        #endregion Conversions
    }
}