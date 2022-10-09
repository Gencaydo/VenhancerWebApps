using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Core.Services;

namespace Venhancer.Crowd.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            return ActionResultInstance(await _userService.LoginUserAsync(loginDto));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(LoginDto loginDto)
        {
            return ActionResultInstance(await _userService.ChangeUserPasswordAsync(loginDto));
        }
    }
}
