using System;
using System.Collections.Generic;
using Waterkh.Common.Memory;

namespace ReWriteClient.Events
{
    public class OptionsArgs : EventArgs
    {
        public Dictionary<string, List<ButtonTemplate>> Options { get; set; }
    }
}