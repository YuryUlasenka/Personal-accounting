using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(user => user.UserName)
                .ToListAsync();
        }

        public async Task<User> GetUserById(string id, bool trackChanges)
        {
            return await FindByCondition(user => user.Id == id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUserName(string userName, bool trackChanges)
        {
            return await FindByCondition(user => user.UserName == userName, trackChanges).SingleOrDefaultAsync();
        }
    }
}