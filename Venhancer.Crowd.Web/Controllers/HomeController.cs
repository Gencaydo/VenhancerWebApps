using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using Venhancer.Crowd.Configuration;
using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Core.Models;
using Venhancer.Crowd.Shared.Dtos;
using Venhancer.Crowd.Shared.Services;
using Venhancer.Crowd.Web.Mapping;
using Venhancer.Crowd.Web.Models;

namespace Venhancer.Crowd.Web.Controllers
{
    public class HomeController : CustomBaseController
    {
        private readonly APIOptions _apiOptions;
        public HomeController(IOptions<APIOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<Response<UserAppDto>> GetUserData()
        {
            var userAppDto = new UserAppDto();
            userAppDto.UserName = HttpContext.Session.GetString("UserName");
            try
            {
                var userAuthorizationResponse = await CallAPIService.CallPostAPI(_apiOptions.CrowAPIBaseUrl, _apiOptions.CrowAPIGetUserDataUrl, userAppDto, HttpContext.Session.GetString("AccessToken"));
                var userAppData = JsonConvert.DeserializeObject<Response<UserAppDto>>(userAuthorizationResponse);

                if (!userAppData.IsSuccessful) return Response<UserAppDto>.Fail(new ErrorDto("Authorization Error Please Contact With Admin!", true), 404);

                return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(userAppData.Data), 200);
            }
            catch (Exception ex)
            {
                return Response<UserAppDto>.Fail(new ErrorDto(ex.Message, true), 404);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}