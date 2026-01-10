using Domain.Helpers.NameOfTeamsHelper;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.NameOfTeamsPresentation
{
    public class NameOfTeamsPresentation
    {
        public TeamNames TeamsNameInput(Map selectedMap)
        {
            Console.WriteLine("- - - - - TEAM NAMES - - - - -");

            Console.WriteLine("Name of the blue team: ");
            string blueTeamName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Name of the red team: ");
            string redTeamName = Console.ReadLine() ?? string.Empty;

            while (redTeamName.Equals(blueTeamName, StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("The name is already taken, try again: ");
                redTeamName = Console.ReadLine() ?? string.Empty;
            }

            selectedMap.BlueTeam = blueTeamName;
            selectedMap.RedTeam = redTeamName;

            return new TeamNames
            {
                BlueName = blueTeamName,
                RedName = redTeamName
            };
        }
    }
}
