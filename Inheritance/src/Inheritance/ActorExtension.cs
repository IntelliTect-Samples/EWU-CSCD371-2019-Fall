using System;
using System.IO;

namespace Inheritance
{
    public static class ActorExtension
    {
        public static void Speak(this Actor actor, TextWriter writer)
        {
            if (actor is null || writer is null)
                throw new ArgumentNullException();

            switch (actor)
            {
                case Penny penny:
                    penny.Speak(writer);
                    break;

                case Raj raj when !raj.WomenPresent:
                    raj.Speak(writer);
                    break;

                case Raj raj when raj.WomenPresent:
                    raj.SpeakToWomen(writer);
                    break;

                case Sheldon sheldon:
                    sheldon.Speak(writer);
                    break;
            }
        }
    }
}