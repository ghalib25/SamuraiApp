using AutoMapper;
using SamuraiApp.Domain;
using SamuraiApp.Data.DTO;

namespace SamuraiApp.API.Profiles
{
    public class SamuraiProfiles : Profile
    {
        public SamuraiProfiles()
        {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<SamuraiAddDTO, Samurai>();
        }
    }
}
