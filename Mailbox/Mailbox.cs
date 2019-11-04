using System;

namespace Mailbox
{
    public class Mailbox 
    {
        public ValueTuple<int, int> Location { get; }
        public Person Owner { get; }
        public Size Size { get; }



        public Mailbox(ValueTuple<int,int> location, Person owner, Size size) 
        {
            Location = location;
            Owner = owner;
            Size = size;
        }

        public override string ToString()
        {
            return Size == 0 ? string.Empty : $"{Owner.ToString()}'s {Size} box is located at row {Location.Item1} and column {Location.Item2}.";
        }

    }
}
