using System;

namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }
        public string SpeakWithWomenPresent()
        {
            return "Raj: \"*mumbles*\"";
        }

        public string SpeakWithoutWomenPresent()
        {
            return "Raj: \"I've said it before and I'll say it again, Aquaman sucks!\"";
        }
    }
}
