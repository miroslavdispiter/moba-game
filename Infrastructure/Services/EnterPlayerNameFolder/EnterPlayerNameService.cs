using Domain.Models;
using Domain.Repositories;
using Domain.Results.AssignHeroResult;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.EnterPlayerNameFolder
{
    public class EnterPlayerNameService : IEnterPlayerName
    {
        private readonly IHeroRepository _heroRepository;

        public EnterPlayerNameService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public AssignHeroResult AssignHeroToPlayer(string id, string playerName, string heroName, Dictionary<string, Hero> currentDict)
        {
            Hero? selectedHero = _heroRepository.Heroes().FirstOrDefault(h => h.Name == heroName);

            if (selectedHero == null)
            {
                return new AssignHeroResult
                {
                    Success = false,
                    ErrorMessage = $"Hero with name '{heroName}' not found.",
                    Data = currentDict
                };
            }

            currentDict[playerName] = selectedHero;

            return new AssignHeroResult
            {
                Success = true,
                Data = currentDict
            };
        }
    }
}
