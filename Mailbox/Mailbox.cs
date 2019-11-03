using System;

namespace Mailbox
{

    public class Mailbox
    {
        public Size Size { get; set; }
        public (int Row, int Column) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size boxSize, ValueTuple<int, int> loc, Person newOwner)
        {
            if (loc.Item1 < 1 || loc.Item1 > 30)
            {
                throw new ArgumentOutOfRangeException("Mailbox row is out of bounds.");
            }
            if (loc.Item2 < 1 || loc.Item2 > 10)
            {
                throw new ArgumentOutOfRangeException("Mailbox column is out of bounds.");
            }
            Size = boxSize;
            Location = loc;
            Owner = newOwner;
        }

        public override string ToString()
        {
            string output = $"Owner: {Owner.ToString()}, Location: {Location.Item1}, {Location.Item2}";

            if(Size.ToString() != "Unset")
            {

                output += $", Size: {Size.ToString()}";
            }

            return output;
        }

    }

}
