using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
        Task<Response<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);
        Task<Response<VerificationCodeDto>> GetSmsVerificationCodeAsync(Response<UserAppDto> userAppDto);
        Task<Response<VerificationCodeDto>> GetMailVerificationCodeAsync(Response<UserAppDto> userAppDto);
    }
}
