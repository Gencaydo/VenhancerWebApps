using AutoMapper;
using Venhancer.Crowd.Identity.Core.Dtos;
using Venhancer.Crowd.Identity.Core.Models;

namespace Venhancer.Crowd.Identity.Service.Mapping
{
    internal class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
