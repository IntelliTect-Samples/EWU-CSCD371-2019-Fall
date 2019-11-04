namespace Mailbox
{

    public class Mailbox
    {

        public Person Owner { get; set; }
        public Size   Size   { get; set; }

        public (int x, int y) Location { get; set; }

    }

}
