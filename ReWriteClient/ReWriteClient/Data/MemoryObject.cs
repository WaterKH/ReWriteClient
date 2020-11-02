using ReWriteClient.Enums;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public class MemoryObject
    {
        public string Name { get; set; }
        public int Address { get; set; }
        public DataType Type { get; set; }
        public ManipulationType ManipulationType { get; set; }
        public string Value { get; set; }
    }
}