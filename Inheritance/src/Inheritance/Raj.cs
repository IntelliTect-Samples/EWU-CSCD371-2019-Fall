using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public string Script 
        {
            get 
            {
                return AreWomenPresent ? "mumble" : Script;
            }
            set { Script = value; }
        }
        public bool AreWomenPresent { get; set; }
    }
}
