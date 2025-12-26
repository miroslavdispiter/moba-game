using Domain.Enums;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HeroRepositoryFolder
{
    public class HeroRepository : IHeroRepository
    {
        private static readonly List<Hero> HeroesList;

        static HeroRepository()
        {
            HeroesList = new List<Hero>()
            {
                new Hero("Malphite", 1250, 120, 0),
                new Hero("Zac", 1100, 95, 0),
                new Hero("Ahri", 900, 135, 0),
                new Hero("Ezreal", 870, 175, 0),
                new Hero("Nami", 780, 120, 0),
                new Hero("Orn", 1350, 110, 0),
                new Hero("Elise", 950, 120, 0),
                new Hero("Yasuo", 900, 160, 0),
                new Hero("Jhin", 860, 180, 0),
                new Hero("Blitzcrank", 950, 90, 0)
            };
        }

        public List<Hero> Heroes()
        {
            return HeroesList;
        }
    }
}
