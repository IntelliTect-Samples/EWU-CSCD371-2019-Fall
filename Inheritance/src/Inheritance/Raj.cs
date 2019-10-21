using System;
using System.IO;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenPresent { get; set; }

        public Raj()
        {
            WomenPresent = false;
        }

        public Raj(bool womenPresent)
        {
            WomenPresent = womenPresent;
        }

        public void Speak(TextWriter writer)
        {
            writer.WriteLine("Hello, my name is Raj");
        }
        public void SpeakToWomen(TextWriter writer)
        {
            writer.WriteLine("mumble");
        }
    }
}