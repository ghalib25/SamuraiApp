using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.DTO
{
    public class SwordElementAddDTO
    {
        public SwordAddDTO swordAddDTO { get; set; }
        public List<ElementAddDTO> elementAddDTOs { get; set; } = new List<ElementAddDTO>();
    }
}
