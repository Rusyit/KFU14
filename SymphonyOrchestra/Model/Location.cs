﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphonyOrchestra.Model
{
    public class Location
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name} - {City} - {Country}";
        }
    }
}
