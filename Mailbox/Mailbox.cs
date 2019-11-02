using System;

namespace Mailbox
{

    public class Mailbox
    {
        public Person Owner { get; set; }
        public Sizes BoxSize { get; set; }
        public (int x, int y) Location { get; set; }

        public Mailbox(Person owner, Sizes boxSize, (int x, int y) location)
        {
            Owner = owner;
            BoxSize = boxSize;
            Location = location;
        }

        public string toString()
        {
            if (BoxSize == Sizes.Default)
            {
                return "";
            }

            //return premium ? $"Owner: {Owner.toString()}, Premium " + BoxSize.ToString() : $"Owner: {Owner.toString()}, " + BoxSize.ToString();
            return $"Owner: {Owner.toString()}, " + BoxSize.ToString();
        }
    }
}
