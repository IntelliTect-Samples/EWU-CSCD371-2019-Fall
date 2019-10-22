using System;

namespace Inheritance {
    public static class ActorExtention {
        public static String Speak(this Actor actor) {
            string result = "";
            switch (actor) {
                case Sheldon sheldon:
                    result = "I really wish the programmer knew more about Big Bang Therory, so he could better make fun of me!";

                    break;
                case Penny penny:
                    result = "If the programmer isn't mistaken, I'm just the token hot chick.";

                    break;
                case Raj raj:
                    raj = (Raj) actor;
                    if (raj.womenArePresent) {
                        result = "*Incoherent mumbles*";
                    } else {
                        result = "I'm so nerdy and awkward, it's hilarious!";
                    }
                    break;
            }
            result += " *canned laughter*";
            return result;
        }
    }
}