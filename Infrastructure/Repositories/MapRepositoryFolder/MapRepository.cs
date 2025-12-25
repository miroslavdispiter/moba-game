using Domain.Enums;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.MapRepositoryFolder
{
    public class MapRepository : IMapRepository
    {
        private static readonly List<Map> MapsList;

        static MapRepository()
        {
            MapsList = new List<Map>()
            {
                new Map("Cosmic Ruins", MapType.Summer, 10, "", "", 40),
                new Map("Crush Site", MapType.Winter, 6, "", "", 40),
                new Map("Sunset Valley", MapType.Summer, 8, "", "", 40),
                new Map("Frostpeak Ridge", MapType.Winter, 9, "", "", 40)
            };
        }

        public List<Map> Maps()
        {
            return MapsList;
        }
    }
}
