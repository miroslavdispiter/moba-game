using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.AuthentificationFolder
{
    public class AuthentificationService : IAuthentification
    {
        IUserRepository _userRepository = new UserRepository();

        public AuthentificationService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public User? LoginUser(string username, string password)
        {
            User? user = _userRepository.Users().FirstOrDefault(u => u.Username.Equals(username));

            if (user == null)
            {
                return null;
            }

            if (!user.Password.Equals(password))
            {
                return null;
            }

            return user;
        }
    }
}
