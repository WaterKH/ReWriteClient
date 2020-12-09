using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeTimelessRiverEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[13]["Cornerstone Hill"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 5 }, new List<int> { 6 }, new List<int> { 7 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Pier"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 58 }, new List<int> { 67 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Waterway"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 3 }, new List<int> { 52 }, new List<int> { 86 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Wharf"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 53 }, new List<int> { 88 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Lilliput"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 54 }, new List<int> { 78 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Building Site"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 55 }, new List<int> { 82 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Scene of the Fire"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 56 }, new List<int> { 74 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Mickey's House"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 57 }, new List<int> { 70 }, }
                 },

                { WorldRoomMappings.Rooms[13]["Villain's Vale (Black & White)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, }
                 }
            };
        }
    }
}
