using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeDestinyIslandsEvents()
        {
            return new Dictionary<int, List<List<int>>> {
                { WorldRoomMappings.Rooms[3]["Main Island: Ocean's Road"], new List<List<int>> {
                new List<int> { 51 }, new List<int> { 52 }, }
                 },

                { WorldRoomMappings.Rooms[3]["Main Island: Shore"], new List<List<int>> {
                new List<int> { 53 }, new List<int> { 54 }, }
                 }
            };
        }
    }
}
