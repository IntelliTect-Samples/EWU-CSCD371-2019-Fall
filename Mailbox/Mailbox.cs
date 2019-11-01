namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, (int x, int y) location, Person owner)
        {
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"Size: {Size} Location: {Location} Owner: {Owner.ToString()}";
        }
    }
}
