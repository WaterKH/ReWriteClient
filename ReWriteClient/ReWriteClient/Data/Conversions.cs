using System;
using System.Collections.Generic;
using System.Text;

namespace ReWriteClient.Data
{
    public class Conversions
    {
        public static Dictionary<string, string> QuickMenuToItem = new Dictionary<string, string>
        {
            { "23", "1" }, // Potion
            { "20", "2" }, // HiPotion
            { "21", "3" }, // Ether
            { "22", "4" }, // Elixir
            { "242", "5" }, // MegaPotion
            { "243", "6" }, // MegaEther
            { "244", "7" }, // Megalixir
        };
    }
}
