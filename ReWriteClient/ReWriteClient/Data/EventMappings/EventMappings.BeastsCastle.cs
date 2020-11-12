using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static Dictionary<int, List<List<int>>> InitializeBeastsCastleEvents()
        {
            return new Dictionary<int, List<List<int>>> {

                { WorldRoomMappings.Rooms[5]["Entrance Hall"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 12 }, new List<int> { 75 }, new List<int> { 124 }, }
                 },

                { WorldRoomMappings.Rooms[5]["Parlor"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 68 }, new List<int> { 102 }, }
                 },

                { WorldRoomMappings.Rooms[5]["Belle's Room"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 104 }, }
                 },

                { WorldRoomMappings.Rooms[5]["Beast's Room"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 11 }, new List<int> { 69 }, new List<int> { 110 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Ballroom (Normal)"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 10 }, new List<int> { 74 }, new List<int> { 119 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Ballroom (Covered in Darkness)"], new List<List<int>> {
                new List<int> { 78 }, new List<int> { 79 }, new List<int> { 113 }, new List<int> { 114 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Courtyard"], new List<List<int>> {
                new List<int> { 10 }, new List<int> { 11 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["The West Hall"], new List<List<int>> {
                new List<int> { 2 }, new List<int> { 3 }, new List<int> { 95 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["The West Wing"], new List<List<int>> {
                new List<int> { 10 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Dungeon"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 108 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Undercroft"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 72 }, new List<int> { 129 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Secret Passage"], new List<List<int>> {
                new List<int> { 1 }, new List<int> { 2 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Bridge (Normal)"], new List<List<int>> {
                new List<int> { 10 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Ballroom"], new List<List<int>> {
                new List<int> { 1 }, }
                 },

                {
                                WorldRoomMappings.Rooms[5]["Bridge (Xaldin Battle Area)"], new List<List<int>> {
                new List<int> { 82 }, new List<int> { 97 }, new List<int> { 98 }, new List<int> { 99 }, new List<int> { 127 }, }
                 }
            };
        }
    
    }
}
