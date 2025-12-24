using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Weapon
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int IncreaseAttack { get; set; }
        public int AvailableQuantity { get; set; }

        public Weapon() { }

        public Weapon(string name, int price, int increaseAttack, int availableQuantity)
        {
            Name = name;
            Price = price;
            IncreaseAttack = increaseAttack;
            AvailableQuantity = availableQuantity;
        }
    }
}
