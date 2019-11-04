using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size MailboxSize { get; set; }
        public Tuple<int, int> Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, int locX, int locY, Person owner)
        {
            MailboxSize = size; Location = new Tuple<int, int>(locX, locY); Owner = owner;
        }

        public override string ToString()
        {
            string s = Enum.GetName(typeof(Size), MailboxSize);
            
            return "size: " + s + " location: " + Location + " owner: " + Owner;
        }
    }
}
