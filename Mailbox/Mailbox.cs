namespace Mailbox
{
    public class Mailbox
    {
        public Person Owner { get; }
        public Sizes MailboxSize { get; }
        public (int, int) Location { get; }

        public override string ToString()
        {
            return "";
        }
    }
}
