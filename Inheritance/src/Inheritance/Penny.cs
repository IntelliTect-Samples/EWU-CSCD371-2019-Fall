using System;
using System.IO;

namespace Inheritance
{
    public class Penny : Actor
    {
        public void Speak(TextWriter writer)
        {
            writer.WriteLine("Hello, my name is Penny");
        }
    }
}
