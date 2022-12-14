using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Identity.Shared.Dtos;

namespace Venhancer.Crowd.Identity.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T:class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
