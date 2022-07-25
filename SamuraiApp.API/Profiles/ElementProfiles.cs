using AutoMapper;
using SamuraiApp.Data.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class ElementProfiles : Profile
    {
        public ElementProfiles()
        {
            CreateMap<Element, ElementDTO>();
            CreateMap<ElementAddDTO, Element>();
        }

    }
}
