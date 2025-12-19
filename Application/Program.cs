using Domain.Services;
using Services.AuthentificationFolder;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AUTHENTIFICATION

            IAuthentification auth = new AuthentificationService();

            Console.WriteLine("\n--- LOGIN ---\n");

            while (true)
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine();

                if (auth.Login(username, password) == null)
                {
                    Console.WriteLine("Wrong username or password.");
                }
                else
                {
                    Console.WriteLine("Successful login.");
                    break;
                }
            }
        }
    }
}
