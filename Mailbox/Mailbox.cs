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
            Size = boxSize;
            Location = loc;
            Owner = newOwner;
        }

        public override string ToString()
        {
            string output = $"Owner: {Owner.ToString()}, Location: {Location.Item1}, {Location.Item2}";

            if(Size != Size.Unset && Size != Size.Premium)
            {
                output += $", Size: {Size.ToString()}";
            }

            return output;
        }

    }

}
