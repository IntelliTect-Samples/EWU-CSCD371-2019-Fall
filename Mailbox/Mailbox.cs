namespace Mailbox
{
    /*
     * Create a new Mailbox class
     * A Mailbox contains a Size, a value tuple (int X, int Y) for its Location, and a Person Owner
     * The ToString method should include all property members.
     * When including the Size in the ToString, it should output empty string when the Size 
     * is the default (0) value, the name of the size with " Premium" it is a premium size,
     * or simple the size name. For examples "Small" or "Medium Premium".
     */

    public class Mailbox
    {
        private Size? MailboxSize;
        (int X, int Y)? Location;
        private Person? Owner;

        public override string ToString()
        {
        }
    }
}
