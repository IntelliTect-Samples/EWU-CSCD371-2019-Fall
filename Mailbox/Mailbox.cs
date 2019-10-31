namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public Person Owner { get; set; }
        public (int X, int Y) Location { get; set; }

        public override string? ToString() => $"Owner: {Owner.ToString()} Location: {Location} Size: {(Size == Size.Default ? "" : Size.ToString())}";

    }
}
