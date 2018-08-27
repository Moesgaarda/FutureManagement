using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext _dbContext;
        public UserRepository(DataContext dbContext){
            this._dbContext = dbContext;
        }

        public async Task<bool> ActivateUser(User user)
        {
            user.IsActive = true;
            _dbContext.Users.Update(user);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AddRole(UserRole newRole)
        {

            _dbContext.UserRoles.Add(newRole);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public Task<bool> AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeActivateUser(User user)
        {
            _dbContext.Users.Update(user);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EditRole(User user)
        {
            _dbContext.Users.Update(user);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> EditUser(User user)
        {
            var userToChange = _dbContext.Users.First(x => x.Id == user.Id);
            _dbContext.Entry(userToChange).CurrentValues.SetValues(user);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<User>> GetAllActiveUsers()
        {
            return await _dbContext.Users.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<User>> GetAllInactiveUsers()
        {
            return await _dbContext.Users.Where(x => x.IsActive == false).ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _dbContext.Users
                    .Where(x => x.Id == id)
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync();

            return user;
        }

        public Task<User> ShowDetails(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}