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
        public int TotalValueSold { get; set; }

        public Store() { }

        public Store(int id, IEnumerable<Weapon> weapons, IEnumerable<Potion> potions, int totalValueSold)
        {
            Id = id;
            Weapons = weapons;
            Potions = potions;
            TotalValueSold = totalValueSold;
        }
    }
}
