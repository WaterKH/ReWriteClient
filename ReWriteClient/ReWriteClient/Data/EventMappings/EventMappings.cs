using System.Collections.Generic;

namespace ReWriteClient.Data
{
    public partial class EventMappings
    {
        public static EventMappings Instance { get; set; } = new EventMappings();

        // Key: World - Value: Key: Room - Value: Event vars
        public Dictionary<int, Dictionary<int, List<List<int>>>> Events;

        private EventMappings()
        {
            Events = InitializeEvents();
        }

        public Dictionary<int, Dictionary<int, List<List<int>>>> InitializeEvents()
        {
            var events = new Dictionary<int, Dictionary<int, List<List<int>>>>
            {
                { WorldRoomMappings.Worlds["World of Darkness"], InitializeWorldOfDarknessEvents() },
                { WorldRoomMappings.Worlds["Twilight Town"], InitializeTwilightTownEvents() },
                { WorldRoomMappings.Worlds["Destiny Islands"], InitializeDestinyIslandsEvents() },
                { WorldRoomMappings.Worlds["Hollow Bastion/Radiant Garden"], InitializeRadiantGardenEvents() },
                { WorldRoomMappings.Worlds["Beast's Castle"], InitializeBeastsCastleEvents() },
                { WorldRoomMappings.Worlds["Olympus Coliseum"], InitializeOlympusColiseumEvents() },
                { WorldRoomMappings.Worlds["Agrabah"], InitializeAgrabahEvents() },
                { WorldRoomMappings.Worlds["The Land of Dragons"], InitializeTheLandOfDragonsEvents() },
                { WorldRoomMappings.Worlds["100 Acre Wood"], InitializeHundredAcreWoodEvents() },
                { WorldRoomMappings.Worlds["Pride Lands"], InitializePrideLandsEvents() },
                { WorldRoomMappings.Worlds["Atlantica"], InitializeAtlanticaEvents() },
                { WorldRoomMappings.Worlds["Disney Castle"], InitializeDisneyCastleEvents() },
                { WorldRoomMappings.Worlds["Timeless River"], InitializeTimelessRiverEvents() },
                { WorldRoomMappings.Worlds["Halloween Town"], InitializeHalloweenTownEvents() },
                { WorldRoomMappings.Worlds["Port Royal"], InitializePortRoyalEvents() },
                { WorldRoomMappings.Worlds["Space Paranoids"], InitializeSpaceParanoidsEvents() },
                { WorldRoomMappings.Worlds["The World That Never Was"], InitializeTheWorldThatNeverWasEvents() },
            };

            return events;
        }
    }
}
