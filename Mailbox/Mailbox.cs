#pragma warning disable CA1724
namespace Mailbox
{
    public class Mailbox
    {
        public Sizes Size { get; }
        public (int, int) Location { get; }
        public Person Owner { get; }

        public Mailbox(Sizes size, (int, int) location, Person owner)
        {
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            string outputSize = Size != 0 ? Size.ToString() : "";
            return $"Size: {outputSize} Location: {Location} Owner: {Owner}";
        }
    }
}
