using System;

namespace Mailbox
{
    public class Mailbox 
    {
        Person owner;
        Size size;
        ValueTuple<int,int> location;

        public Mailbox() 
        {
        }

        public override string ToString()
        {
            return size == 0 ? string.Empty : $"{owner.ToString()}'s {size} box is located at row {location.Item1} and column {location.Item2}.";
        }

    }
}
