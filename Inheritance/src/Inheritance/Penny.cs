using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Penny : Actor
    {
        public string lastSaid { get; private set; }
        public void Speak()
        {
            lastSaid = "Penny is speaking.";
            Console.WriteLine(lastSaid);
        }
    }
}
