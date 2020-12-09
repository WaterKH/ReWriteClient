using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeSpaceParanoidsEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[17]["Pit Cell"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 6 }, new List<int> { 7 }, new List<int> { 10 }, new List<int> { 12 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Canyon"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 10 }, new List<int> { 51 }, new List<int> { 84 }, new List<int> { 85 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Game Grid"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 53 }, new List<int> { 61 }, new List<int> { 62 }, new List<int> { 63 }, new List<int> { 88 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Dataspace"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 54 }, new List<int> { 91 }, }
                 },

                { WorldRoomMappings.Rooms[17]["I/O Tower: Hallway"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 55 }, new List<int> { 56 }, new List<int> { 93 }, }
                 },

                { WorldRoomMappings.Rooms[17]["I/O Tower: Communications Room"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 4 }, new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Solar Sailer Simulation 1"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 57 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Central Computer Mesa"], new List<List<int>> {
                new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Central Computer Core"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 58 }, new List<int> { 59 }, new List<int> { 106 }, new List<int> { 107 }, }
                 },

                { WorldRoomMappings.Rooms[17]["Solar Sailer Simulation 2"], new List<List<int>> {
                new List<int> { 10 }, }
                 }
            };
        }
    }
}
