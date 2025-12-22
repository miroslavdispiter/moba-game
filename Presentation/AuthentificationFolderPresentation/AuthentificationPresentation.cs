using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.AuthentificationFolderPresentation
{
    public class AuthentificationPresentation
    {
        private readonly IAuthentification _authentification;

        public AuthentificationPresentation(IAuthentification authentification)
        {
            _authentification = authentification;
        }

        public User? Login()
        {

            Console.WriteLine("\n--- LOGIN ---\n");

            while (true)
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                Console.WriteLine("Password: ");
                string password = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                User? loggedUser = _authentification.LoginUser(username, password);

                if (loggedUser == null)
                {
                    Console.WriteLine("Wrong username or password.");
                }
                else
                {
                    Console.WriteLine("Successful login.");
                    return loggedUser;
                }
            }
        }
    }
}
