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
                // first shop
                new Weapon("Mace", 100, 30, 10),
                new Weapon("Sword", 150, 50, 10),
                new Weapon("Bow", 120, 40, 10),
                // second shop
                new Weapon("Dagger", 100, 30, 10),
                new Weapon("Axe", 150, 50, 10),
                new Weapon("Crossbow", 120, 40, 10)
            };
        }

        public List<Weapon> Weapons()
        {
            return WeaponList;
        }
    }
}
