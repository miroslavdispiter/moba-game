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
                    new Weapon("Mace", 100, 20, 5),
                    new Weapon("Sword", 150, 30, 3),
                    new Weapon("Bow", 120, 25, 7)
                },
                new List<Potion>()
                {
                    new Potion("Health Potion", 50, 40, 10),
                    new Potion("Mana Potion", 40, 25, 8),
                    new Potion("Speed Brew", 45, 30, 6)
                }),

                new Store(2, new List<Weapon>()
                {
                    new Weapon("Dagger", 80, 15, 10),
                    new Weapon("Axe", 130, 28, 4),
                    new Weapon("Crossbow", 140, 27, 6)
                },
                new List<Potion>()
                {
                    new Potion("Energy Drink", 30, 40, 5),
                    new Potion("Shield Potion", 60, 20, 4),
                    new Potion("Invisibility Elixir", 70, 20, 3)
                }),
            };
        }
        public List<Store> Stores()
        {
            return StoresList;
        }
    }
}
