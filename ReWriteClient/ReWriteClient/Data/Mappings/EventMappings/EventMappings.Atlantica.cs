using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeAtlanticaEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[11]["Triton's Throne"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                { WorldRoomMappings.Rooms[11]["Ariel's Grotto"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 51 }, new List<int> { 67 }, new List<int> { 83 }, new List<int> { 84 }, }
                 },

                { WorldRoomMappings.Rooms[11]["Undersea Courtyard (Day)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 5 }, new List<int> { 8 }, new List<int> { 9 }, new List<int> { 11 }, new List<int> { 52 }, new List<int> { 63 }, }
                 },

                { WorldRoomMappings.Rooms[11]["Undersea Courtyard (Dawn)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 53 }, new List<int> { 68 }, new List<int> { 87 }, new List<int> { 88 }, }
                 },

                { WorldRoomMappings.Rooms[11]["The Palace: Performance Hall"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 55 }, new List<int> { 64 }, new List<int> { 66 }, new List<int> { 70 }, new List<int> { 77 }, new List<int> { 78 }, new List<int> { 102 }, new List<int> { 103 }, }
                 },

                { WorldRoomMappings.Rooms[11]["Sunken Ship"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, }
                 },

                { WorldRoomMappings.Rooms[11]["The Shore (Day)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, }
                 },

                { WorldRoomMappings.Rooms[11]["The Shore (Night)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, }
                 },

                { WorldRoomMappings.Rooms[11]["The Shore (Dawn)"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                { WorldRoomMappings.Rooms[11]["Wrath of the Sea"], new List<List<int>> {
                new List<int> { 65 }, new List<int> { 69 }, new List<int> { 97 }, new List<int> { 98 }, }
                 }
            };
        }
    }
}
