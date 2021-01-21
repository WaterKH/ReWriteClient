using System.Collections.Generic;

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

        public static Dictionary<string, int> QuickMenuToMagicAddress = new Dictionary<string, int>
        {
            { "49", 0x2032F0C4 }, // Fire
            { "51", 0x2032F0C5 }, // Blizzard
            { "50", 0x2032F0C6 }, // Thunder
            { "52", 0x2032F0C7 }, // Cure
            { "174", 0x2032F0FF }, // Magnet
            { "177", 0x2032F100 }, // Reflect
        };
    }
}