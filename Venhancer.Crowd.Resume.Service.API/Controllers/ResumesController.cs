using Microsoft.AspNetCore.Mvc;
using Venhancer.Crowd.Resume.Service.API.Dtos;
using Venhancer.Crowd.Resume.Service.API.Services;

namespace Venhancer.Crowd.Resume.Service.API.Controllers
{
    public class ResumesController : CustomBaseController
    {
        private readonly IResumeService _resumeService;

        public ResumesController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var categories = await _categoryService.GetAllAsync();
        //    return ActionResultInstance(categories);
        //}
        [HttpGet("firstname")]
        public async Task<IActionResult> GetByFirstNameAsync(string firstname)
        {
            var category = await _resumeService.GetByFirstNameAsync(firstname);
            return ActionResultInstance(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ResumeDto resumeDto)
        {
            var response = await _resumeService.CreateAsync(resumeDto);
            return ActionResultInstance(response);
        }
    }
}
