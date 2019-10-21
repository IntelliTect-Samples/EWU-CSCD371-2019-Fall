using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public Raj(bool isWomenPresent)
        {
            WomenArePresent = isWomenPresent;
        }

        public string RajSays()
        {
            return "Hello";
        }

        public string RajMumbles()
        {
            return "...mmaksjdjsks";
        }
    }
}
