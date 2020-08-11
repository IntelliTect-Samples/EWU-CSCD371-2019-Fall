using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor) =>
            actor switch
            {
                Raj r when r.WomenArePresent => r.Mumble(),
                Raj r => r.Talk(),
                Penny p => p.Talk(),
                Sheldon s => s.Talk(),
                null => throw new ArgumentNullException(nameof(actor)),
                _ => throw new ArgumentException(nameof(actor))
            };

    }
}
