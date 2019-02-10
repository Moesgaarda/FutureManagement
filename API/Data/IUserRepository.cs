using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Models;

namespace API.Data
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllActiveUsers();  
        Task<List<User>> GetAllInactiveUsers();
        Task<User> GetUser(int id);
        Task<User> ShowDetails(User user);
        Task<bool> AddRoleCategory(RoleCategory newRoleCategory);
        Task<bool> AddRole(UserRole newRole);
        Task<List<RoleCategory>> GetRoleCategories();
        Task<bool> AddUser(User user);
        Task<bool> EditUser(User user, User userToChange);
        Task<bool> EditRole(User user);
        Task<bool> DeleteUser(User user);
        Task<bool> ActivateUser(User user);
        Task<bool> DeActivateUser(User user);
    }
}