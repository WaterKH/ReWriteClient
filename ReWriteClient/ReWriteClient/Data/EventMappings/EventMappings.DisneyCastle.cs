using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeDisneyCastleEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[12]["Audience Chamber"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 51 }, new List<int> { 81 }, }
                 },

                { WorldRoomMappings.Rooms[12]["Library"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 53 }, }
                 },

                { WorldRoomMappings.Rooms[12]["Colonnade"], new List<List<int>> {
                new List<int> { 2, 2, 1 }, new List<int> { 79 }, }
                 },

                { WorldRoomMappings.Rooms[12]["Courtyard"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                { WorldRoomMappings.Rooms[12]["The Hall of the Cornerstone (With Thorns)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 54 }, }
                 },

                { WorldRoomMappings.Rooms[12]["The Hall of the Cornerstone (Normal)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, }
                 },

                { WorldRoomMappings.Rooms[12]["Gummi Hangar"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                { WorldRoomMappings.Rooms[12]["Gathering Place"], new List<List<int>> {
                new List<int> { 68 }, new List<int> { 69 }, new List<int> { 70 }, new List<int> { 71 }, new List<int> { 73 }, }
                 }
            };
        }
    }
}
