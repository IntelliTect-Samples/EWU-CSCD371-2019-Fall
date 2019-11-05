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
            s = MailboxSize.ToString();
            string[] split = s.Split(",");
            if (split.Length > 1) //It is flagged
            {
                s = split[1].Trim() + " " + split[0].Trim();
            }
            else if (s.Equals("Default")) s = "";

            return "size: " + s + " location: " + Location + " owner: " + Owner;
        }
    }
}
