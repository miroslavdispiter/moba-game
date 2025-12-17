using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Map
    {
        public string Name { get; set; } = string.Empty;
        public MapType Type { get; set; }
        public int MaxPlayers { get; set; }
        public string BlueTeam { get; set; } = string.Empty;
        public string RedTeam { get; set; } = string.Empty;
        public int EntitiesCount { get; set; }

        public Map() { }

        public Map(string name, MapType type, int maxPlayers, string blueTeam, string redTeam, int entitiesCount)
        {
            Name = name;
            Type = type;
            MaxPlayers = maxPlayers;
            BlueTeam = blueTeam;
            RedTeam = redTeam;
            EntitiesCount = entitiesCount;
        }
    }
}
