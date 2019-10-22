namespace Inheritance
{

    public class Raj : Actor
    {

        public bool WomenArePresent { get; set; }

        public string Speak(string message) => message ?? "Aquaman sucks!";

        public string Mumble() => "*audible confusion*";

    }

}
