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
        [HttpGet("Email")]
        public async Task<IActionResult> GetResumeDataByEmailAsync(string email)
        {
            var category = await _resumeService.GetResumeDataByEmailAsync(email);
            return ActionResultInstance(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResumeAsync(ResumeDto resumeDto)
        {
            var response = await _resumeService.CreateResumeAsync(resumeDto);
            return ActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateResumeDataByEmailAsync(ResumeDto resumeDto, string email)
        {
            var response = await _resumeService.UpdateResumeDataByEmailAsync(resumeDto, email);
            return ActionResultInstance(response);
        }
    }
}
