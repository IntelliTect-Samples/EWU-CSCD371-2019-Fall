using System;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string SpeakWithWomenPresent()
        {
            return "This is something Raj would say with women present";
        }

        public string SpeakWithoutWomenPresent()
        {
            return "This is something Raj would say WITHOUT women present";
        }
    }
}
