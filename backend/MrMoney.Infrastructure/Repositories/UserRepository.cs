using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Models;
using MrMoney.Infrastructure.Data;

namespace MrMoney.Infrastructure.Repositories
{
    public class UserRepository : MongoDbContext<User>, IUserRepository
    {
        public async Task<List<User>> GetAsync() =>
            await Collection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User newBook) =>
            await Collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, User updatedBook) =>
            await Collection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await Collection.DeleteOneAsync(x => x.Id == id);
    }
}
