namespace Venhancer.Crowd.Resume.Service.API.Dtos
{
    public class ResumeDto : BaseDto
    {    
        public List<CVTypeDto>? CVTypes { get; set; }
        public List<PersonelInformationDto>? PersonelInformations { get; set; }
    }
}
