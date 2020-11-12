using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeHalloweenTownEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[14]["Halloween Town Square"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 51 }, new List<int> { 60 }, new List<int> { 82 }, new List<int> { 108 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Dr. Finkelstein's Lab"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 11 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Graveyard"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 5 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Curly Hill"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 52 }, new List<int> { 57 }, new List<int> { 94 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Hinterlands"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 10 }, new List<int> { 58 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Yuletide Hill"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 3 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Candy Cane Lane"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 3 }, new List<int> { 5 }, new List<int> { 10 }, new List<int> { 53 }, new List<int> { 88 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Christmas Tree Plaza"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 64 }, new List<int> { 114 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Santa's House"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 18 }, new List<int> { 20 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Toy Factory: Shipping and Receiving"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 55 }, new List<int> { 59 }, new List<int> { 75 }, new List<int> { 100 }, }
                 },

                { WorldRoomMappings.Rooms[14]["Toy Factory: The Wrapping Room"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 62 }, new List<int> { 63 }, new List<int> { 72 }, }
                 }
            };
        }
    }
}
