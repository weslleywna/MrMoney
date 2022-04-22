using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Interfaces.Services;
using MrMoney.Domain.Models;

namespace MrMoney.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAsync() => await _userRepository.GetAsync();

        public async Task<User?> GetAsync(string id)
        {
            return await _userRepository.GetAsync(id);
        }

        public Task CreateAsync(User newBook)
        {
            return _userRepository.CreateAsync(newBook);
        }

        public Task RemoveAsync(string id)
        {
            return _userRepository.RemoveAsync(id);
        }

        public Task UpdateAsync(string id, User updatedBook)
        {
            return _userRepository.UpdateAsync(id, updatedBook);
        }
    }
}
