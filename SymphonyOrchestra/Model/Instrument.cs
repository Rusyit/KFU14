﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphonyOrchestra.Model
{
    public class Instrument
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Family { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Material Material { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Type} - {Family} - {Manufacturer} - {Material}";
        }
    }
}
