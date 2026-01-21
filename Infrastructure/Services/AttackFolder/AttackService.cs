using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.AttackFolder
{
    public class AttackService : IAttack
    {
        private List<Entity> _entities = new List<Entity>();
        private List<Weapon> _weapons;
        private List<Potion> _potions;
        private Store _store;
        private Random _rand = new Random();
        static int entitet = 0;

        public AttackService(IEnumerable<Entity> entities, Store store)
        {
            _store = store;
            _entities = entities.ToList();
            _weapons = store.Weapons.ToList();
            _potions = store.Potions.ToList();
        }

        public void AttackEntity(Hero attacker)
        {
            if (_entities.Count == 0) {
                Console.WriteLine("1. Entiteta vise nema, pa nema sta da napadne.\n");
                return;
            }

            entitet++;

            Console.WriteLine($"0. Ubijen {entitet}. entitet.");

            attacker.Gold += _entities[0].Value;
            _entities.RemoveAt(0);
        }

        public void AttackHero(Hero attacker, Hero defender)
        {
            int lucky = 0;

            if (defender.HealthPoints <= 400 && defender.HealthPoints > 0)
            {
                var potion = _store.Potions.FirstOrDefault(p => p.Name == "Health Potion");
                
                // Fix this exception after
                if (potion == null)
                {
                    throw new Exception("Potion not found in store.");
                }

                if (defender.Gold > potion.Price && potion.AvailableQuantity > 0)
                {
                    defender.HealthPoints += potion.IncreaseHealth;
                    defender.Gold -= potion.Price;
                    potion.AvailableQuantity--;
                    Console.WriteLine("2. Health potion bought.");
                }
            }

            if (lucky == 3)
            {
                Potion? potion = _potions.FirstOrDefault(p => p.Name == "Strength Potion");
                if (attacker.Gold > potion?.Price && potion.AvailableQuantity > 0)
                {
                    attacker.AttackPower += potion.IncreaseHealth; // Increase attack power, not health
                    potion.AvailableQuantity--;
                    Console.WriteLine("3. Strength potion bought.");
                }
                lucky = 0;
            }

            defender.HealthPoints -= attacker.AttackPower;
            Console.WriteLine("4. Attacker attacked defender.");

            if (attacker.Gold >= 500)
            {
                int randomWeapon = _rand.Next(0, _weapons.Count);
                Weapon? weapon = _weapons[randomWeapon];

                if (attacker.Gold >= weapon.Price && weapon.AvailableQuantity > 0)
                {
                    Console.WriteLine("5. Attacker bought something in a shop.");
                    attacker.AttackPower += weapon.IncreaseAttack;
                    attacker.Gold -= weapon.Price;
                    weapon.AvailableQuantity--;
                }
            }

            lucky++;
        }
    }
}
