using System;

namespace Mailbox
{
    /*
     * Create a new Mailbox class
     * A Mailbox contains a Size, a value tuple (int X, int Y) for its Location, and a Person Owner
     * The ToString method should include all property members.
     * When including the Size in the ToString, it should output empty string when the Size 
     * is the default (0) value, the name of the size with " Premium" it is a premium size,
     * or simple the size name. For examples "Small" or "Medium Premium".
     */

    public class Mailbox
    {
        private Size MailboxSize;
        public ValueTuple<int, int> Location;
        public Person Owner;

        public Mailbox(Size size, ValueTuple<int, int> location, Person owner)
        {
            NullCheck("Mailbox Constructor", size);
            NullCheck("Mailbox Constructor", location);
            NullCheck("Mailbox Constructor", owner);
            MailboxSize = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            NullCheck("ToString", MailboxSize);
            NullCheck("ToString", Location);
            NullCheck("ToString", Owner);

            string s = "Size: ";
            if ((MailboxSize & Size.SizeMask) == Size.Small)
                s += "";
            else if ((MailboxSize & Size.SizeMask) == Size.Medium)
                s += "Medium ";
            else if ((MailboxSize & Size.SizeMask) == Size.Large)
                s += "Large ";

            var (X, Y) = Location;
            s += $"Location: X: {X} Y: {Y} ";
            s += $"Owner: {Owner.ToString()}";
            return s;
        }

        private void NullCheck(string methodName, object obj)
        {
            if (obj is null)
                throw new InvalidOperationException($"Cannot call {methodName} method when {nameof(obj)} is null.");
        }
    }
}
