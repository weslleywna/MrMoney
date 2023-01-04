using Microsoft.AspNetCore.Mvc;
using MrMoney.Domain.Dtos;
using MrMoney.Domain.Interfaces.Repositories;
using MrMoney.Domain.Interfaces.Services;
using MrMoney.Domain.Models;
using MrMoney.Infrastructure.Repositories;

namespace MrMoney.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
            
        }

        [HttpGet("{username}")]
        public async Task<User> GetByUsernameAsync(string username) =>
            await _authService.GetByUsernameAsync(username);

        [HttpGet]
        public async Task<List<User>> Get() =>
            await _authService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _authService.GetByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            var newUser = await _authService.CreateUserAsync(userDto);

            if (newUser is null) return BadRequest("Falha ao criar usuário.");

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedBook)
        {
            var user = await _authService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedBook.Id = user.Id;

            await _authService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _authService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _authService.RemoveAsync(id);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            var login = await _authService.Login(userDto);
            return Ok();
        }
    }
}
