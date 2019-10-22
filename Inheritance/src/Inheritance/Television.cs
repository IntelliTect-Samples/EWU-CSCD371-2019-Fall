using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string manufacturer { get; set; }
        public string size { get; set; }

        public override string PrintInfo()
        {
            return "<" + manufacturer + "> - <" + size + ">";
        }
    }
}
