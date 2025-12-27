using Domain.Helpers.CalculateTotalValueSoldHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Store
    {
        public int Id { get; set; }
        public IEnumerable<Weapon> Weapons { get; set; }
        public IEnumerable<Potion> Potions { get; set; }
        public int TotalValue => CalculateTotalValueSold.Calculate(Weapons, Potions);

        public Store() { }

        public Store(int id, IEnumerable<Weapon> weapons, IEnumerable<Potion> potions)
        {
            Id = id;
            Weapons = weapons;
            Potions = potions;
        }
    }
}
