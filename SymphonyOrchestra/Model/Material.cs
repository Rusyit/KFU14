using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SymphonyOrchestra.Model
{
    public class Material
    {
        public string Type { get; set; }
        public string Source { get; set; }

        public override string ToString()
        {
            return $"{Type} - {Source}";
        }
    }
}
