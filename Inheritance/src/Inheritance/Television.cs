using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Television : Item
    {
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public override string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
