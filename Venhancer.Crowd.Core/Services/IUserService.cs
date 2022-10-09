using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Shared.Dtos;

namespace Venhancer.Crowd.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
        Task<Response<UserAppDto>> LoginUserAsync(LoginDto loginDto);
        Task<Response<UserAppDto>> ChangeUserPasswordAsync(LoginDto loginDto);
    }
}
