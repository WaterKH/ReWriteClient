using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeAgrabahEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[7]["Agrabah"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 5 }, new List<int> { 6 }, new List<int> { 10 }, new List<int> { 22 }, new List<int> { 57 }, new List<int> { 110 }, new List<int> { 113 },  }
                 },

                { WorldRoomMappings.Rooms[7]["The Peddler's Shop (1st Visit)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, }
                 },

                { WorldRoomMappings.Rooms[7]["The Palace"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 10 }, new List<int> { 59 }, new List<int> { 128 }, new List<int> { 130 }, }
                 },

                { WorldRoomMappings.Rooms[7]["Vault"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[7]["Above Agrabah"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 62 }, new List<int> { 146 }, }
                 },

                { WorldRoomMappings.Rooms[7]["Palace Walls"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 11 }, }
                 },

                { WorldRoomMappings.Rooms[7]["The Cave of Wonders: Entrance"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                { WorldRoomMappings.Rooms[7]["The Cave of Wonders: Stone Guardians"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, }
                 },

                { WorldRoomMappings.Rooms[7]["The Cave of Wonders: Treasure Room"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 58 }, new List<int> { 124 }, }
                 },

                { WorldRoomMappings.Rooms[7]["Ruined Chamber"], new List<List<int>> {
                new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[7]["The Cave of Wonders: Chasm of Challenges"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 79 }, }
                 },

                { WorldRoomMappings.Rooms[7]["Sandswept Ruins"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 11 }, new List<int> { 12 }, new List<int> { 13 }, new List<int> { 14 }, new List<int> { 15 }, new List<int> { 16 }, new List<int> { 17 }, new List<int> { 61 }, new List<int> { 86 }, new List<int> { 87 }, new List<int> { 102 }, new List<int> { 111 }, new List<int> { 140 }, new List<int> { 141 }, new List<int> { 15 }, new List<int> { 10 }, new List<int> { 133 }, new List<int> { 135 }, }
                 }
            };
        }
    }
}
