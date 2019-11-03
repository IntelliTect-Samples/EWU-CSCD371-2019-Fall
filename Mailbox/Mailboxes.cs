using System;
using System.Collections.Generic;

namespace Mailbox
{
    public class Mailboxes : List<Mailbox>
    {
        public Mailboxes(IEnumerable<Mailbox> collection, int width, int height) 
            : base(collection)
        { 
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }

        public bool GetAdjacentPeople(int x, int y, out HashSet<Person> adjacentPeople)
        {
            adjacentPeople = new HashSet<Person>();
            bool isOccupied = false;

            foreach(Mailbox mailbox in this)
            {
                //current
                if (mailbox.Location == (x, y))
                {
                    isOccupied = true;
                }
                //above
                if (mailbox.Location == (x, y - 1))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //right
                if (mailbox.Location == (x + 1, y))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //bottom
                if (mailbox.Location == (x, y + 1))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
                //left
                if (mailbox.Location == (x - 1, y))
                {
                    adjacentPeople.Add(mailbox.Owner);
                }
            }

            return isOccupied;
        }
    }
}
