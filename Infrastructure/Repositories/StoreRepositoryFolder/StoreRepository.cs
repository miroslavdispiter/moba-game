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
                    new Weapon("Mace", 100, 30, 10),
                    new Weapon("Sword", 150, 50, 10),
                    new Weapon("Bow", 120, 40, 10)
                },
                new List<Potion>()
                {
                    new Potion("Health Potion", 70, 50, 10),
                    new Potion("Strength Potion", 70, 50, 10)
                }),

                new Store(2, new List<Weapon>()
                {
                    new Weapon("Dagger", 100, 30, 10),
                    new Weapon("Axe", 150, 50, 10),
                    new Weapon("Crossbow", 120, 40, 10)
                },
                new List<Potion>()
                {
                    new Potion("Health Potion", 70, 50, 10),
                    new Potion("Strength Potion", 70, 0, 10)
                }),
            };
        }
        public List<Store> Stores()
        {
            return StoresList;
        }
    }
}
