namespace Mailbox {
    public class Mailboxes {

        public Mailbox[,] MailboxesArray { get; }

        public Mailboxes(Mailbox[,] mailboxes) {
            MailboxesArray = mailboxes;
        }

        public (int, int) FindValidLocation(Person owner) {
            for (int i = 0; i < MailboxesArray.GetLength(0); i++) {
                for (int j = 0; j < MailboxesArray.GetLength(1); j++) {
                    if (CanOwnBox(owner, i, j)) {
                        return (i, j);
                    }
                }
            }
            return (-1, -1); // No available box
        }

        private bool CanOwnBox(Person owner, int x, int y) {
            //Checking current location
            if (MailboxesArray[x, y] != null) {
                return false;
            }
            //Checking right
            if (x + 1 < MailboxesArray.GetLength(0) && MailboxesArray[x + 1, y] != null && MailboxesArray[x + 1, y].Owner.Equals(owner)) {
                return false;
            }
            //Checking left
            if (x - 1 >= 0 && MailboxesArray[x - 1, y] != null && MailboxesArray[x - 1, y].Owner.Equals(owner)) {
                return false;
            }
            //Checking up
            if (y - 1 >= 0 && MailboxesArray[x, y - 1] != null && MailboxesArray[x, y - 1].Owner.Equals(owner)) {
                return false;
            }
            //Checking down
            if (y + 1 < MailboxesArray.GetLength(1) && MailboxesArray[x, y + 1] != null && MailboxesArray[x, y + 1].Owner.Equals(owner)) {
                return false;
            }
            return true;
        }
    }
}
