using Domain.Models;
using Domain.Results.AssignHeroResult;
using Domain.Results.TeamNamesHelper;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.PlayerNamesPresentation
{
    public class PlayerNamesPresentation
    {
        private readonly IEnterPlayerName _playerNames;

        public PlayerNamesPresentation(IEnterPlayerName playerNames) 
        {
            _playerNames = playerNames;
        }

        /* Logika:
            1. Unesi naziv igraca
            2. Unesi naziv heroja
            3. Spakuj u dictionary
            */

        public Dictionary<string, Hero> EnterPlayersPresentation(string id, TeamNames teamNames, int numOfPlayers)
        {
            if (id == "blue")
            {
                Dictionary<string, Hero> playerHeroBlueDict = new Dictionary<string, Hero>();

                for (int i = 0; i < numOfPlayers; i++)
                {
                    Console.WriteLine($"[{teamNames.BlueName}]");

                    Console.WriteLine($"Unesi naziv {i + 1} igraca: ");
                    string playerName = Console.ReadLine() ?? "";

                    Console.WriteLine($"[{playerName}] Heroj: ");
                    string heroName = Console.ReadLine() ?? "";

                    AssignHeroResult result = _playerNames.AssignHeroToPlayer(id, playerName, heroName, playerHeroBlueDict);

                    if (result.Success)
                    {
                        playerHeroBlueDict = result.Data;
                        Console.WriteLine($"{playerName} uspesno je odabrao heroja {heroName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Greska: {result.ErrorMessage}");
                        i--;
                    }
                }

                return playerHeroBlueDict;
            }
            else if (id == "red")
            {
                Dictionary<string, Hero> playerHeroRedDict = new Dictionary<string, Hero>();

                for (int i = 0; i < numOfPlayers; i++)
                {
                    Console.WriteLine($"[{teamNames.RedName}]");

                    Console.WriteLine($"Unesi naziv {i + 1} igraca: ");
                    string playerName = Console.ReadLine() ?? "";

                    Console.WriteLine($"[{playerName}] Heroj: ");
                    string heroName = Console.ReadLine() ?? "";

                    AssignHeroResult result = _playerNames.AssignHeroToPlayer(id, playerName, heroName, playerHeroRedDict);

                    if (result.Success)
                    {
                        playerHeroRedDict = result.Data;
                        Console.WriteLine($"{playerName} uspesno je odabrao heroja {heroName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Greska: {result.ErrorMessage}");
                        i--;
                    }
                }
                return playerHeroRedDict;
            }
            else
            {
                Console.WriteLine("Mistake.");
                return new Dictionary<string, Hero>();
            }
    }
    }
}
