using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeWorldOfDarknessEvents()
        {
            return new Dictionary<int, List<List<int>>> {
                { WorldRoomMappings.Rooms[1]["The Dark Margin"], new List<List<int>> {
                    new List<int> { 51 }, new List<int> { 57 }, new List<int> { 58 }, new List<int> { 60 },
                    new List<int> { 61 },
                    }
                },
                { WorldRoomMappings.Rooms[1]["Loop Demo"], new List<List<int>> {
                    new List<int> { 56 },
                    }
                }
            };
        }
    }
}
