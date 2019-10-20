using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public string Mumble() => "mmhmhmhhmmhmhmmhmhm";
        public string Phrase() => "My name is Raj!";
    }
}
