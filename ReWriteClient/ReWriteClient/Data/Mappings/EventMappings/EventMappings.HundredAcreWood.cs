using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeHundredAcreWoodEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[9]["The Hundred Acre Wood"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 5 }, new List<int> { 6 }, new List<int> { 7 }, new List<int> { 8 }, new List<int> { 9 }, new List<int> { 10 }, new List<int> { 11 }, }
                 },

                { WorldRoomMappings.Rooms[9]["Starry Hill"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 3 }, new List<int> { 52 }, new List<int> { 53 }, new List<int> { 73 }, }
                 },

                { WorldRoomMappings.Rooms[9]["Pooh Bear's House"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, }
                 },

                { WorldRoomMappings.Rooms[9]["Rabbit's House"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, }
                 },

                { WorldRoomMappings.Rooms[9]["Piglet's House"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 4 }, }
                 },

                { WorldRoomMappings.Rooms[9]["Kanga's House"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 4 }, }
                 },

                { WorldRoomMappings.Rooms[9]["A Windsday Tale"], new List<List<int>> {
                new List<int> { 55 }, new List<int> { 69 }, }
                 },

                { WorldRoomMappings.Rooms[9]["The Honey Hunt"], new List<List<int>> {
                new List<int> { 57 }, new List<int> { 70 }, }
                 },

                { WorldRoomMappings.Rooms[9]["Blossom Valley"], new List<List<int>> {
                new List<int> { 59 }, new List<int> { 71 }, }
                 },

                { WorldRoomMappings.Rooms[9]["The Spooky Cave"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 3 }, new List<int> { 61 }, new List<int> { 72 }, }
                 }
            };
        }
    }
}
