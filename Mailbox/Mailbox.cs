namespace Mailbox
{
    public class Mailbox
    {
        Sizes BoxSize { get; set; }

        (int, int) Location { get; set; }

        Person Owner { get; set; }

        public override string ToString()
        {
            return $"{Owner} - {Location} - {SizeString()}";
        }

        private string SizeString()
        {
            bool isPremium = false;
            if ((BoxSize & Sizes.Default) != Sizes.Default)
            {
                return "";
            }
            if (BoxSize.HasFlag(Sizes.Premium))
            {
                isPremium = true;
            }
            Sizes size = BoxSize & ~Sizes.Premium;
            return $"{size}" + (isPremium ? "- Premium" : "");
        }
    }

}
