using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class Situation
    {
        public static bool WomenArePresent = false;
        
        public static string Speak(this Actor a)
        {
            string type = a.GetType().Name;
            if (type == "Penny")
            {
                WomenArePresent = true;
                return "Hello, I am Penny.";
            }
            else if (type == "Sheldon")
            {
                return "Hello, I am Sheldon.";
            }
            else if (type == "Raj")
            {
                return WomenArePresent ? "mumble..." : "Hello, I am Raj."; 
            }
            else
            {
                return "bad input";
            }
        }
    }
}
