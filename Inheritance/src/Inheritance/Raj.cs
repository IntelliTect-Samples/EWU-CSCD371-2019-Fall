using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool womenArePresent { get; set; }

        public string Say(string content) { return content; }
        public string Mumble() { return "*mumbles*"; }
    }
}
