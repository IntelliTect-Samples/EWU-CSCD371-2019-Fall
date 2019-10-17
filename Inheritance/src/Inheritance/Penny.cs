namespace Inheritance {
    public class Penny : Actor {
        public string Speak() {
            return ActorExtention.Speak((Actor) this);
        }
    }
}
