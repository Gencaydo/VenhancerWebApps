using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Models;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<NoDataDto>> RemoveUserAsync(UserAppDto userAppDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
        Task<Response<List<UserAppDto>>> GetAllUserAsync();
        Task<Response<UserAppDto>> LoginUserAsync(LoginDto loginDto);
        Task<Response<UserAppDto>> ChangeUserPasswordAsync(LoginDto loginDto);
    }
}
