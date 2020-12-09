using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializePortRoyalEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[16]["Rampart"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Harbor 1"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 51 }, new List<int> { 52 }, new List<int> { 53 }, new List<int> { 54 }, new List<int> { 91 }, new List<int> { 92 }, new List<int> { 116 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Town"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 55 }, new List<int> { 88 }, new List<int> { 94 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Interceptor 1"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 3 }, new List<int> { 56 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Interceptor: Ship's Hold"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Black Pearl 1"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 12 }, new List<int> { 13 }, new List<int> { 14 }, new List<int> { 20 }, new List<int> { 86 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Black Pearl: Captain's Stateroom 1"], new List<List<int>> {
                new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Interceptor 2"], new List<List<int>> {
                new List<int> { 58 }, new List<int> { 81 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Isla de Muerta: Rock Face 1"], new List<List<int>> {
                new List<int> { 3 }, new List<int> { 4 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Isla de Muerta: Cave Mouth"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 59 }, new List<int> { 100 }, new List<int> { 101 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Isla de Muerta: Treasure Heap 1"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 10 }, new List<int> { 60 }, new List<int> { 111 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Ship Graveyard: The Interceptor's Hold"], new List<List<int>> {
                new List<int> { 10 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Ship Graveyard: Seadrift Keep"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 62 }, new List<int> { 123 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Isla de Muerta: Treasure Heap 2"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 61 }, new List<int> { 103 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Black Pearl 2"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 85 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Black Pearl 3"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 11 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Interceptor 3"], new List<List<int>> {
                new List<int> { 2 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Interceptor 4"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                { WorldRoomMappings.Rooms[16]["The Black Pearl: Captain's Stateroom 2"], new List<List<int>> {
                new List<int> { 79 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Harbor 2"], new List<List<int>> {
                new List<int> { 54 }, new List<int> { 82 }, new List<int> { 84 }, }
                 },

                { WorldRoomMappings.Rooms[16]["Isla de Muerta: Rock Face 2"], new List<List<int>> {
                new List<int> { 83 }, }
                 }
                 };
        }
    }
}
