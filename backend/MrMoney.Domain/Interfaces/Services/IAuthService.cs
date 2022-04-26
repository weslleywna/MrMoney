using MrMoney.Domain.Dtos;
using MrMoney.Domain.Models;

namespace MrMoney.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string id);
        Task<User> CreateUserAsync(UserDto userDto);
        Task UpdateAsync(string id, User updatedBook);
        Task RemoveAsync(string id);
        Task<bool> Login(UserDto userDto);
    }
}
