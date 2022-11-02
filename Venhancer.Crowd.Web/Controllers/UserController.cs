using Microsoft.AspNetCore.Http;
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
    public class UserController : CustomBaseController
    {
        private readonly APIOptions _apiOptions;
        public UserController(IOptions<APIOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult _SignOut()
        {
            return Redirect("~/Login");
        }

        [HttpPost]
        public async Task<Response<NoDataDto>> UserSignIn([FromBody] LoginDto loginDto)
        {
            var createTokenResponse = "";
            try
            {
                /////////////////Get Token With User Credentinal////////////////////////////////
                createTokenResponse = await CallAPIService.CallTokenAPI(_apiOptions.CrowAPIBaseUrl, _apiOptions.CrowAPICreateTokenUrl, loginDto);
                var createTokenDto = JsonConvert.DeserializeObject<CreateTokenDto.Root>(createTokenResponse);
                if (string.IsNullOrEmpty(createTokenResponse)) return Response<NoDataDto>.Fail(new ErrorDto("UserName or Password Wrong!", true), 404);
                if (!createTokenDto.IsSuccessful) return Response<NoDataDto>.Fail(new ErrorDto("UserName or Password Wrong!", true), 404);

                /////////////////Authoriza With Token//////////////////////////////////////////
                var userAuthorizationResponse = await CallAPIService.CallAuthorizationAPI(_apiOptions.CrowAPIBaseUrl, _apiOptions.CrowAPISingInUrl, loginDto, createTokenDto.Data.AccessToken);
                var userAppDto = JsonConvert.DeserializeObject<Response<UserAppDto>>(userAuthorizationResponse);

                if (!userAppDto.IsSuccessful) return Response<NoDataDto>.Fail(new ErrorDto("Authorization Error Please Contact With Admin!", true), 404);
                else
                {
                    HttpContext.Session.SetString("UserName", userAppDto.Data.UserName);
                    HttpContext.Session.SetString("AccessToken", createTokenDto.Data.AccessToken);
                }

                return Response<NoDataDto>.Success(200);

            }
            catch (Exception ex)
            {
                return Response<NoDataDto>.Fail(new ErrorDto("Authorization Error Please Contact With Admin!", true), 404);
            }
        }
        [HttpGet]
        public async Task<Response<List<UserAppDto>>> GetAllUser()
        {
            try
            {
                /////////////////Get Token With User Credentinal////////////////////////////////
                var getAllUserResponse = await CallAPIService.CallAPI(_apiOptions.CrowAPIBaseUrl, _apiOptions.CrowAPIGetAllUserDataUrl, null, HttpContext.Session.GetString("AccessToken"), Method.Get);
                var allUserDto = JsonConvert.DeserializeObject<Response<List<UserAppDto>>>(getAllUserResponse);

                if (!allUserDto.IsSuccessful) return Response<List<UserAppDto>>.Fail(new ErrorDto("User Not Found!", true), 404);
                else return Response<List<UserAppDto>>.Success(ObjectMapper.Mapper.Map<List<UserAppDto>>(allUserDto.Data), 200);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
