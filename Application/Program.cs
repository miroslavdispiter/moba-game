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
using Infrastructure.Services.EnterPlayerNameFolder;
using Infrastructure.Services.GenerateEntityFolder;
using Infrastructure.Services.SelectMapFolder;
using Infrastructure.Services.SelectStoreFolder;
using Presentation.AuthentificationFolderPresentation;
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
            List<Entity> entities = entityPresentation.GenerateEntities();

            Console.WriteLine($"Generated {entities.Count} entities.");

            // SELECT MAP
            IMapRepository mapRepository = new MapRepository();
            ISelectMap selectMapService = new SelectMapService(mapRepository);
            SelectMapPresentation selectMapPresentation = new SelectMapPresentation(selectMapService);
            Map? chosenMap = selectMapPresentation.EnterMap();

            if (chosenMap != null)
            {
                Console.WriteLine($"You selected: {chosenMap.Name}");
            }

            // SELECT SHOP
            IStoreRepository storeRepository = new StoreRepository();
            ISelectStore selectStoreService = new SelectStoreService(storeRepository);
            SelectStorePresentation selectStorePresentation = new SelectStorePresentation(selectStoreService);
            Store? chosenStore = selectStorePresentation.EnterStoreId();

            if (chosenStore != null)
            {
                Console.WriteLine($"You selected store: {chosenStore.Id}");
            }

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
            // ovo verovatno treba da ide u neki service
            Random rnd = new Random();
            int seconds = rnd.Next(3, 8);
            Console.WriteLine($"Bitka u toku. Trajace {seconds} sekundi.");
            Thread.Sleep(seconds * 1000);

            IAttack attackService = new AttackService(entities, chosenStore);
            IBattle battleService = new BattleService(attackService);
            battleService.StartBattle(bluePlayers, redPlayers);

            // STATISTICS
        }
    }
}
