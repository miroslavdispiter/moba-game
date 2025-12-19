using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> UsersList;
        static UserRepository()
        {
            UsersList = new List<User>()
            {
                new User("d1p0", "123", "Miroslav Dispiter"),
                new User("admin", "123", "Miroslav Dispiter")
            };
        }

        public List<User> Users()
        {
            return UsersList;
        }
    }
}
