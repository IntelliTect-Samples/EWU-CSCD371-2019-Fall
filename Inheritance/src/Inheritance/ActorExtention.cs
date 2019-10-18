using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtention
    {
        public static string Speak(this Actor actor, string content)
        {
            switch (actor) {

                case Raj raj:
                    if (raj.womenArePresent)
                        return raj.Mumble();
                    else return raj.Say(content);

                case Sheldon sheldon:
                    return sheldon.Say(content);

                case Penny penny:
                    return penny.Say(content);

                default:
                    throw new ArgumentNullException(nameof(actor));
            }
        }
    }
}
