using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public class EntitySlotMappings
    {
        // Key - Name : Value - Addresses
        public static Dictionary<int, EntitySlot> EntitySlots = new Dictionary<int, EntitySlot>
        {
            { 1, new EntitySlot { Health = 0x21C6C4E8, MaxHealth = 0x21C6C4EC, Strength = 0x21C6C670, Defense = 0x21C6C67C } },
            { 2, new EntitySlot { Health = 0x21C6C280, MaxHealth = 0x21C6C284, Strength = 0x21C6C410, Defense = 0x21C6C414 } },
            { 3, new EntitySlot { Health = 0x21C6C018, MaxHealth = 0x21C6C01C, Strength = 0x21C6C1B4, Defense = 0x21C6C1B8 } },
        };
    }
}