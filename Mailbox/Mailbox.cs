namespace Mailbox
{
    public class Mailbox
    {
        public Sizes Size { get; set; }
        public (int X, int Y) Location;
        public Person Owner { get; set; }

        public override string ToString()
        {
            string sizeStr = Size.ToString();

            if (sizeStr.Contains("Premium"))
                sizeStr.Replace("Premium", " Premium");

            else if (sizeStr.Equals("Default"))
                sizeStr = "";

            return $"Owner: {Owner.ToString()}, Mailbox Size: {sizeStr}, Location: {Location.X}, {Location.Y}";
        }
    }
}
