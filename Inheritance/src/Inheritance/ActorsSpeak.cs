using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorsSpeak
    {
        public static string Speak(this Actor actor)
        {
            switch (actor)
            {
                case Sheldon sheldon:
                    return sheldon.SheldonSays();
                case Penny penny:
                    return penny.PennySays();
                case Raj raj when raj.WomenArePresent:
                    return raj.RajMumbles();
                case Raj raj when !raj.WomenArePresent:
                    return raj.RajSays();
                default:
                    throw new NotSupportedException("There are no other characters implemented");
            }
        }

    }
}
