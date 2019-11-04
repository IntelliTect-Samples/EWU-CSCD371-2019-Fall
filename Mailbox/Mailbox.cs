using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, ValueTuple<int,int> location, Person owner)
        {
            Size = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            String size;
            if(Size == Size.Default)
            {
                size = "";
            }
            else if(Size == Size.Premium)
            {
                size = Size.ToString() + "Premium";
            }
            else
            {
                size = Size.ToString();
            }

            return $"Size: {size} Location: {Location.ToString()} Owner: {Owner.ToString()}";
        }
    }
}
