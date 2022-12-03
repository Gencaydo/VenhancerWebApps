using Venhancer.Crowd.Identity.Shared.Dtos;
using Venhancer.Crowd.Resume.Service.API.Dtos;

namespace Venhancer.Crowd.Resume.Service.API.Services
{
    public interface IResumeService
    {
        Task<Response<List<ResumeDto>>> GetAllAsync();
        Task<Response<NoDataDto>> CreateAsync(ResumeDto resumeDto);
        Task<Response<ResumeDto>> GetByFirstNameAsync(string firstName);
    }
}
