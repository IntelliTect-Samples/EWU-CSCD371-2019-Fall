namespace Inheritance
{
    public class Penny : Actor
    {
        public string Words { get; }

        public Penny()
        {
            this.Words = "Woah, that's kind of a big step for a guy " +
                "who only recently agreed to take his socks off.";
        }
    }
}