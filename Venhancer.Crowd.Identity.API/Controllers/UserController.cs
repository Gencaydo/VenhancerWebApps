using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Services;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.API.Controllers
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
        public async Task<IActionResult> RemoveUser(UserAppDto userAppDto)
        {
            return ActionResultInstance(await _userService.RemoveUserAsync(userAppDto));
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            return ActionResultInstance(await _userService.LoginUserAsync(loginDto));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetUser(UserAppDto userAppDto)
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(userAppDto.UserName));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return ActionResultInstance(await _userService.GetAllUserAsync());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(LoginDto loginDto)
        {
            return ActionResultInstance(await _userService.ChangeUserPasswordAsync(loginDto));
        }
    }
}
