using Microsoft.AspNetCore.Identity;
using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Core.Models;
using Venhancer.Crowd.Core.Services;
using Venhancer.Crowd.Service;
using Venhancer.Crowd.Shared.Dtos;

namespace Venhancer.Crowd.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp { Email = createUserDto.Email,UserName = createUserDto.UserName };
            var result = await _userManager.CreateAsync(user,createUserDto.Password);
            if (!result.Succeeded)
            {
                var Errors = result.Errors.Select(x =>x.Description).ToList();
                return Response<UserAppDto>.Fail(new ErrorDto(Errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user),200);
        }
        public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null)  return Response<UserAppDto>.Fail("User not found",404,true);
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
        public async Task<Response<UserAppDto>> LoginUserAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Response<UserAppDto>.Fail(new ErrorDto("Email or Password is wrong", true), 400);
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password)) return Response<UserAppDto>.Fail(new ErrorDto("Email or Password is wrong", true), 400);
            var userdata = await _userManager.FindByIdAsync(user.Id);
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(userdata), 200);
        }
        public async Task<Response<UserAppDto>> ChangeUserPasswordAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var userdata = await _userManager.AddPasswordAsync(user, loginDto.Password);
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(userdata), 200);
        }
    }
}
