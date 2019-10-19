using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string Speach() => "My name is Raj";
        public string Mumble() => "*mumble*";
    }
}
