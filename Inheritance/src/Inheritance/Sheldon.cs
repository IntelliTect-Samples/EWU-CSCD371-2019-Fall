namespace Inheritance {
    public class Sheldon : Actor {
        public string Speak() {
            return ActorExtention.Speak((Actor) this);
        }
    }
}