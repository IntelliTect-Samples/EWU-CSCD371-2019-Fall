using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Sheldon : Actor
    {
        public string lastSaid { get; private set; }
        public void Speak()
        {
            lastSaid = "Sheldon is speaking.";
            Console.WriteLine(lastSaid);
        }
    }
}
