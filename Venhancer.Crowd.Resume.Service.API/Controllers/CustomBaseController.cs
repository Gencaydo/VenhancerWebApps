using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Resume.Service.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
