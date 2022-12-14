using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Venhancer.Crowd.Identity.Core.Confugiration;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Models;
using Venhancer.Crowd.Identity.Core.Repository;
using Venhancer.Crowd.Identity.Core.Services;
using Venhancer.Crowd.Identity.Core.UniteOfWork;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;
        public AuthenticationService(IOptions<List<Client>> optionsClient,ITokenService tokenService,UserManager<UserApp> userManager,IUnitOfWork unitOfWork,IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;

        }
        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Response<TokenDto>.Fail(new ErrorDto("Email or Password is wrong", true), 400);
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return Response<TokenDto>.Fail(new ErrorDto("Email or Password is wrong", true),400);
            var token = _tokenService.CreateToken(user);
            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null) await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, RefreshToken = token.RefreshToken,Expiration = token.RefreshTokenExpiration});
            else { userRefreshToken.RefreshToken = token.RefreshToken;userRefreshToken.Expiration = token.RefreshTokenExpiration;}
            await _unitOfWork.CommitAsync();
            return Response<TokenDto>.Success(token, 200);
        }

        public async Task<Response<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x=> x.Equals(clientLoginDto.ClientId)&& x.Secret.Equals(clientLoginDto.ClientSecret));
            if (client == null) return Response<ClientTokenDto>.Fail("ClientId or ClientSecret not found", 404, true);
            var token = await _tokenService.CreateTokenByClient(client);
            return Response<ClientTokenDto>.Success(token, 200);
        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x=> x.RefreshToken.Equals(refreshToken)).SingleOrDefaultAsync();
            if (existRefreshToken == null) return Response<TokenDto>.Fail("Resfersh token not found", 404, true);
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null) return Response<TokenDto>.Fail("User token not found", 404, true);
            var tokenDto =  _tokenService.CreateToken(user);
            existRefreshToken.RefreshToken = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            await _unitOfWork.CommitAsync();
            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<VerificationCodeDto>> GetSmsVerificationCodeAsync(Response<UserAppDto> userAppDto)
        {
            var user = await _userManager.FindByIdAsync(userAppDto.Data.Id);
            if (user == null) return Response<VerificationCodeDto>.Fail("ClientId not found", 404, true);
            //var verificationcode = await _authenticationService.GetVerificationCodeAsync(userAppDto);
            return Response<VerificationCodeDto>.Success(new VerificationCodeDto { VerificationCode = "123456" }, 200);
        }
        public async Task<Response<VerificationCodeDto>> GetMailVerificationCodeAsync(Response<UserAppDto> userAppDto)
        {
            var user = await _userManager.FindByIdAsync(userAppDto.Data.Id);
            if (user == null) return Response<VerificationCodeDto>.Fail("ClientId not found", 404, true);
            //var verificationcode = await _authenticationService.GetVerificationCodeAsync(userAppDto);
            return Response<VerificationCodeDto>.Success(new VerificationCodeDto { VerificationCode = "123456" }, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.RefreshToken.Equals(refreshToken)).SingleOrDefaultAsync();
            if (existRefreshToken == null) return Response<NoDataDto>.Fail("Refresh token not found", 404, true);
            _userRefreshTokenService.Remove(existRefreshToken);
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }
    }
}
