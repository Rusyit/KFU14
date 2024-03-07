using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphonyOrchestra.Model
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Country}";
        }
    }
}
