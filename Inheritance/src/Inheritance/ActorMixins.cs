using System;

namespace Inheritance
{

    public static class ActorMixins
    {

        public static string Speak(Actor actor, string message) => actor switch
        {
            Sheldon sheldon => sheldon.Speak(message),
            Penny penny     => penny.Speak(message),
            Raj raj         => raj.WomenArePresent ? raj.Mumble() : raj.Speak(message),
            { }             => throw new ArgumentException("Unknown actor", nameof(actor)),
            null            => throw new ArgumentNullException(nameof(actor)),
        };

    }

}
