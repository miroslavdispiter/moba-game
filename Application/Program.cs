using Domain.Models;
using Domain.Repositories;
using Domain.Results.PlayerCountHelper;
using Domain.Results.TeamNamesHelper;
using Domain.Services;
using Infrastructure.Repositories.HeroRepositoryFolder;
using Infrastructure.Repositories.MapRepositoryFolder;
using Infrastructure.Repositories.StoreRepositoryFolder;
using Infrastructure.Services.AttackFolder;
using Infrastructure.Services.AuthentificationFolder;
using Infrastructure.Services.BattleServiceFolder;
using Infrastructure.Services.BattleStatisticsFolder;
using Infrastructure.Services.EnterPlayerNameFolder;
using Infrastructure.Services.GenerateEntityFolder;
using Infrastructure.Services.SelectMapFolder;
using Infrastructure.Services.SelectStoreFolder;
using Infrastructure.Services.StoreProviderFolder;
using Presentation.AuthentificationFolderPresentation;
using Presentation.BattleStatisticsPresentation;
using Presentation.EntityPresentation;
using Presentation.NameOfTeamsPresentation;
using Presentation.NumberOfPlayersPresentation;
using Presentation.PlayerNamesPresentation;
using Presentation.SelectMapPresentation;
using Presentation.SelectStorePresentation;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AUTHENTIFICATION
            IUserRepository userRepository = new UserRepository();
            IAuthentification authService = new AuthentificationService(userRepository);
            AuthentificationPresentation authPresentation = new AuthentificationPresentation(authService);
            User? loggedUser = authPresentation.Login();

            // ENTITY GENERATION
            IGenerateEntity generateEntity = new GenerateEntity();
            EntityPresentation entityPresentation = new EntityPresentation(generateEntity);
            List<Entity> entities = entityPresentation.EnterNumOfEntities();

            // SELECT MAP
            IMapRepository mapRepository = new MapRepository();
            ISelectMap selectMapService = new SelectMapService(mapRepository);
            SelectMapPresentation selectMapPresentation = new SelectMapPresentation(selectMapService);
            Map? chosenMap = selectMapPresentation.EnterMap();

            // SELECT SHOP
            IStoreRepository storeRepository = new StoreRepository();
            ISelectStore selectStoreService = new SelectStoreService(storeRepository);
            SelectStorePresentation selectStorePresentation = new SelectStorePresentation(selectStoreService);
            Store? chosenStore = selectStorePresentation.EnterStoreId();

            // NUMBER OF PLAYERS IN THE TEAM
            NumberOfPlayersPresentation numberOfPlayersPresentation = new NumberOfPlayersPresentation();
            PlayerCount playerCount = numberOfPlayersPresentation.InputPlayersPerTeam(chosenMap.MaxPlayers);

            // NAMES OF THE BLUE AND THE RED TEAM
            NameOfTeamsPresentation nameOfTeamsPresentation = new NameOfTeamsPresentation();
            TeamNames teamNames = nameOfTeamsPresentation.TeamsNameInput(chosenMap);

            // NAMES OF PLAYERS AND HEROES IN BLUE AND THEN RED TEAM
            IHeroRepository heroRepository = new HeroRepository();
            IEnterPlayerName enterPlayerNameService = new EnterPlayerNameService(heroRepository);
            PlayerNamesPresentation playerNamesPresentation = new PlayerNamesPresentation(enterPlayerNameService);

            Dictionary<string, Hero> bluePlayers = playerNamesPresentation.EnterPlayersPresentation("blue", teamNames, playerCount.BlueTeam);
            Dictionary<string, Hero> redPlayers = playerNamesPresentation.EnterPlayersPresentation("red", teamNames, playerCount.RedTeam);

            // FIGHT SIMULATION -> 10-45sec

            IStoreProvider storeProvider = new StoreProviderService(chosenStore);
            IAttack attackService = new AttackService(entities, storeProvider);
            IBattle battleService = new BattleService(attackService);
            battleService.StartBattle(bluePlayers, redPlayers);

            // STATISTICS
            // Must fix DI problem later
            
            IBattleStatistics battleStatisticsService = new BattleStatisticsService();
            BattleStatisticsPresentation battleStatsPresentation = new BattleStatisticsPresentation(battleStatisticsService);
            battleStatsPresentation.ChooseOutputAndShow(bluePlayers.Values.ToList(), redPlayers.Values.ToList(), chosenMap, chosenStore);
        }
    }
}
