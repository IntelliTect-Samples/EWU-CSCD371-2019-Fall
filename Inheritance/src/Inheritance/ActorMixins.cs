using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorMixins
    {
        public static String Speak(this Actor actor) =>
        actor switch
        {
        Penny p => "Hey I'm Penny",
        Sheldon s => "Bapzingus",
        Raj { WomenArePresent: false} r => "Hello friends",
        Raj { WomenArePresent: true} r => "mumble",
        { } => throw new ArgumentException(),
        _ => throw new ArgumentNullException()
        };
    }
}
