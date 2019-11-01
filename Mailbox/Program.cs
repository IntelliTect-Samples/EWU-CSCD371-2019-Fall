using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox {
    class Program {
        private const int Width = 50;
        private const int Height = 10;

        static void Main(string[] args) {
            //Main does not need to be unit tested.
            var dataLoader = new DataLoader("Mailboxes.json");

            Mailboxes boxes = new Mailboxes(dataLoader.Load() ?? new Mailbox[Width, Height]);

            while (true) {
                int selection;
                do {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine(" 1. Add a new mailbox");
                    Console.WriteLine(" 2. List existing owners");
                    Console.WriteLine(" 3. Save changes");
                    Console.WriteLine(" 4. Show mailbox details");
                    Console.WriteLine(" 5. Quit");

                    if (!int.TryParse(Console.ReadLine(), out selection)) {
                        selection = 0;
                    }
                } while (selection == 0);

                switch (selection) {
                    case 1:
                        Console.WriteLine("Enter the first name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("What size?");
                        if (!Enum.TryParse(Console.ReadLine(), out Sizes size)) {
                            size = Sizes.Small;
                        }

                        if (AddNewMailbox(boxes, firstName, lastName, size) is Mailbox mailbox) {
                            boxes._Mailboxes[mailbox._Location.Item1, mailbox._Location.Item2] = mailbox;
                            Console.WriteLine("New mailbox added");
                        } else {
                            Console.WriteLine("No available location");
                        }

                        break;
                    case 2:
                        Console.WriteLine(GetOwnersDisplay(boxes));
                        break;
                    case 3:
                        dataLoader.Save(boxes._Mailboxes);
                        Console.WriteLine("Saved");
                        break;
                    case 4:
                        Console.WriteLine("Enter box number as x,y");
                        string boxNumber = Console.ReadLine();
                        string[] parts = boxNumber?.Split(',');
                        if (parts?.Length == 2 &&
                            int.TryParse(parts[0], out int x) &&
                            int.TryParse(parts[1], out int y)) {
                            Console.WriteLine(GetMailboxDetails(boxes, x, y));
                        } else {
                            Console.WriteLine("Invalid box number");
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        public static string GetOwnersDisplay(Mailboxes mailboxes) {
            string result = "";
            foreach (Mailbox mailbox in mailboxes._Mailboxes) {
                if (mailbox is null) {
                    continue;
                }
                result += mailbox._Owner.toString() + "\n";
            }
            return result;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y) {
            try {
                return mailboxes._Mailboxes[x, y].toString();
            } catch (NullReferenceException) {
                return "Mailbox is unused.";
            }
        }
        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes size) {
            Person owner = new Person(firstName, lastName);
            (int, int) location = mailboxes.findValidLocation(owner);
            if (location.Equals((-1, -1))) {
                return null;
            }
            return new Mailbox(size, location, owner);
        }
    }
}
