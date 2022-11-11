using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Services;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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
        [HttpPost]
        public async Task<IActionResult> GetUser(UserAppDto userAppDto)
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(userAppDto.UserName));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return ActionResultInstance(await _userService.GetAllUserAsync());
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(LoginDto loginDto)
        {
            return ActionResultInstance(await _userService.ChangeUserPasswordAsync(loginDto));
        }
    }
}
