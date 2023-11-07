using Microsoft.AspNetCore.Mvc;
using Newsio.BLL.Dtos;
using Newsio.BLL.Interfaces.Services;

namespace Newsio.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto model)
        {
            var user = await _userService.GetByLoginAndPasswordAsync(model);

            return Ok(user);
        }

        [HttpGet("username/{userName}")]
        public async Task<ActionResult<bool>> UserNameExists(string userName)
        {
            var exists = await _userService.UserNameExists(userName);

            return Ok(exists);
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserDto model)
        {
            var created = await _userService.AddAsync(model);

            return CreatedAtAction(nameof(Add), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UserDto model)
        {
            await _userService.UpdateAsync(id, model);

            return NoContent();
        }

        [HttpPut("password/{id}")]
        public async Task<bool> UpdatePassword(int id, UserChangePasswordDto model)
        {
            return await _userService.UpdatePasswordAsync(id, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}