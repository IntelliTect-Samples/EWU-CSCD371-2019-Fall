using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Television:IItem
    {
        public string Manufacturer { get; set; }

        public string Size { get; set; }

        public  string PrintInfo() => $"<{Manufacturer}> - <{Size}>";
    }
}
