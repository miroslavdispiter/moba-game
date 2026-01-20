using Domain.Models;
using Domain.Results.AssignHeroResult;
using Domain.Results.TeamNamesHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IEnterPlayerName
    {
        public AssignHeroResult AssignHeroToPlayer(string teamName, string playerName, string heroName, Dictionary<string, Hero> dictResult);
    }

}
