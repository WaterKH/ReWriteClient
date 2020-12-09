using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializePrideLandsEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[10]["Pride Rock"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 5 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 12 }, new List<int> { 13 }, new List<int> { 14 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Stone Hollow"], new List<List<int>> {
                new List<int> { 10 }, }
                    },

                { WorldRoomMappings.Rooms[10]["The King's Den"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 51 }, new List<int> { 83 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Wildebeest Valley (Present)"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 4 }, }
                    },

                { WorldRoomMappings.Rooms[10]["The Savannah"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 3 }, new List<int> { 10 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Elephant Graveyard"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 56 }, new List<int> { 57 }, new List<int> { 68 }, new List<int> { 93 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Gorge"], new List<List<int>> {
                new List<int> { 1 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Jungle"], new List<List<int>> {
                new List<int> { 1 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Oasis (Day)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 10 }, new List<int> { 11 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Oasis (Night)"], new List<List<int>> {
                new List<int> { 1 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Overlook"], new List<List<int>> {
                new List<int> { 1 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Peak"], new List<List<int>> {
                new List<int> { 1 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Scar's Darkness"], new List<List<int>> {
                new List<int> { 55 }, new List<int> { 85 }, }
                    },

                { WorldRoomMappings.Rooms[10]["The Savannah (Groundshaker Battle Area)"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 59 }, new List<int> { 99 }, }
                    },

                { WorldRoomMappings.Rooms[10]["Wildebeest Valley (Past)"], new List<List<int>> {
                new List<int> { 1 }, }
                    }
            };
        }
    }
}
