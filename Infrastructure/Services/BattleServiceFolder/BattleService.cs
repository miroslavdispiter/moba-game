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

        // main logic:
        /*
            1. The battle continues until one team loses all its players.
            2. A random player from each team is chosen to perform an action.
            3. It is randomly decided whether the player attacks an entity or an enemy hero.
            4. If the player attacks an entity, a map entity is selected and AttackEntity() is used to perform the attack (the entity is killed in one hit).
            5. If the player attacks a hero, a random opposing player is selected and AttackHero() is used to perform the attack (dealing damage).
            6. At the end of each round, the program checks whether any team has lost all its players.
        */
        public void StartBattle(Dictionary<string, Hero> teamBlue, Dictionary<string, Hero> teamRed)
        {
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
