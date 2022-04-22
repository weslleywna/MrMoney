using MrMoney.Domain.Models;

namespace MrMoney.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string id);
        Task CreateAsync(User newBook);
        Task UpdateAsync(string id, User updatedBook);
        Task RemoveAsync(string id);
    }
}
