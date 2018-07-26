using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private DataContext _dbContext;
        public UserRepository(DataContext dbContext){
            this._dbContext = dbContext;
        }

        public Task<bool> ActivateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddRoles()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddUser()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeActivateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditRole(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<User>> GetAllInactiveUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> ShowDetails(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}