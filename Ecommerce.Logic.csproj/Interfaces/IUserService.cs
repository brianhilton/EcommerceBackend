using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Models;

namespace Ecommerce.Logic.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetUserByIDAsync(string id);
        public Task<User?> GetUserByNameAsync(string username);
        public Task<User?> CreateUserAsync(User user);
        public Task<User?> UpdateUserAsync(User user);
        public Task DeleteUserAsync(string id);


    }
}
