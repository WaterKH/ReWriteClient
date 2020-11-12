using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeTheLandOfDragonsEvents()
        {
            return new Dictionary<int, List<List<int>>> {
                    { WorldRoomMappings.Rooms[8]["Bamboo Grove"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 2 }, }
                     },

                    { WorldRoomMappings.Rooms[8]["Encampment"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 68 }, new List<int> { 70 }, new List<int> { 110 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Checkpoint"], new List<List<int>> {
                    new List<int> { 3 }, new List<int> { 69 }, new List<int> { 80 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Mountain Trail"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 71 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Village Cave"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 72 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Ridge"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 10 }, new List<int> { 12 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Summit"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 2 }, new List<int> { 10 }, new List<int> { 73 }, new List<int> { 76 }, new List<int> { 120 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Imperial Square"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 13 }, new List<int> { 74 }, new List<int> { 79 }, new List<int> { 81 }, new List<int> { 129 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Palace Gate"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 10 }, new List<int> { 75 }, new List<int> { 105 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Antechamber"], new List<List<int>> {
                    new List<int> { 10 }, new List<int> { 11 }, new List<int> { 13 }, new List<int> { 78 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Throne Room"], new List<List<int>> {
                    new List<int> { 10 }, new List<int> { 11 }, new List<int> { 64 }, }
                     },
 
                    {
                                    WorldRoomMappings.Rooms[8]["Village (Repaired)"], new List<List<int>> {
                    new List<int> { 1 }, new List<int> { 10 }, }
                     }
            };
        }
    }
}
