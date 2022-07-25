using AutoMapper;
using SamuraiApp.Data.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class SwordProfiles : Profile
    {
        public SwordProfiles()
        {
            CreateMap<Sword, SwordDTO>();
            CreateMap<SwordAddDTO, Sword>();
            CreateMap<Sword, SwordElementDTO>().ForMember(se=>se.elementDTOs, m=>m.MapFrom(e=>e.Elements));
            CreateMap<SwordElementAddDTO, Sword>();
        }
    }
}
