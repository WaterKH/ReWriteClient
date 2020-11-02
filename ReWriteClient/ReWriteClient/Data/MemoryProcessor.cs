using ReWriteClient.Enums;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
                Console.WriteLine(e.Message);

                return false;
            }

            return true;
        }

        public bool UpdateMemory(MemoryObject obj)
        {
            if (ProcessHandle == null)
                return false;

            try
            {
                byte[] data;

                data = ConvertToBytes(obj.Type, obj.Value);

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
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateAbilityMemory(MemoryObject obj, int maxNumber, int toggleValue)
        {
            if (ProcessHandle == null)
                return false;

            int firstInstance = 0;
            int lastReference = 0;
            int currNumber = 0;
            byte[] data;

            data = new byte[] { byte.Parse(int.Parse(obj.Value).ToString()) };

            byte[] readMemory = new byte[data.Length];

            for (int i = 0; i < 148; i += 2)
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

        public bool CheckMemory(int address, DataType type, string value)
        {
            byte[] data;

            data = ConvertToBytes(type, value);

            byte[] readMemory = new byte[data.Length];

            ReadProcessMemory(ProcessHandle, (IntPtr)address, readMemory, data.Length, out _);

            if (readMemory.SequenceEqual(data))
                return true;

            return false;
        }

        public byte[] ConvertToBytes(DataType type, string value) => type switch
        {
            DataType.Binary => BitConverter.GetBytes(byte.Parse(value)), // ?
            DataType.Byte => new byte[] { byte.Parse(Convert.ToInt32(value, 16).ToString()) },
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
    }
}