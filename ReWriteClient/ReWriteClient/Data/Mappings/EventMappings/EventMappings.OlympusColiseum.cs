using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeOlympusColiseumEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                    { WorldRoomMappings.Rooms[6]["The Coliseum"], new List<List<int>> {
                    new List<int> { 22 }, new List<int> { 1 }, new List<int> { 2 }, new List<int> { 4 }, new List<int> { 68 }, new List<int> { 140 }, new List<int> { 141 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Coliseum Gates (Normal)"], new List<List<int>> {
                    new List<int> { 2 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Coliseum Gates (Destroyed) (Day)"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 142 }, new List<int> { 143 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Underworld Entrance"], new List<List<int>> {
                    new List<int> { 2 }, new List<int> { 5 }, new List<int> { 7 }, new List<int> { 10 }, new List<int> { 12 }, new List<int> { 13 }, new List<int> { 18 }, new List<int> { 19 }, new List<int> { 197 }, new List<int> { 198 }, new List<int> { 199 }, new List<int> { 210 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Coliseum Foyer"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Valley of the Dead"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 3 }, new List<int> { 111 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Hades' Chamber"], new List<List<int>> {
                    new List<int> { 2 }, new List<int> { 10 }, new List<int> { 65 }, new List<int> { 66 }, new List<int> { 67 }, new List<int> { 112 }, new List<int> { 126 }, new List<int> { 216 }, new List<int> { 248 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Cave of the Dead: Entrance"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 10 }, new List<int> { 114 }, new List<int> { 221 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Well of Captivity"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 2 }, new List<int> { 115 }, new List<int> { 116 }, new List<int> { 237 }, new List<int> { 240 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["The Underdrome 1"], new List<List<int>> {
                    new List<int> { 124 }, new List<int> { 125 }, new List<int> { 189 }, new List<int> { 190 }, new List<int> { 191 }, new List<int> { 192 }, new List<int> { 193 }, new List<int> { 194 }, new List<int> { 195 }, new List<int> { 196 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Cave of the Dead: Inner Chamber"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 3 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["The Lock"], new List<List<int>> {
                    new List<int> { 0, 0, 1 }, new List<int> { 2 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["The Underdrome 2"], new List<List<int>> {
                    new List<int> { 10 }, new List<int> { 11 }, new List<int> { 71 }, new List<int> { 180 }, new List<int> { 181 }, new List<int> { 182 }, new List<int> { 183 }, new List<int> { 184 }, new List<int> { 201 }, new List<int> { 202 }, new List<int> { 255 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Coliseum Gates (Destroyed) (Night)"], new List<List<int>> {
                    new List<int> { 10 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Cave of the Dead: Passage"], new List<List<int>> {
                    new List<int> { 1 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Underworld Caverns: Atrium"], new List<List<int>> {
                    new List<int> { 123 }, new List<int> { 3 }, }
                     },

                    { WorldRoomMappings.Rooms[6]["Coliseum Gates (Hydra Battle Area)"], new List<List<int>> {
                    new List<int> { 171 }, new List<int> { 243 }, }
                     }
            };
        }
    }
}
