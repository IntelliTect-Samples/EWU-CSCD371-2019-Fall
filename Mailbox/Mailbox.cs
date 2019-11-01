using System;

namespace Mailbox
{

    public class Mailbox
    {
        public Size _Size { get; set; }
        public (int Row, int Column) _Location { get; set; }
        public Person _Owner { get; set; }

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
            _Size = boxSize;
            _Location = loc;
            _Owner = newOwner;
        }

        public override string ToString()
        {
            /*string output = 
            return output;
                
                $"Owner: {_Owner}, Location: {_Location.Item1}, {_Location.Item2}, Size: {_Size.ToString()}"; */
            return null;
        }

    }

}
