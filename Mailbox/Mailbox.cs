namespace Mailbox
{
    public class Mailbox
    {
        public Sizes Size { get; }
        public (int X, int Y) Location { get; }
        public Person Owner { get; }

        public Mailbox(Sizes size, (int X, int Y) location, Person owner)
        {
            //None of the parameters could be null
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return base.ToString();//TODO
        }
    }
}
