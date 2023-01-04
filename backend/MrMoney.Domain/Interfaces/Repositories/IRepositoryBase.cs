using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrMoney.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAsync();
        Task<TEntity?> GetAsync(string id);
        Task CreateAsync(TEntity newBook);
        Task UpdateAsync(string id, TEntity updatedBook);
        Task RemoveAsync(string id);
        Task<TEntity> GetByIdAsync(string id);
    }
}
