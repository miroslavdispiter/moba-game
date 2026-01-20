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
                new Potion("Health Potion", 70, 50, 10),
                new Potion("Strength Potion", 70, 0, 10)
            };
        }
        public List<Potion> Potions()
        {
            return PotionList;
        }
    }
}
