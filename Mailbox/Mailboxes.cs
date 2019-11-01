using System;
using System.Collections.Generic;

namespace Mailbox {
    public class Mailboxes : List<Mailbox> {
        public Mailboxes(IEnumerable<Mailbox> collection, int width, int height)
            : base(collection) {
            if (width < 0) {
                throw new ArgumentOutOfRangeException(nameof(width));
            }
            if (height < 0) {
                throw new ArgumentOutOfRangeException(nameof(height));
            }
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }

        public bool GetAdjacentPeople(int x, int y, out HashSet<Person> adjacentPeople) {
            adjacentPeople = new HashSet<Person>();
            bool isOccupied = false;

            foreach (Mailbox mailbox in this) {
                //current
                if (mailbox._Location == (x, y)) {
                    isOccupied = true;
                }
                //above
                if (mailbox._Location == (x, y - 1)) {
                    adjacentPeople.Add(mailbox._Owner);
                }
                //right
                if (mailbox._Location == (x + 1, y)) {
                    adjacentPeople.Add(mailbox._Owner);
                }
                //bottom
                if (mailbox._Location == (x, y + 1)) {
                    adjacentPeople.Add(mailbox._Owner);
                }
                //left
                if (mailbox._Location == (x - 1, y)) {
                    adjacentPeople.Add(mailbox._Owner);
                }
            }

            return isOccupied;
        }
    }
}
