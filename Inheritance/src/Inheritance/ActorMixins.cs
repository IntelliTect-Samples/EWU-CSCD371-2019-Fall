using System;

namespace Inheritance
{
    public static class ActorMixins
    {
        public static string Speak(Actor actor) =>
            actor switch
            {
                Sheldon sheldon => sheldon.Speak(),
                Penny penny => penny.Speak(),
                Raj raj => raj.WomenArePresent ? raj.Mumble() : raj.Speak(),
                { } => throw new ArgumentException("Unknown actor", nameof(actor)),
                null => throw new ArgumentNullException(nameof(actor))
            };
    }
}