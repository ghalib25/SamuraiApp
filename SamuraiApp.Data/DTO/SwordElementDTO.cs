using SamuraiApp.Domain;

namespace SamuraiApp.Data.DTO
{
    public class SwordElementDTO
    {
        public String Name { get; set; }
        public List<ElementDTO> elementDTOs { get; set; } = new List<ElementDTO>();
    }
}
