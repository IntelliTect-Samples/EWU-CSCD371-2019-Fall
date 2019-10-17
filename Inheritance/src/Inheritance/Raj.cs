using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Raj : Actor
    {
        public string lastSaid { get; private set; }
        public void Speak()
        {
            lastSaid = "Raj is speaking.";
            Console.WriteLine(lastSaid);
        }

        public void Mumble()
        {
            lastSaid = "Raj is mumbling.";
            Console.WriteLine(lastSaid);
        }
    }
}
