using System;

namespace Mailbox
{
    public class Mailbox
    {
        public (int X, int Y) Location { get; }

        public Person Owner { get; }

        public Sizes Size { get; }

        public Mailbox((int X, int Y) location, Person owner, Sizes size)
        {
            if (!size.IsValid()) throw new ArgumentException("Invalid size.", nameof(size));
            Location = location;
            Owner = owner;
            Size = size;
        }

        public override string? ToString() =>
            $"{Owner.FirstName} {Owner.LastName}'s{(Size.Premium() ? " Premium" : "")} {Size.Size()} mailbox at {Location}";
    }
}
