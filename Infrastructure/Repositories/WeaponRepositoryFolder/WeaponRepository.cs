using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.WeaponRepositoryFolder
{
    public class WeaponRepository : IWeaponRepository
    {
        private static readonly List<Weapon> WeaponList;

        static WeaponRepository()
        {
            WeaponList = new List<Weapon>()
            {
                new Weapon("Mace", 100, 20, 5),
                new Weapon("Sword", 150, 30, 3),
                new Weapon("Bow", 120, 25, 7),
                new Weapon("Dagger", 80, 15, 10),
                new Weapon("Axe", 130, 28, 4),
                new Weapon("Crossbow", 140, 27, 6)
            };
        }

        public List<Weapon> Weapons()
        {
            return WeaponList;
        }
    }
}
