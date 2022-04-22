using MrMoney.Domain.Models;

namespace MrMoney.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string id);
        Task CreateAsync(User newBook);
        Task UpdateAsync(string id, User updatedBook);
        Task RemoveAsync(string id);
    }
}
