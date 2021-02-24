using ReWriteClient.Messages;
using System.Collections;
using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public class ResponseManager
    {
        public static ResponseManager Instance { get; set; } = new ResponseManager();

        // TODO Change these so that it maybe uses the cache to see if we should send out a response or not?
        public void SendResponse(MessageHub messageHub)
        {
            var list = new List<string>();

            list.AddRange(this.CheckSpells());
            list.AddRange(this.CheckLimits());
            list.AddRange(this.CheckFormsSummons());
            list.AddRange(this.CheckSlots());
            list.AddRange(this.CheckModels());

            if (list.Count > 0)
            {
                messageHub.SendDynamicUIResponseMessage(list);
            }
        }

        public List<string> CheckSpells()
        {
            var list = new List<string>();

            var fire = MemoryProcessor.Instance.GetMemory(0x2032F0C4, 1);
            var blizzard = MemoryProcessor.Instance.GetMemory(0x2032F0C5, 1);
            var thunder = MemoryProcessor.Instance.GetMemory(0x2032F0C6, 1);
            var cure = MemoryProcessor.Instance.GetMemory(0x2032F0C7, 1);
            var magnet = MemoryProcessor.Instance.GetMemory(0x2032F0FF, 1);
            var reflect = MemoryProcessor.Instance.GetMemory(0x2032F100, 1);

            list.Add($"Sora:Take Fira:{fire != 0}");
            list.Add($"Sora:Give Fire:{fire != 1}");
            list.Add($"Sora:Give Fira:{fire != 2}");
            list.Add($"Sora:Give Firaga:{fire != 3}");
            list.Add($"Sora:Change Fire Magic Cost:{fire > 0}");

            list.Add($"Sora:Take Blizzard:{blizzard != 0}");
            list.Add($"Sora:Give Blizzard:{blizzard != 1}");
            list.Add($"Sora:Give Blizzara:{blizzard != 2}");
            list.Add($"Sora:Give Blizzaga:{blizzard != 3}");
            list.Add($"Sora:Change Blizzard Magic Cost:{blizzard > 0}");

            list.Add($"Sora:Take Thunder:{thunder != 0}");
            list.Add($"Sora:Give Thunder:{thunder != 1}");
            list.Add($"Sora:Give Thundara:{thunder != 2}");
            list.Add($"Sora:Give Thundaga:{thunder != 3}");
            list.Add($"Sora:Change Thunder Magic Cost:{thunder > 0}");

            list.Add($"Sora:Take Cure:{cure != 0}");
            list.Add($"Sora:Give Cure:{cure != 1}");
            list.Add($"Sora:Give Cura:{cure != 2}");
            list.Add($"Sora:Give Curaga:{cure != 3}");
            list.Add($"Sora:Change Cure Magic Cost:{cure > 0}");

            list.Add($"Sora:Take Magnet:{magnet != 0}");
            list.Add($"Sora:Give Magnet:{magnet != 1}");
            list.Add($"Sora:Give Magnera:{magnet != 2}");
            list.Add($"Sora:Give Magnega:{magnet != 3}");
            list.Add($"Sora:Change Magnet Magic Cost:{magnet > 0}");

            list.Add($"Sora:Take Reflect:{reflect != 0}");
            list.Add($"Sora:Give Reflect:{reflect != 1}");
            list.Add($"Sora:Give Reflera:{reflect != 2}");
            list.Add($"Sora:Give Reflega:{reflect != 3}");
            list.Add($"Sora:Change Reflect Magic Cost:{reflect > 0}");

            return list;
        }

        public List<string> CheckLimits()
        {
            var list = new List<string>();

            var donaldSlot = MemoryProcessor.Instance.GetMemory(0x21CE0B6A, 2);
            var goofySlot = MemoryProcessor.Instance.GetMemory(0x21CE0B6C, 2);
            var partySlot = GetPartyMemberForWorld();

            list.Add($"Sora:Change Duck Flare Magic Cost:{donaldSlot == 92 || goofySlot == 92 || partySlot == 92}");
            list.Add($"Sora:Change Comet Magic Cost:{donaldSlot == 92 || goofySlot == 92 || partySlot == 92}");

            list.Add($"Sora:Change WhirliGoof Magic Cost:{donaldSlot == 93 || goofySlot == 93 || partySlot == 93}");
            list.Add($"Sora:Change Knocksmash Magic Cost:{donaldSlot == 93 || goofySlot == 93 || partySlot == 93}");

            list.Add($"Sora:Change Red Rocket Magic Cost:{(donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || donaldSlot == 99 || goofySlot == 99 || partySlot == 99}");
            list.Add($"Sora:Change Twin Howl Magic Cost:{donaldSlot == 94 || goofySlot == 94 || partySlot == 94}");
            list.Add($"Sora:Change Bushido Magic Cost:{donaldSlot == 101 || goofySlot == 101 || partySlot == 101}");
            list.Add($"Sora:Change Bluff Magic Cost:{donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077}");
            list.Add($"Sora:Change Speedster Magic Cost:{donaldSlot == 98 || goofySlot == 98 || partySlot == 98}");
            list.Add($"Sora:Change Dance Call Magic Cost:{(donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95)}");
            list.Add($"Sora:Change Wildcat Magic Cost:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97}");
            list.Add($"Sora:Change Setup Magic Cost:{donaldSlot == 724 || goofySlot == 724 || partySlot == 724}");
            list.Add($"Sora:Change Session Magic Cost:{donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073}");

            return list;
        }

        public List<string> CheckFormsSummons()
        {
            var list = new List<string>();

            var formSummons = new BitArray(new int[] { MemoryProcessor.Instance.GetMemory(0x2032F1F0, 1) });
            var summons = new BitArray(new int[] { MemoryProcessor.Instance.GetMemory(0x2032F1F4, 1) });
            var limit = MemoryProcessor.Instance.GetMemory(0x2032F1FA, 1); // This controls more than just Limit... but what?

            list.Add($"Sora:Give Valor Form:{formSummons[1]}");
            list.Add($"Sora:Take Valor Form:{!formSummons[1]}");
            list.Add($"Sora:Give Wisdom Form:{formSummons[2]}");
            list.Add($"Sora:Take Wisdom Form:{!formSummons[2]}");
            list.Add($"Sora:Give Limit Form:{limit > 0}");
            list.Add($"Sora:Take Limit Form:{limit > 0}");
            list.Add($"Sora:Give Master Form:{formSummons[6]}");
            list.Add($"Sora:Take Master Form:{!formSummons[6]}");
            list.Add($"Sora:Give Final Form:{formSummons[4]}");
            list.Add($"Sora:Take Final Form:{!formSummons[4]}");
            list.Add($"Sora:Give Anti Form:{formSummons[5]}");
            list.Add($"Sora:Take Anti Form:{!formSummons[5]}");

            list.Add($"Sora:Equip Valor Keyblade:{formSummons[1]}");
            list.Add($"Sora:Equip Master Keyblade:{formSummons[6]}");
            list.Add($"Sora:Equip Final Keyblade:{formSummons[4]}");

            list.Add($"Sora:Give Ukulele Charm:{formSummons[0]}");
            list.Add($"Sora:Take Ukulele Charm:{formSummons[0]}");

            list.Add($"Sora:Give Baseball Charm:{formSummons[3]}");
            list.Add($"Sora:Take Baseball Charm:{formSummons[3]}");

            list.Add($"Sora:Give Lamp Charm:{summons[4]}");
            list.Add($"Sora:Take Lamp Charm:{summons[4]}");

            list.Add($"Sora:Give Feather Charm:{summons[5]}");
            list.Add($"Sora:Take Feather Charm:{summons[5]}");

            list.Add($"Sora:Change Strike Raid Magic Cost:{limit > 0}");
            list.Add($"Sora:Change Sonic Blade Magic Cost:{limit > 0}");
            list.Add($"Sora:Change Ragnarok Magic Cost:{limit > 0}");
            list.Add($"Sora:Change Ars Arcanum Magic Cost:{limit > 0}");

            return list;
        }

        public List<string> CheckSlots()
        {
            var list = new List<string>();
            
            var donaldSlot = MemoryProcessor.Instance.GetMemory(0x21CE0B6A, 2);
            var goofySlot = MemoryProcessor.Instance.GetMemory(0x21CE0B6C, 2);
            var partySlot = GetPartyMemberForWorld();

            #region Sora

            var soraArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E030, 1);
            var soraAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E031, 1);
            var soraItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E032, 1);

            list.Add($"Sora:Change Armor Slot 1:{soraArmorSlots >= 1}");
            list.Add($"Sora:Change Armor Slot 2:{soraArmorSlots >= 2}");
            list.Add($"Sora:Change Armor Slot 3:{soraArmorSlots >= 3}");
            list.Add($"Sora:Change Armor Slot 4:{soraArmorSlots >= 4}");

            list.Add($"Sora:Change Accessory Slot 1:{soraAccessorySlots >= 1}");
            list.Add($"Sora:Change Accessory Slot 2:{soraAccessorySlots >= 2}");
            list.Add($"Sora:Change Accessory Slot 3:{soraAccessorySlots >= 3}");
            list.Add($"Sora:Change Accessory Slot 4:{soraAccessorySlots >= 4}");

            list.Add($"Sora:Change Item Slot 1:{soraItemSlots >= 1}");
            list.Add($"Sora:Change Item Slot 2:{soraItemSlots >= 2}");
            list.Add($"Sora:Change Item Slot 3:{soraItemSlots >= 3}");
            list.Add($"Sora:Change Item Slot 4:{soraItemSlots >= 4}");
            list.Add($"Sora:Change Item Slot 5:{soraItemSlots >= 5}");
            list.Add($"Sora:Change Item Slot 6:{soraItemSlots >= 6}");
            list.Add($"Sora:Change Item Slot 7:{soraItemSlots >= 7}");
            list.Add($"Sora:Change Item Slot 8:{soraItemSlots >= 8}");

            #endregion Sora

            #region Donald

            var donaldArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E144, 1);
            var donaldAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E145, 1);
            var donaldItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E146, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldArmorSlots >= 1}");
            list.Add($"Party:Change Armor Slot 2:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldArmorSlots >= 2}");

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92)}");
            list.Add($"Party:Change Accessory Slot 1:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldAccessorySlots >= 1}");
            list.Add($"Party:Change Accessory Slot 2:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldAccessorySlots >= 2}");
            list.Add($"Party:Change Accessory Slot 3:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldAccessorySlots >= 3}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 92 || goofySlot == 92 || partySlot == 92) && donaldItemSlots >= 2}");

            #endregion Donald

            #region Goofy

            var goofyArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E258, 1);
            var goofyAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E259, 1);
            var goofyItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E25A, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93)}");
            list.Add($"Sora:Change Armor Slot 1:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyArmorSlots >= 1}");
            list.Add($"Sora:Change Armor Slot 2:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyArmorSlots >= 2}");
            list.Add($"Sora:Change Armor Slot 3:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyArmorSlots >= 3}");

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93)}");
            list.Add($"Sora:Change Accessory Slot 1:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyAccessorySlots >= 1}");
            list.Add($"Sora:Change Accessory Slot 2:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyAccessorySlots >= 2}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93)}");
            list.Add($"Sora:Change Item Slot 1:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyItemSlots >= 1}");
            list.Add($"Sora:Change Item Slot 2:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyItemSlots >= 2}");
            list.Add($"Sora:Change Item Slot 3:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyItemSlots >= 3}");
            list.Add($"Sora:Change Item Slot 4:{(donaldSlot == 93 || goofySlot == 93 || partySlot == 93) && goofyItemSlots >= 4}");

            #endregion Goofy

            #region Mulan

            var mulanArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E594, 1);
            var mulanAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E595, 1);
            var mulanItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E596, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99) && mulanArmorSlots >= 1}");

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)}");
            list.Add($"Party:Change Accessory Slot 1:{((donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)) && mulanAccessorySlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)}");
            list.Add($"Party:Change Item Slot 1:{((donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)) && mulanItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{((donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)) && mulanItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{((donaldSlot == 100 || goofySlot == 100 || partySlot == 100) || (donaldSlot == 99 || goofySlot == 99 || partySlot == 99)) && mulanItemSlots >= 3}");

            #endregion Mulan

            #region Beast

            var beastAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E8D1, 1);
            var beastItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E8D2, 1);

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94)}");
            list.Add($"Party:Change Accessory Slot 1:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94) && beastAccessorySlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94) && beastItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94) && beastItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94) && beastItemSlots >= 3}");
            list.Add($"Party:Change Item Slot 4:{(donaldSlot == 94 || goofySlot == 94 || partySlot == 94) && beastItemSlots >= 4}");

            #endregion Beast

            #region Auron

            var auronArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E480, 1);
            var auronItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E482, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 101 || goofySlot == 101 || partySlot == 101)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 101 || goofySlot == 101 || partySlot == 101) && auronArmorSlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 101 || goofySlot == 101 || partySlot == 101)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 101 || goofySlot == 101 || partySlot == 101) && auronItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 101 || goofySlot == 101 || partySlot == 101) && auronItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{(donaldSlot == 101 || goofySlot == 101 || partySlot == 101) && auronItemSlots >= 3}");

            #endregion Auron

            #region Captain Jack Sparrow

            var sparrowArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E7BC, 1);
            var sparrowAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E7BD, 1);
            var sparrowItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E7BE, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077) && sparrowArmorSlots >= 1}");

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077)}");
            list.Add($"Party:Change Accessory Slot 1:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077) && sparrowAccessorySlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077) && sparrowItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077) && sparrowItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{(donaldSlot == 2077 || goofySlot == 2077 || partySlot == 2077) && sparrowItemSlots >= 3}");

            #endregion Captain Jack Sparrow

            #region Aladdin

            var aladdinArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032E6A8, 1);
            var aladdinItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E6AA, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98) && aladdinArmorSlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98) && aladdinItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98) && aladdinItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98) && aladdinItemSlots >= 3}");
            list.Add($"Party:Change Item Slot 4:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98) && aladdinItemSlots >= 4}");
            list.Add($"Party:Change Item Slot 5:{(donaldSlot == 98 || goofySlot == 98 || partySlot == 98) && aladdinItemSlots >= 5}");

            #endregion Aladdin

            #region Jack Skellington

            var skellingtonAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032E9E5, 1);
            var skellingtonItemSlots = MemoryProcessor.Instance.GetMemory(0x2032E9E6, 1);

            list.Add($"Party:Change Accessory Slots:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95))}");
            list.Add($"Party:Change Accessory Slot 1:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95)) && skellingtonAccessorySlots >= 1}");
            list.Add($"Party:Change Accessory Slot 2:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95)) && skellingtonAccessorySlots >= 2}");

            list.Add($"Party:Change Item Slots:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95))}");
            list.Add($"Party:Change Item Slot 1:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95)) && skellingtonItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95)) && skellingtonItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{((donaldSlot == 96 || goofySlot == 96 || partySlot == 96) || (donaldSlot == 95 || goofySlot == 95 || partySlot == 95)) && skellingtonItemSlots >= 3}");

            #endregion Jack Skellington

            #region Simba

            var simbaAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032EAF9, 1);
            var simbaItemSlots = MemoryProcessor.Instance.GetMemory(0x2032EAFA, 1);

            list.Add($"Party:Change Accessory Slots:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97}");
            list.Add($"Party:Change Accessory Slot 1:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97 && simbaAccessorySlots >= 1}");
            list.Add($"Party:Change Accessory Slot 2:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97 && simbaAccessorySlots >= 2}");

            list.Add($"Party:Change Item Slots:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97}");
            list.Add($"Party:Change Item Slot 1:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97 && simbaItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97 && simbaItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{donaldSlot == 97 || goofySlot == 97 || partySlot == 97 && simbaItemSlots >= 3}");

            #endregion Simba

            #region Tron

            var tronArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032EC0C, 1);
            var tronAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032EC0D, 1);
            var tronItemSlots = MemoryProcessor.Instance.GetMemory(0x2032EC0E, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724) && sparrowArmorSlots >= 1}");

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724)}");
            list.Add($"Party:Change Accessory Slot 1:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724) && sparrowAccessorySlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724) && sparrowItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 724 || goofySlot == 724 || partySlot == 724) && sparrowItemSlots >= 2}");

            #endregion Tron

            #region Riku

            var rikuArmorSlots = MemoryProcessor.Instance.GetMemory(0x2032ED20, 1);
            var rikuAccessorySlots = MemoryProcessor.Instance.GetMemory(0x2032ED21, 1);
            var rikuItemSlots = MemoryProcessor.Instance.GetMemory(0x2032ED22, 1);

            list.Add($"Party:Change Armor Slots:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073)}");
            list.Add($"Party:Change Armor Slot 1:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuArmorSlots >= 1}");
            list.Add($"Party:Change Armor Slot 2:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuArmorSlots >= 2}");

            list.Add($"Party:Change Accessory Slots:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073)}");
            list.Add($"Party:Change Accessory Slot 1:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuAccessorySlots >= 1}");

            list.Add($"Party:Change Item Slots:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073)}");
            list.Add($"Party:Change Item Slot 1:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuItemSlots >= 1}");
            list.Add($"Party:Change Item Slot 2:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuItemSlots >= 2}");
            list.Add($"Party:Change Item Slot 3:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuItemSlots >= 3}");
            list.Add($"Party:Change Item Slot 4:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuItemSlots >= 4}");
            list.Add($"Party:Change Item Slot 5:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuItemSlots >= 5}");
            list.Add($"Party:Change Item Slot 6:{(donaldSlot == 2073 || goofySlot == 2073 || partySlot == 2073) && rikuItemSlots >= 6}");

            #endregion Riku

            return list;
        }

        public List<string> CheckModels()
        {
            var list = new List<string>();

            var world = MemoryProcessor.Instance.GetMemory(0x2032BAE0, 1);
            var room = MemoryProcessor.Instance.GetMemory(0x2032BAE1, 1);

            list.Add($"ModelSwap:Change Sora:{world != 10 || world != 13 || world != 14 || world != 17}");
            list.Add($"ModelSwap:Change Halloween Sora:{world == 14 || room < 5}");
            list.Add($"ModelSwap:Change Christmas Sora:{world == 14 || room >= 5}");
            list.Add($"ModelSwap:Change Lion Sora:{world == 10}");
            list.Add($"ModelSwap:Change Space Paranoids Sora:{world == 17}");
            list.Add($"ModelSwap:Change Timeless River Sora:{world == 13}");

            list.Add($"ModelSwap:Change Donald (Ally):{world != 10 || world != 13 || world != 14 || world != 17}");
            list.Add($"ModelSwap:Change Donald (Enemy):{world != 10 || world != 13 || world != 14 || world != 17}");
            list.Add($"ModelSwap:Change Halloween Donald (Ally):{world == 14 || room < 5}");
            list.Add($"ModelSwap:Change Halloween Donald (Enemy):{world == 14 || room < 5}");
            list.Add($"ModelSwap:Change Christmas Donald (Ally):{world == 14 || room >= 5}");
            list.Add($"ModelSwap:Change Christmas Donald (Enemy):{world == 14 || room >= 5}");
            list.Add($"ModelSwap:Change Bird Donald (Ally):{world == 10}");
            list.Add($"ModelSwap:Change Bird Donald (Enemy):{world == 10}");
            list.Add($"ModelSwap:Change Space Paranoids Donald (Ally):{world == 17}");
            list.Add($"ModelSwap:Change Space Paranoids Donald (Enemy):{world == 17}");
            list.Add($"ModelSwap:Change Timeless River Donald (Ally):{world == 13}");
            list.Add($"ModelSwap:Change Timeless River Donald (Enemy):{world == 13}");

            list.Add($"ModelSwap:Change Goofy (Ally):{world != 10 || world != 13 || world != 14 || world != 17}");
            list.Add($"ModelSwap:Change Goofy (Enemy):{world != 10 || world != 13 || world != 14 || world != 17}");
            list.Add($"ModelSwap:Change Halloween Goofy (Ally):{world == 14 || room < 5}");
            list.Add($"ModelSwap:Change Halloween Goofy (Enemy):{world == 14 || room < 5}");
            list.Add($"ModelSwap:Change Christmas Goofy (Ally):{world == 14 || room >= 5}");
            list.Add($"ModelSwap:Change Christmas Goofy (Enemy):{world == 14 || room >= 5}");
            list.Add($"ModelSwap:Change Bird Goofy (Ally):{world == 10}");
            list.Add($"ModelSwap:Change Bird Goofy (Enemy):{world == 10}");
            list.Add($"ModelSwap:Change Space Paranoids Goofy (Ally):{world == 17}");
            list.Add($"ModelSwap:Change Space Paranoids Goofy (Enemy):{world == 17}");
            list.Add($"ModelSwap:Change Timeless River Goofy (Ally):{world == 13}");
            list.Add($"ModelSwap:Change Timeless River Goofy (Enemy):{world == 13}");

            list.Add($"ModelSwap:Change Aladdin (Ally):{world == 7}");
            list.Add($"ModelSwap:Change Aladdin (Enemy):{world == 7}");
            list.Add($"ModelSwap:Change Auron (Ally):{world == 6}");
            list.Add($"ModelSwap:Change Auron (Enemy):{world == 6}");
            list.Add($"ModelSwap:Change Beast (Ally):{world == 5}");
            list.Add($"ModelSwap:Change Beast (Enemy):{world == 5}");
            list.Add($"ModelSwap:Change Captain Jack Sparrow (Ally):{world == 16}");
            list.Add($"ModelSwap:Change Captain Jack Sparrow (Enemy):{world == 16}");
            list.Add($"ModelSwap:Change Jack Skellington (Ally):{world == 14}");
            list.Add($"ModelSwap:Change Jack Skellington (Enemy):{world == 14}");
            list.Add($"ModelSwap:Change Mulan (Ally):{world == 8}");
            list.Add($"ModelSwap:Change Mulan (Enemy):{world == 8}");
            list.Add($"ModelSwap:Change Riku (Ally):{world == 18}");
            list.Add($"ModelSwap:Change Riku (Enemy):{world == 18}");
            list.Add($"ModelSwap:Change Simba (Ally):{world == 10}");
            list.Add($"ModelSwap:Change Simba (Enemy):{world == 10}");
            list.Add($"ModelSwap:Change Tron (Ally):{world == 17}");
            list.Add($"ModelSwap:Change Tron (Enemy):{world == 17}");

            return list;
        }

        private int GetPartyMemberForWorld()
        {
            var world = MemoryProcessor.Instance.GetMemory(0x2032BAE0, 1);

            return world switch
            {
                // Beast's Castle
                5 => MemoryProcessor.Instance.GetMemory(0x21CE104E, 2),
                // Olympus Coliseum
                6 => MemoryProcessor.Instance.GetMemory(0x21CE0EE2, 2),
                // Agrabah
                7 => MemoryProcessor.Instance.GetMemory(0x21CE0F7E, 2),
                // The Land of Dragons
                8 => MemoryProcessor.Instance.GetMemory(0x21CE10B6, 2),
                // Pride Lands
                10 => MemoryProcessor.Instance.GetMemory(0x21CE1256, 2),
                // Halloween / Christmas Town
                14 => MemoryProcessor.Instance.GetMemory(0x21CE101A, 2),
                // Port Royal
                16 => MemoryProcessor.Instance.GetMemory(0x21CE0DDE, 2),
                // Space Paranoids
                17 => MemoryProcessor.Instance.GetMemory(0x21CE11EE, 2),
                // TWTNW
                18 => MemoryProcessor.Instance.GetMemory(0x21CE10EA, 2),
                _ => -1,
            };
        }
    }
}