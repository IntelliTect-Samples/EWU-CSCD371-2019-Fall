namespace Mailbox
{
    public class Mailbox
    {
        public Size Size { get; set; }
        public Person Owner { get; set; }
        public (int X, int Y) Location { get; set; }

        public override string? ToString()
        {
            string size;
            switch (Size)
            {
                case Size.Premium:
                    size = "Premium";
                    break;
                case Size.SmallPremium:
                    size = "Small Premium";
                    break;
                case Size.MediumPremium:
                    size = "Medium Premium";
                    break;
                case Size.LargePremium:
                    size = "Large Premium";
                    break;
                default:
                    size = Size.ToString();
                    break;
            }

            return $"Owner: {Owner.ToString()} Location: {Location} Size: {(Size == Size.Default ? "" : size)}";
        }
    }
}
