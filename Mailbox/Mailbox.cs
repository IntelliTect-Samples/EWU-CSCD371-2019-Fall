using System;

// renamed mailbox namespace to avoid compiler warnings of overlapping namespace and class
// I would have preferred to rename this class but I couldn't think of anything that made sense
namespace MailRoom
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
            MailboxSize = mailboxSize.IsValid() ? mailboxSize : throw new ArgumentOutOfRangeException(nameof(mailboxSize));

        }

        public override string ToString()
        {
            return $"Name: {Owner}; Location: {Location}; Mailbox Size: {MailboxSize.GetString()}";
        }
    }
}
