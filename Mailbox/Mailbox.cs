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

        public Mailbox(Person owner, (int X, int Y) location, Sizes mailboxSize)
        {
            MailboxSize = mailboxSize.IsValid() ? mailboxSize : throw new ArgumentOutOfRangeException(nameof(mailboxSize));
            Location = location.X >= 0 && location.Y >= 0 ? location : throw new ArgumentOutOfRangeException(nameof(location));
            Owner = owner;
        }

        public override string ToString()
            => $"Name: {Owner}; Location: {Location}; Mailbox Size: {MailboxSize.GetString()}";
    }
}
