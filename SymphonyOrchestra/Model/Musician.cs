using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphonyOrchestra.Model
{
    public class Musician
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Instrument Instrument { get; set; }
        public int Experience { get; set; }
        public string Section { get; set; }
        public Education Education { get; set; }
    }
}
