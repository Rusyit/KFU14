using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphonyOrchestra.Model
{
    public class Symphony
    {
        public string Title { get; set; }
        public string Composer { get; set; }
        public string Duration { get; set; }
        public int Year { get; set; }

        public Conductor Conductor { get; set; }
        public Location Location { get; set; }
    }
}
