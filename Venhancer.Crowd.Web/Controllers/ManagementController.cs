using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Venhancer.Crowd.Configuration;
using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Shared.Dtos;
using Venhancer.Crowd.Shared.Services;
using Venhancer.Crowd.Web.Mapping;

namespace Venhancer.Crowd.Web.Controllers
{
    public class ManagementController : Controller
    {
        private readonly APIOptions _apiOptions;
        public ManagementController(IOptions<APIOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
        }
        public IActionResult UserList()
        {
            return View();
        }

        public IActionResult CreateUserCv()
        {
            return View();
        }

        [HttpPost]
        public async Task<Response<CreateUserDto>> UserCreate([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var createUserResponse = await CallAPIService.CallAPI(_apiOptions.CrowAPIBaseUrl, _apiOptions.CrowAPICreateUserUrl, createUserDto, HttpContext.Session.GetString("AccessToken"),Method.Post);
                var createUserData = JsonConvert.DeserializeObject<Response<CreateUserDto>>(createUserResponse);

                if (!createUserData.IsSuccessful) return Response<CreateUserDto>.Fail(new ErrorDto(createUserData.Error.Errors, true), 404);

                return Response<CreateUserDto>.Success(ObjectMapper.Mapper.Map<CreateUserDto>(createUserData.Data), 200);
            }
            catch (Exception ex)
            {
                return Response<CreateUserDto>.Fail(new ErrorDto(ex.Message, true), 404);
            }
        }

        [HttpPost]
        public async Task<Response<CreateUserDto>> CreateUserCV([FromBody] CreateUserCVDto createUserCVDto)
        {
            try
            {
                var createUserResponse = await CallAPIService.CallAPI(_apiOptions.CrowAPIBaseUrl, _apiOptions.CrowAPICreateUserUrl, createUserCVDto, HttpContext.Session.GetString("AccessToken"), Method.Post);
                var createUserData = JsonConvert.DeserializeObject<Response<CreateUserDto>>(createUserResponse);

                if (!createUserData.IsSuccessful) return Response<CreateUserDto>.Fail(new ErrorDto(createUserData.Error.Errors, true), 404);

                return Response<CreateUserDto>.Success(ObjectMapper.Mapper.Map<CreateUserDto>(createUserData.Data), 200);
            }
            catch (Exception ex)
            {
                return Response<CreateUserDto>.Fail(new ErrorDto(ex.Message, true), 404);
            }
        }
    }
}
