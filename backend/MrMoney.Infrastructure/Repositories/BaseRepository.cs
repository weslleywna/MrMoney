using MongoDB.Driver;
using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrMoney.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : MongoDbContext<TEntity>, IRepositoryBase<TEntity> where TEntity : class, new()
    {
        public async Task<List<TEntity>> GetAsync() =>
            await Collection.Find(_ => true).ToListAsync();

        public async Task<TEntity?> GetAsync(string id) =>
            await Collection.Find(x => x.GetType().GetProperty("Id").Name == id).FirstOrDefaultAsync();

        public async Task<TEntity?> GetByIdAsync(string id) =>
            await Collection.Find(Builders<TEntity>.Filter.Eq($"{{_id}}", id)).FirstOrDefaultAsync();

        public async Task CreateAsync(TEntity newBook) =>
            await Collection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, TEntity updatedBook) =>
            await Collection.ReplaceOneAsync(x => x.GetType().GetProperty("Id").Name == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await Collection.DeleteOneAsync(x => x.GetType().GetProperty("Id").Name == id);
    }
}
