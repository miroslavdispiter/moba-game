using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Repositories.MapRepositoryFolder;
using Infrastructure.Repositories.StoreRepositoryFolder;
using Infrastructure.Services.AuthentificationFolder;
using Infrastructure.Services.GenerateEntityFolder;
using Infrastructure.Services.SelectMapFolder;
using Infrastructure.Services.SelectStoreFolder;
using Presentation.AuthentificationFolderPresentation;
using Presentation.EntityPresentation;
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
            var authPresentation = new AuthentificationPresentation(authService);
            User? loggedUser = authPresentation.Login();

            // ENTITY GENERATION
            IGenerateEntity generateEntity = new GenerateEntity();
            var entityPresentation = new EntityPresentation(generateEntity);
            var entities = entityPresentation.GenerateEntities();

            Console.WriteLine($"Generated {entities.Count} entities.");

            // SELECT MAP
            IMapRepository mapRepository = new MapRepository();
            ISelectMap selectMapService = new SelectMapService(mapRepository);
            var selectMapPresentation = new SelectMapPresentation(selectMapService);
            Map? chosenMap = selectMapPresentation.EnterMap();

            if (chosenMap != null)
            {
                Console.WriteLine($"You selected: {chosenMap.Name}");
            }

            // SELECT SHOP
            IStoreRepository storeRepository = new StoreRepository();
            ISelectStore selectStoreService = new SelectStoreService(storeRepository);
            var selectStorePresentation = new SelectStorePresentation(selectStoreService);
            Store? chosenStore = selectStorePresentation.EnterStoreId();

            if (chosenStore != null)
            {
                Console.WriteLine($"You selected store: {chosenStore.Id}");
            }

            // NUMBER OF PLAYERS IN THE TEAM

            // NAMES OF PLAYERS IN BLUE AND THEN RED TEAM

            // FIGHT SIMULATION -> 10-45sec

            // STATISTICS
        }
    }
}
