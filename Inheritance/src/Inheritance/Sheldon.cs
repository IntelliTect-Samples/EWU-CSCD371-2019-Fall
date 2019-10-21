using System;
using System.IO;

namespace Inheritance
{
    public class Sheldon : Actor
    {
        public void Speak(TextWriter writer)
        {
            writer.WriteLine("Hello, my name is Sheldon");
        }
    }
}