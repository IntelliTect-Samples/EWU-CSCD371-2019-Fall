using System;

namespace Inheritance {
    public class Raj : Actor {
        public bool womenArePresent { get; set; }

        public String Speak() {
            return ActorExtention.Speak((Actor) this);
        }
    }
}