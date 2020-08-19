namespace Mailbox
{
    public class Mailbox
    {
        Size BoxSize { get; set; }

        (int, int) Location { get; set; }

        Person Owner { get; set; }

        public override string ToString()
        {
            return $"{Owner} - {Location} - {BoxSize}";
        }
    }

}
