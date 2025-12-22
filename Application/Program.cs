using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Services.AuthentificationFolder;
using Presentation.AuthentificationFolderPresentation;

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
        }
    }
}
