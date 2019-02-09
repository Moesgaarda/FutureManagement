using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext _dbContext;
        private readonly RoleManager<Role> _roleManager;
        public UserRepository(DataContext dbContext, RoleManager<Role> roleManager){
            this._dbContext = dbContext;
            this._roleManager = roleManager;
        }

        public async Task<bool> ActivateUser(User user)
        {
            user.IsActive = true;
            _dbContext.Users.Update(user);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AddRoleCategory(RoleCategory newRoleCategory)
        {
            foreach(var role in newRoleCategory.RoleCategoryRoleRelations){
                role.Role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == role.RoleId);
            }

            _dbContext.RoleCategories.Add(newRoleCategory);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> AddRole(UserRole newRole)
        {

            _dbContext.UserRoles.Add(newRole);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<RoleCategory>> GetRoleCategories()
        {
            return await _dbContext.RoleCategories.ToListAsync();
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

        public async Task<bool> EditUser(User user, User userToChange)
        {
            _dbContext.Entry(userToChange).CurrentValues.SetValues(user);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<User>> GetAllActiveUsers()
        {
            List<User> users = await _dbContext.Users
                .Where(x => x.IsActive == true)
                .Include(x => x.UserRoles)
                .ToListAsync();
            return users;
        }

        public async Task<List<User>> GetAllInactiveUsers()
        {
            return await _dbContext.Users
                .Where(x => x.IsActive == false)
                .Include(x => x.UserRoles)
                .ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _dbContext.Users
                    .Where(x => x.Id == id)
                    .Include(x => x.UserRoles)
                    .FirstOrDefaultAsync();
            return user;
        }

        public Task<User> ShowDetails(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}