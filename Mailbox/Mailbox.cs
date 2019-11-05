using System;

namespace Mailbox
{

    public class Mailbox
    {

        public Person Owner { get; }
        public Size   Size   { get; }

        public (int x, int y) Location { get; }

        public Mailbox(Person? owner, Size? size, (int x, int y) location)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Location = location;
        }

        public override string ToString()
        {
            return $"{Location} | {Owner} {((int) Size > 4 ? "| " + Size.ToString().Substring(0, Size.ToString().Length - 7) + " Premium" : Size != Size.Default ? "| " + Size : "")}";
        }

    }

}
