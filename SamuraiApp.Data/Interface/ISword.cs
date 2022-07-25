using SamuraiApp.Data.DTO;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface ISword : ICrud<Sword>
    {
        //input swordelement
        Task<Element> InsertElement(Element element);
        Task<SwordElement> InsertSwordElement(SwordElement swordelement);
        Task<Sword> InsertSwordElementDetail(Sword sword, List<Element> elementList);
    }
}
