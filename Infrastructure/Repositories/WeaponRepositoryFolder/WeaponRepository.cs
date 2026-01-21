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
                new Weapon("Mace", 150, 60, 25),
                new Weapon("Sword", 200, 80, 25),
                new Weapon("Longbow", 180, 70, 25),
                // second shop
                new Weapon("Dagger", 100, 45, 25),
                new Weapon("Axe", 220, 90, 25),
                new Weapon("Crossbow", 170, 75, 25)
            };
        }

        public List<Weapon> Weapons()
        {
            return WeaponList;
        }
    }
}
