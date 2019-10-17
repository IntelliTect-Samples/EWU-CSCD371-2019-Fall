using System;

namespace Inheritance {
    public static class ActorExtention {
        public static String Speak(Actor actor) {
            string result = "";
            if (actor is Raj) {
                Raj raj = (Raj) actor;
                if (raj.womenArePresent) {
                    result = "*Incoherent mumbles*";
                } else {
                    result = "I'm so nerdy and awkward, it's hilarious!";
                }
            } else if (actor is Sheldon) {
                result = "I really wish the programmer knew more about Big Bang Therory, so he could better make fun of me!";
            } else if (actor is Penny) {
                result = "If the programmer isn't mistaken, I'm just the token hot chick.";
            }
            result += " *canned laughter*";
            return result;
        }
    }
}