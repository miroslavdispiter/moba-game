using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Services.AuthentificationFolder;
using Infrastructure.Services.GenerateEntityFolder;
using Presentation.AuthentificationFolderPresentation;
using Presentation.EntityPresentation;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AUTHENTIFICATION
            IUserRepository userRepository = new UserRepository();
            IAuthentification auth = new AuthentificationService(userRepository);
            var authPresentation = new AuthentificationPresentation(auth);
            User? loggedUser = authPresentation.Login();

            // ENTITY GENERATION
            IGenerateEntity generateEntity = new GenerateEntity();
            var entityPresentation = new EntityPresentation(generateEntity);
            var entities = entityPresentation.GenerateEntities();

            Console.WriteLine($"Generated {entities.Count} entities.");
        }
    }
}
