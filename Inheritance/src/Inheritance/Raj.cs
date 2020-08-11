using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string Talk()
        {
            return "No women are present, so Raj is able to speak.";
        }

        public string Mumble()
        {
            return "Women are present so Raj is just mumbling";
        }
    }
}
