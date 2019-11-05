
using System;

namespace Mailbox
{
    public class MailBox
    {
        public Sizes MailboxSize { get; }
        public (int, int) Location { get; }
        public Person Owner { get; }

        public MailBox(Sizes mailboxSize, (int, int) location, Person owner)
        {
            if (!mailboxSize.IsValid()) throw new ArgumentException("Invalid size.", nameof(mailboxSize));
            MailboxSize = (Sizes)mailboxSize;
            Location = location;
            Owner = owner;
        }

        public override string? ToString()
        {
            return (MailboxSize) switch
            {
                Sizes.Undeclared => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: ",
                Sizes.SmallPremium => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: Premium Small",
                Sizes.MediumPremium => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: Premium Medium",
                Sizes.LargePremium => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: Premium Large",
                _ => $"Mailbox Owner: {Owner.ToString()}, Location: x = {Location.Item1}, y = {Location.Item2}, Box size: {MailboxSize}",
            };
        }
    }
}
