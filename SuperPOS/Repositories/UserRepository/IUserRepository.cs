using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SuperPOS.Models;

namespace SuperPOS.Repositories.UserRepository
{
    internal interface IUserRepository
    {
        Task CreateAsync(User newUser);
        Task DeleteAsync(int id);
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync(string keyword = "");
        Task UpdateAsync(User updatedUser);
        Task<User> GetByUsernameAsync(string username);
    }
}
