using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Models;
using Venhancer.Crowd.Identity.Core.Services;
using Venhancer.Crowd.Identity.Data;
using Venhancer.Crowd.Identity.Service.Mapping;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly AppDBContext _appDBContext;
        public UserService(UserManager<UserApp> userManager,AppDBContext appDBContext)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var username = createUserDto.Username?.Replace(" ","");
            var usermail = createUserDto.Email?.Replace(" ", "");
            var userpassword = createUserDto.Password?.Replace(" ", "");
            var user = new UserApp { Email = usermail,UserName = username,IsActive = true};
            var result = await _userManager.CreateAsync(user,userpassword);
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
            if (user == null) return Response<UserAppDto>.Fail(new ErrorDto("User not Found or Login Service not Working. Please Contact with Administrator", true), 400);
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

        public async Task<Response<List<UserAppDto>>> GetAllUserAsync()
        {
            var user = await _userManager.Users.Where(x=> x.IsActive == true).ToListAsync();
            if (user == null) return Response<List<UserAppDto>>.Fail("User not found", 404, true);
            return Response<List<UserAppDto>>.Success(ObjectMapper.Mapper.Map<List<UserAppDto>>(user), 200);
        }

        public async Task<Response<NoDataDto>> RemoveUserAsync(UserAppDto userAppDto)
        {
            var result = await _appDBContext.Database.ExecuteSqlInterpolatedAsync($"exec SP_REMOVE_USERS {userAppDto.Id}");
            if (result == 0) return Response<NoDataDto>.Fail("User not found", 404, true);
            return Response<NoDataDto>.Success(200);
        }
    }
}
