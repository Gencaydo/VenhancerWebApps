using AutoMapper;
using Venhancer.Crowd.Core.Dtos;
using Venhancer.Crowd.Core.Models;

namespace Venhancer.Crowd.Web.Mapping
{
    internal class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
