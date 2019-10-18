using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public static class ActorExtensions
    {
        public static string Speak(this Actor actor, string script)
        {
            //return $"{actor.GetType()}: {script}";
            return "ABC";
        }
    }
}
