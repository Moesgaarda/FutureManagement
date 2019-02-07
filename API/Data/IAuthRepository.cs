using System.Threading.Tasks;
using API.Models;
using System.Collections.Generic;

namespace API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        //List<Role> GetRoles(ICollection<RoleCategory> roleCategories);
    }
}