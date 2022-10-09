using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Shared.Dtos;

namespace Venhancer.Crowd.API.Controllers
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
