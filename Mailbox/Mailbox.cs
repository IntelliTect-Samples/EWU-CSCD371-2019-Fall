/*
 #### Mailbox
- The ToString method should include all property members.
- When including the Size in the ToString, it should output empty string when the Size is the default (0) value,
the name of the size with " Premium" it is a premium size,
or simple the size name. For examples "Small" or "Medium Premium".
*/
using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size _MailboxSize;
        public ValueTuple<int, int> _Location;
        public Person _Owner;

        public Mailbox(Size size, ValueTuple<int, int> location, Person owner)
        {
            if (size is null) throw new ArgumentNullException();
            if (location is null) throw new ArgumentNullException();
            if (owner is null) throw new ArgumentNullException();
        }

        public override string ToString()
        {
            
        }
    }
}
