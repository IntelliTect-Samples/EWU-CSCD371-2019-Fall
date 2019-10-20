using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    static class ActorExtension
    {
        public static string Speak(Actor actor) => actor switch
        {
            Sheldon sheldon => sheldon.Phrase(),
            Penny penny => penny.Phrase(),
            Raj { WomenArePresent: true } raj => raj.Mumble(),
            Raj { WomenArePresent: false } raj => raj.Phrase(),
            { } => throw new ArgumentException(message: "Actor is not known", nameof(actor)),
            null => throw new ArgumentNullException(nameof(actor))
        };
    }
}
