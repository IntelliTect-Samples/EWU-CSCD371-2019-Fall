using System;

namespace Mailbox
{
    public class Mailbox
    {
        private Size Size { get; set; }
        private Tuple<int> Location { get; set; }
        private Person Owner { get; set; }

        public Mailbox(Size size, Tuple<int> location, Person owner)
        {
            if(owner.Equals(null) || size.Equals(null))
            {
                throw new ArgumentNullException("The owner and size cannot be null");
            }
        }

    }
}
