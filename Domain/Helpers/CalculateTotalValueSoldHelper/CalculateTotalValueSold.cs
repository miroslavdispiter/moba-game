using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers.CalculateTotalValueSoldHelper
{
    public class CalculateTotalValueSold
    {
        public static int Calculate(IEnumerable<Weapon> weapons, IEnumerable<Potion> potions)
        {
            int totalValueWeapons = weapons.Sum(w => w.Price * w.AvailableQuantity);
            int totalValuePotions = potions.Sum(p => p.Price * p.AvailableQuantity);
            return totalValuePotions + totalValueWeapons;
        }
    }
}
