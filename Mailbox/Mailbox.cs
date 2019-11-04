
using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Size MailboxSize { get; }
        public ValueTuple<int, int> Location { get; }
        public Person Owner { get; }

        public Mailbox(Size? size, ValueTuple<int, int>? location, Person? owner)
        {
            MailboxSize = size ?? throw new ArgumentNullException(nameof(size));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public override string? ToString()
        {
            return (MailboxSize) switch
            {
                Size.Undeclared => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: ",
                Size.Premium => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: {MailboxSize} Premium",
                _ => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: {MailboxSize}"
            };
        }
    }
}
