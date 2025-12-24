using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PotionRepositoryFolder
{
    public class PotionRepository : IPotionRepository
    {
        private static readonly List<Potion> PotionList;

        static PotionRepository()
        {
            PotionList = new List<Potion>()
            {
                new Potion("Health Potion", 50, 40, 10),
                new Potion("Mana Potion", 40, 25, 8),
                new Potion("Energy Drink", 30, 23, 5),
                new Potion("Shield Potion", 60, 35, 4)
            };
        }
        public List<Potion> Potions()
        {
            return PotionList;
        }
    }
}
