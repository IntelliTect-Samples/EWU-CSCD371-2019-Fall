using System;

namespace Inheritance
{
    public static class ActorMixins
    {
        public static string Speak(this Actor actor) =>
            actor switch
            {
                Penny p                         => "I'm Penny",
                Raj { WomenArePresent: true  }  => "",
                Raj { WomenArePresent: false }  => "*mumble*",
                Sheldon s                       => "I'm Sheldon",
                { }         => throw new ArgumentException("Not a known actor.", nameof(actor)),
                null        => throw new ArgumentNullException(nameof(actor))
            };
    }
}
