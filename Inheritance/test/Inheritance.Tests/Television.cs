﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Television : Item
    {
        public string Size { get; set; }
        public string Manufacturer { get; set; }

        public override string PrintInfo()
        {
            return ($"{ Manufacturer } - { Size }");
        }
    }
}
