using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SymphonyOrchestra.Model
{
    public class Education
    {
        public string Institution { get; set; }
        public string Degree { get; set; }
        public int YearCompleted { get; set; }

        public override string ToString()
        {
            return $"{Institution} - {Degree} - {YearCompleted}";
        }
    }
}
