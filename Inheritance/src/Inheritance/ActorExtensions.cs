using System;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor, bool womenArePresent) => actor switch
        {
            Penny penny                  => penny.Greet(),
            Sheldon sheldon              => sheldon.Fact(),
            Raj raj when womenArePresent => raj.Mumble(),
            Raj raj                      => raj.Exclaim(),
            null                         => throw new ArgumentNullException(nameof(actor)),
            _                            => throw new NotImplementedException()
        };
    }
}
