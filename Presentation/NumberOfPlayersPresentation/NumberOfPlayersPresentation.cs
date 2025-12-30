using Domain.Helpers.PlayerCountHelper;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.NumberOfPlayersPresentation
{
    public class NumberOfPlayersPresentation
    {
        public PlayerCount InputPlayersPerTeam(int maxPlayers)
        {
            while (true)
            {
                Console.WriteLine("Enter the number of players for the blue team: ");
                int blue = int.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Enter the number of players for the red team: ");
                int red = int.Parse(Console.ReadLine() ?? "");

                if (blue + red > maxPlayers)
                {
                    Console.WriteLine("Too many players. Please choose a different number.");
                    continue;
                }

                return new PlayerCount
                {
                    BlueTeam = blue,
                    RedTeam = red
                };
            }
        }
    }
}
