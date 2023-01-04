using MongoDB.Driver;
using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Models;
using MrMoney.Infrastructure.Data;

namespace MrMoney.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {        
        public async Task<User> GetByUsername(string username)
        {
            return await Collection.Find(user => user.Username == username).FirstOrDefaultAsync();
        }

    }
}
