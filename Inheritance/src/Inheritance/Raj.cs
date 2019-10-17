using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string Say(string phrase) => phrase;
        public string Mumble() => "*mumbles something*";
    }
}
