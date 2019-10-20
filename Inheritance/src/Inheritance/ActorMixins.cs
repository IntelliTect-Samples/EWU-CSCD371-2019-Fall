using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorMixins
    {
        public static string Speak(this Actor actor) => actor switch
        {
            Penny penny => penny.Speak(),
            Sheldon sheldon => sheldon.Speak(),
            Howard howard => howard.Speak(),
            Raj raj => raj.WomenPresent ? raj.Mumble() : raj.Speak(), 
            { } => string.Empty,
            null => throw new ArgumentNullException("Actor not specified", nameof(actor))
        };

    }
}
