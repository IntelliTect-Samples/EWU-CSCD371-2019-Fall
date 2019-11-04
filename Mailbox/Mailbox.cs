using System;
using Newtonsoft.Json;

namespace Mailbox
{
    public class Mailbox
    {
        public Size MailboxSize { get; set; }
        public (int x, int y) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, int locX, int locY, Person owner)
        {
            MailboxSize = size; Location = (locX, locY); Owner = owner;
        }

        public override string ToString()
        {
            string s = Enum.GetName(typeof(Size), MailboxSize);
            
            return "size: " + s + " location: " + Location + " owner: " + Owner;
        }
    }
}
