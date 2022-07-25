using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Sword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public double Weight { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
