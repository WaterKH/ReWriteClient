using ReWriteClient.Enums;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

                EventMappings.Instance.Events.TryGetValue((int)world[0], out var rooms);

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
                if (MemoryCache.CurrentWorld != (int)world[0] || MemoryCache.CurrentRoom != (int)room[0])
                {
                    switch (MemoryCache.CurrentWorld)
                    {
                        case 2: // Twilight Town

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC20,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "90" : MemoryCache.SoraModelSwap.ToString()
                            });

                            break;
                        case 10: // Pride Lands

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE1250,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "650" : MemoryCache.SoraModelSwap.ToString()
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
                                Value = isEvent ? "1623" : MemoryCache.SoraModelSwap.ToString()
                            });

                            break;
                        case 14: // Halloween / Christmas Town

                            if (MemoryCache.CurrentRoom < 5)
                            {
                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FAC,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "693" : MemoryCache.SoraModelSwap.ToString()
                                });
                            }
                            else
                            {
                                this.UpdateMemory(new MemoryObject
                                {
                                    Address = 0x21CE0FE0,
                                    ManipulationType = ManipulationType.Set,
                                    Type = DataType.TwoBytes,
                                    Value = isEvent ? "2389" : MemoryCache.SoraModelSwap.ToString()
                                });
                            }

                            break;
                        case 17: // Space Paranoids

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21CE11E8,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "1622" : MemoryCache.SoraModelSwap.ToString()
                            });

                            break;
                        default:

                            this.UpdateMemory(new MemoryObject
                            {
                                Address = 0x21C6CC20,
                                ManipulationType = ManipulationType.Set,
                                Type = DataType.TwoBytes,
                                Value = isEvent ? "84" : MemoryCache.SoraModelSwap.ToString()
                            });

                            break;
                    }

                    if (!isEvent)
                    {
                        MemoryCache.CurrentWorld = (int)world[0];
                        MemoryCache.CurrentRoom = (int)room[0];
                    }

                    MemoryCache.AllowedToWrite = isEvent;
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
                    //var playerIdleAnimation = GetPlayerIdleAnimation();

                    WriteProcessMemory(ProcessHandle, (IntPtr)(BitConverter.ToInt32(readMemory) + 0x2000000C), new byte[2] { 64, 0 }, 2, out _);
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
            DataType.FourBytes => BitConverter.GetBytes(int.Parse(value)),
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