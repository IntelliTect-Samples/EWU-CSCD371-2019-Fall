using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtension
    {
        public static string Speak(this Actor actor, string phrase)
        {
            switch(actor)
            {
                case null:
                    throw new ArgumentNullException(nameof(actor));
                case Raj raj when raj.WomenArePresent:
                    return raj.Mumble();
                case Raj raj when !raj.WomenArePresent:
                    return raj.Say(phrase);
                case Penny penny:
                    return penny.Say(phrase);
                case Sheldon sheldon:
                    return sheldon.Say(phrase);
                default:
                    throw new NotSupportedException(nameof(actor) + " : type " + actor.GetType());
            }
        }
    }
}
