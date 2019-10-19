namespace Inheritance
{
    public class Raj : Actor
    {
        public bool WomenArePresent { get; set; }

        public string Speak() =>
            "Oh man, first monster I see I'm gonna sneak up behind him," +
            "whip out my wand and shoot my magic all over his ass!";

        public string Mumble() => "*audible confusion*";
    }
}