using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Hero
    {
        public string Name { get; set; } = string.Empty;
        public int HealthPoints { get; set; }
        public int AttackPower { get; set; }
        public int Gold { get; set; }

        public Hero() { }

        public Hero(string name, int hp, int ap, int gold)
        {
            Name = name;
            HealthPoints = hp;
            AttackPower = ap;
            Gold = gold;
        }
    }
}