using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MrMoney.Domain.Dtos;
using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Interfaces.Services;
using MrMoney.Domain.Models;
using MrMoney.Util.Global;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MrMoney.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<MyOptions> _tokenKey;

        public AuthService(IUserRepository userRepository, IOptions<MyOptions> tokenKey)
        {
            _userRepository = userRepository;
            _tokenKey = tokenKey;
        }

        public async Task<List<User>> GetAsync() => await _userRepository.GetAsync();

        public async Task<User?> GetAsync(string id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User?> CreateUserAsync(UserDto userDto)
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

        public async Task<string> Login(UserDto userDto)
        {
            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password)) return string.Empty;

            var user = await _userRepository.GetByUsername(userDto.Username);

            bool verified = BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password);

            return verified ? GenerateJwtToken(user) : string.Empty;
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
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user?.Id ?? string.Empty),
                new Claim(ClaimTypes.Name, user?.Name ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenKey.Value.TokenKey ?? string.Empty));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
