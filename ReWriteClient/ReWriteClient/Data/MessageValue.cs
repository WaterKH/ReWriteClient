using System;
using System.Collections.Generic;
using Waterkh.Common.Memory;

namespace ReWriteClient.Data
{
    public class MessageValue
    {
        public Func<ManipulationType, string, bool> Method { get; set; }
        public List<string> Values { get; set; }
        public bool IsOn { get; set; } = true;
    }
}