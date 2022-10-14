using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Shared.Dtos;

namespace Venhancer.Crowd.Web.Controllers
{
    public class CustomBaseController : Controller
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
