using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);

        Task<User> GetUserById(string id, bool trackChanges);

        Task<User> GetUserByUserName(string userName, bool trackChanges);

        void DeleteUser(User user);
    }
}
