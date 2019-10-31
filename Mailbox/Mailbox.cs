namespace Mailbox {
    public class Mailbox {
        private Size size { get; set; }
        private int[] location { get; set; }
        private Person owner { get; set; }

        public string toString() {
            return $"Size: " + size + " Location: (" + location[0] + "," + location[1] + ") Owner: " + owner.toString();
        }
    }
}
