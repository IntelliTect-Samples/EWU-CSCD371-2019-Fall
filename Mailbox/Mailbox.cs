using System;

namespace Mailbox {
    public class Mailbox {
        public Sizes _Size { get; }
        public (int, int) _Location { get; }
        public Person _Owner { get; set; }
        public Mailbox(Sizes size, (int, int) location, Person owner) {
            _Size = size;
            _Location = location;
            _Owner = owner;
        }

        public string toString() {
            return $"{"Size: " + _Size + " Location: (" + _Location + ") Owner: " + _Owner.toString()}";
        }
    }
}
