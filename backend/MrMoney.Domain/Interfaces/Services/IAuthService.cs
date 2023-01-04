using MrMoney.Domain.Dtos;
using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Models;

namespace MrMoney.Domain.Interfaces.Services
{
    public interface IAuthService : IRepositoryBase<User>
    {
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string id);
        Task<User?> GetByUsernameAsync(string id);
        Task<User?> CreateUserAsync(UserDto userDto);
        Task UpdateAsync(string id, User updatedBook);
        Task RemoveAsync(string id);
        Task<string> Login(UserDto userDto);
    }
}
