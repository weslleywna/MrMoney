using MrMoney.Domain.Dtos;
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

        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password)) return null;

            var userAlreadyExists = await _userRepository.GetByUsername(userDto.Username);
            if (userAlreadyExists is not null) return null;

            var hashPassword = HashGeneration(userDto.Password);
            var user = new User { Name = userDto.Name, Username = userDto.Username, Password = hashPassword };

            await _userRepository.CreateAsync(user);

            return user;
        }

        public Task RemoveAsync(string id)
        {
            return _userRepository.RemoveAsync(id);
        }

        public Task UpdateAsync(string id, User updatedBook)
        {
            return _userRepository.UpdateAsync(id, updatedBook);
        }

        public async Task<bool> Login(UserDto userDto)
        {
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password)) return false;

            var user = await _userRepository.GetByUsername(userDto.Username);

            bool verified = BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password);

            return verified;
        }

        private static string HashGeneration(string password)
        {
            int workfactor = 16;

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        public Task CreateAsync(User newBook)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsername(username);
        }
    }
}
