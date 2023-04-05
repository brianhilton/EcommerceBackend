using Ecommerce.Common.Models;
using Ecommerce.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Logic.Services
{
    public class UserService : IUserService
    {
        public Task<User?> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIDAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByNameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
