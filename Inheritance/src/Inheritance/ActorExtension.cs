using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtension
    {
        public static void Speak(this Actor actor, bool WomenArePresent)
        {
            switch (actor)
            {
                case Sheldon s:
                    s.Speak();
                    break;
                case Penny p:
                    p.Speak();
                    break;
                case Raj r when WomenArePresent:
                    r.Mumble();
                    break;
                case Raj r when WomenArePresent is false:
                    r.Speak();
                    break;
            }
        }
    }
}
