namespace Mailbox
{
    public class Mailbox
    {
        public Sizes BoxSize { get; set; }

        public (int, int) Location { get; set; }

        public Person Owner { get; set; }

        //create a constructor because all properties are required.
        public Mailbox (Sizes size, (int, int) location, Person owner)
        {
            BoxSize = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"{Owner} - {Location} - {SizeString()}";
        }

        public string SizeString()
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
            return $"{size}" + (isPremium ? " - Premium" : "");
        }
    }

}
