using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Services;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : CustomBaseController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await authenticationService.CreateTokenAsync(loginDto);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTokenByClient(ClientLoginDto clientloginDto)
        {
            var result = await authenticationService.CreateTokenByClient(clientloginDto);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await authenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await authenticationService.CreateTokenByRefreshToken(refreshTokenDto.RefreshToken);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetSmsVerificationCodeAsync(Response<UserAppDto> userAppDto)
        {
            var result = await authenticationService.GetSmsVerificationCodeAsync(userAppDto);
            return ActionResultInstance(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetMailVerificationCodeAsync(Response<UserAppDto> userAppDto)
        {
            var result = await authenticationService.GetMailVerificationCodeAsync(userAppDto);
            return ActionResultInstance(result);
        }
    }
}
