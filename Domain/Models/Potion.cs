using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Potion
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public int IncreaseAttack { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
