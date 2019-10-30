using System;

namespace Mailbox
{

    public class Mailbox
    {
        public Person Owner { get; set; }
        public Size BoxSize { get; set; }
        public (int x, int y) Location { get; set; }

        public Mailbox(Person owner, Size boxSize, (int x, int y) location)
        {
            Owner = owner;
            BoxSize = boxSize;
            Location = location;
        }

        public string toString()
        {
            if (BoxSize == Size.Default)
            {
                return "";
            }

            bool premium = false;
            if (BoxSize == Size.Premium)
            {
                premium = true;
            }

            return premium ? "Premium " + BoxSize.ToString() : BoxSize.ToString();
        }
    }
}
