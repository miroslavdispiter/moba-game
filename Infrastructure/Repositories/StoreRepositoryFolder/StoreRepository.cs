using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.StoreRepositoryFolder
{
    public class StoreRepository : IStoreRepository
    {
        private readonly static List<Store> StoresList;
        static StoreRepository()
        {
            StoresList = new List<Store>()
            {
                new Store(1, new List<Weapon>()
                {
                    new Weapon("Mace", 150, 60, 25),
                    new Weapon("Sword", 200, 80, 25),
                    new Weapon("Longbow", 180, 70, 25)
                },
                new List<Potion>()
                {
                    new Potion("Health Potion", 90, 120, 40),
                    new Potion("Strength Potion", 120, 50, 30)
                }),

                new Store(2, new List<Weapon>()
                {
                    new Weapon("Dagger", 100, 45, 25),
                    new Weapon("Axe", 220, 90, 25),
                    new Weapon("Crossbow", 170, 75, 25)
                },
                new List<Potion>()
                {
                    new Potion("Health Potion", 90, 120, 40),
                    new Potion("Strength Potion", 120, 50, 30)
                }),
            };
        }
        public List<Store> Stores()
        {
            return StoresList;
        }
    }
}
