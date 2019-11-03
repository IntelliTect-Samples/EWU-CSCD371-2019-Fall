using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public ValueTuple<int, int> Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, ValueTuple<int, int> location, Person owner)
        {
            if(owner.Equals(null) || size.Equals(null))
            {
                throw new ArgumentNullException("The owner and size cannot be null");
            }

            Size = size;
            Owner = owner;
            Location = location;
        }

        public override string ToString()
        {
            string mySize; 

            if(Size.Equals(0))
            {
                mySize = "";
            }
            else
            {
                mySize = Size.ToString();
            }
          

            return $"{Owner.FirstName} {Owner.LastName}'s {mySize} Mailbox is located at {Location.Item1} and {Location.Item2}";
        }
    }
}
