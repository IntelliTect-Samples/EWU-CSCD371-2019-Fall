using System;

namespace Mailbox
{

    public class Mailbox
    {
        public Size MailboxSize { get; set; }
        public ValueTuple<int, int> Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size boxSize, ValueTuple<int, int> location, Person newOwner)
        {
            if(MailboxSize is 0 || location.Item1 == -1 || location.Item2 == -1)
            {
                throw new ArgumentNullException("Improper mailbox information.");
            }
            MailboxSize = boxSize;
        }

        public override string ToString()
        {
            return $"Owner: {Owner}, Location: {Location.Item1}, {Location.Item2}, Size: {MailboxSize.ToString()}"; 
        }

    }

}
