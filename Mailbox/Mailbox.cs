namespace Mailbox {
    public class Mailbox {
        public Sizes Size { get; }
        public (int, int) Location { get; }
        public Person Owner { get; set; }
        public Mailbox(Sizes Size, (int, int) Location, Person Owner) {
            this.Size = Size;
            this.Location = Location;
            this.Owner = Owner;
        }

        public string toString() {
            return $"{"Size: " + Size + " Location: (" + Location + ") Owner: " + Owner.toString()}";
        }
    }
}
