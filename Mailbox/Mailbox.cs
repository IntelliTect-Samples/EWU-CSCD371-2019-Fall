using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Person Owner { get; }
        public (int X, int Y) Location { get; }
        public Sizes MailboxSize { get; }

        public Mailbox(Person owner, (int, int) location, Sizes mailboxSize)
        {
            Owner = owner;
            Location = location;
            MailboxSize = mailboxSize;
        }

        public override string ToString()
        {
            return $"Name: {Owner}; Location: {Location}; Mailbox Size: {MailboxSize.GetString()}";
        }
    }
}
