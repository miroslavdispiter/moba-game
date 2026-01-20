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
                new Hero("Malphite", 1250, 50, 0),
                new Hero("Zac", 1100, 50, 0),
                new Hero("Ahri", 750, 65, 0),
                new Hero("Ezreal", 700, 80, 0),
                new Hero("Nami", 850, 40, 0),
                new Hero("Orn", 1400, 50, 0),
                new Hero("Elise", 1000, 50, 0),
                new Hero("Yasuo", 800, 70, 0),
                new Hero("Jhin", 750, 80, 0),
                new Hero("Blitzcrank", 950, 45, 0)
            };
        }

        public List<Hero> Heroes()
        {
            return HeroesList;
        }
    }
}
