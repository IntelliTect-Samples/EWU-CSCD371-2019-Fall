using System;

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
                case null:
                    throw new ArgumentNullException("There cannot be a null actor");
                default:
                    throw new NotSupportedException("There are no other characters implemented");
            }
        }

    }
}
