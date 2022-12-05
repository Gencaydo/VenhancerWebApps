using Venhancer.Crowd.Identity.Shared.Dtos;
using Venhancer.Crowd.Resume.Service.API.Dtos;

namespace Venhancer.Crowd.Resume.Service.API.Services
{
    public interface IResumeService
    {
        Task<Response<NoDataDto>> CreateResumeAsync(ResumeDto resumeDto);
        Task<Response<ResumeDto>> GetResumeDataByEmailAsync(string email);
        Task<Response<NoDataDto>> UpdateResumeDataByEmailAsync(ResumeDto resumeDto,string email);
    }
}
