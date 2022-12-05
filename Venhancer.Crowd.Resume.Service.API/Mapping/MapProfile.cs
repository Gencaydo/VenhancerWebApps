using AutoMapper;
using Venhancer.Crowd.Resume.Service.API.Models;
using Venhancer.Crowd.Resume.Service.API.Dtos;

namespace Venhancer.Crowd.Resume.Service.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ResumeEntity, ResumeDto>().ReverseMap();
            CreateMap<CVTypeEntity, CVTypeDto>().ReverseMap();
            CreateMap<PersonelInformationEntity, PersonelInformationDto>().ReverseMap();
            //CreateMap<NotificationTypeEntity, NotificationTypeDto>().ReverseMap();
        }
    }
}
