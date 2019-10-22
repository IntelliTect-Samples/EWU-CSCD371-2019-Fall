namespace Inheritance
{
    public class Penny : Actor
    {
        public string Speak(string message) => message ?? "Isn't this when he says \"bazooka\" or something?";
    }
}