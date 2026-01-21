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
                new Potion("Health Potion", 90, 120, 40),
                new Potion("Strength Potion", 120, 50, 30)
            };
        }
        public List<Potion> Potions()
        {
            return PotionList;
        }
    }
}
