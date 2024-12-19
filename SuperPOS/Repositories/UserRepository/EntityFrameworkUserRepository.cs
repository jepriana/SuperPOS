using SuperPOS.Data;
using SuperPOS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperPOS.Repositories.UserRepository
{
    internal class EntityFrameworkUserRepository : IUserRepository
    {
        private readonly SuperPosDataContext _dbContext;

        public EntityFrameworkUserRepository(SuperPosDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(User newUser)
        {
            try
            {
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var selectedUser = await GetAsync(id);
                if (selectedUser != null)
                {
                    _dbContext.Users
                        .Remove(selectedUser);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync(string keyword = "")
        {
            try
            {
                return await _dbContext.Users
                  .Where(d => string.IsNullOrEmpty(keyword) ||
                    d.Username.ToLower().Contains(keyword.ToLower()) ||
                    d.Firstname.ToLower().Contains(keyword.ToLower()) ||
                    d.Lastname.ToLower().Contains(keyword.ToLower()))
                  .AsNoTracking()
                  .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetAsync(int id)
        {
            try
            {
                return await _dbContext.Users
                    .FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            try
            {
                return await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(User updatedUser)
        {
            try
            {
                _dbContext.Users
                    .AddOrUpdate(updatedUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
