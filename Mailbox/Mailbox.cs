using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size _Size { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, ValueTuple<int,int> location, Person owner)
        {
            _Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            if (_Size == Size.Unspecified)
            {
                return "";
            }
            return $"Owner: {Owner.LastName} {Owner.FirstName}, Location: {Location.x},{Location.y}, Size: {_Size}";
        }
    }
}
