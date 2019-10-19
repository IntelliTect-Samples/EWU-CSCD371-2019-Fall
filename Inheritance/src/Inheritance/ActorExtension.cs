using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtension
    {
        public static string Speak(this Actor actor) =>
            actor switch
            {
                Penny p => p.Speach(),
                Sheldon s => s.Speach(),
                Raj { WomenArePresent: true } r => r.Mumble(),
                Raj { WomenArePresent: false } r => r.Speach(),
                { } => "Who am I?",
                _ => throw new ArgumentNullException(nameof(actor))
            };
    }
}
