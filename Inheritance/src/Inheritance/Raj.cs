using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenPresent { get; set; }

        public string Speak()
        {
            return "I've said this before and I'll say it again: Aquaman sucks!";
        }

        public string Mumble()
        {
            return "---silence....mumble....silence---";
        }

    }
}
