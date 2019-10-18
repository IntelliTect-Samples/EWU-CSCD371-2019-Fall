namespace Inheritance
{
    public class Sheldon : Actor
    {
        public string Words { get; }

        public Sheldon()
        {
            this.Words = "I know the real reason you never made progress with that idea." +
                " You thought of it September 22nd, 2007. Two days later, Penny moved in " +
                "and so much blood rushed to your genitals, your brain became a ghost town.";
        }
    }
}