
namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; }
        public (int X, int Y) Location { get; }
        public Person Owner { get; }

        public Mailbox(Size size, (int X, int Y) location, Person owner)
        {
            //None of the parameters could be null
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"Mailbox Location: X: {Location.X} Y: {Location.Y}, {Owner.ToString()}, Size: {Size.ToString()}";
        }
    }
}
