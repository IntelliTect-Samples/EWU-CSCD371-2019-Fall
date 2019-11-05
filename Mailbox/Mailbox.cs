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
        public Size MailboxSize;
        public (int X, int Y) Location;
        public Person Owner;

        public Mailbox(Size size, ValueTuple<int, int> location, Person owner)
        {
            MailboxSize = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            string s = $"Size: ";
            s += MailboxSize switch
            {
                Size.Small => "",
                Size.Medium => "Medium ",
                Size.Large => "Large ",
                Size.SmallPremium => "Premium ",
                Size.MediumPremium => "Medium Premium ",
                Size.LargePremium => "Large Premium ",
                _ => ""
            };

            var (X, Y) = Location;
            s += $"Location: X: {X} Y: {Y} ";
            s += $"Owner: {Owner.ToString()}";
            return s;
        }

        public override bool Equals(object obj)
        {
            if (obj is Mailbox) return this.Equals((Mailbox)obj);
            return false;
        }

        public bool Equals(Mailbox other)
        {
            if (this.MailboxSize == other.MailboxSize &&
                this.Location == other.Location &&
                this.Owner == other.Owner)
                return true;
            return false;
        }

        public override int GetHashCode() => (MailboxSize, Location, Owner).GetHashCode();
    }
}
