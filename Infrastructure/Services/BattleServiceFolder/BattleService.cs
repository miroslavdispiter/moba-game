using Domain.Models;
using Domain.Services;
using Infrastructure.Services.AttackFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.BattleServiceFolder
{
    public class BattleService : IBattle
    {
        private readonly IAttack _attack;
        private readonly Random _rand = new Random();
        public BattleService(IAttack attack) 
        {
            _attack = attack;
        }

        // main logika:
        /*
            1. Bitka traje dok neki tim ne izgubi sve igrace
            2. Bira se random igrac iz oba tima koji ce izvrsiti akciju.
            3. Random je izbor da li ce igrac udariti entitet ili heroja.
            4. Ako izabere da udari entitet, bira se entitet iz mape i koristi AttackEntity() da izvrsi napad (u jednom udarcu ubija entiteta)
            5. Ako izabere da udari heroja, bira se random protivnicki igrac i koristi AttackHero() da izvrsi napad (radi mu damage).
            6. Na kraju svakog kruga, proverava se da li je neki tim izgubio sve igrace.
         */

        public void StartBattle(Dictionary<string, Hero> teamBlue, Dictionary<string, Hero> teamRed)
        {
            // This fight simulation time will not be in this method in the final version
            Random rnd = new Random();
            int seconds = rnd.Next(3, 8);
            Console.WriteLine($"Bitka u toku. Trajaće {seconds} sekundi.");
            Thread.Sleep(seconds * 1000);

            List<Hero> bluesList = teamBlue.Values.ToList();
            List<Hero> redList = teamRed.Values.ToList(); 

            while (bluesList.Count > 0 && redList.Count > 0)
            {
                int teamAttacking = _rand.Next(0, 2); // 0-blue, 1-red

                if (teamAttacking == 0)
                {
                    int heroAttacking = _rand.Next(0, bluesList.Count);
                    Hero attacker = bluesList[heroAttacking];

                    int attackType = _rand.Next(0, 2); // 0-entity, 1-hero

                    if (attackType == 0)
                    {
                        _attack.AttackEntity(attacker);
                    }
                    else
                    {
                        int heroDefending = _rand.Next(0, redList.Count);
                        Hero defender = redList[heroDefending];

                        _attack.AttackHero(attacker, defender);

                        if (defender.HealthPoints <= 0)
                        {
                            defender.HealthPoints = 0;
                            redList.Remove(defender);
                        }
                    }
                }
                else
                {
                    int heroAttacking = _rand.Next(0, redList.Count);
                    Hero attacker = redList[heroAttacking];

                    int attackType = _rand.Next(0, 2); // 0-entity, 1-hero

                    if (attackType == 0)
                    {
                        _attack.AttackEntity(attacker);
                    }
                    else
                    {
                        int heroDefending = _rand.Next(0, bluesList.Count);
                        Hero defender = bluesList[heroDefending];

                        _attack.AttackHero(attacker, defender);

                        if (defender.HealthPoints <= 0)
                        {
                            defender.HealthPoints = 0;
                            bluesList.Remove(defender);
                        }
                    }
                }
            }

            if (bluesList.Count == 0)
                Console.WriteLine($"Battle ended! Red team is winner.");
            else 
                Console.WriteLine($"Battle ended! Blue team is winner.");
        }
    }
}
