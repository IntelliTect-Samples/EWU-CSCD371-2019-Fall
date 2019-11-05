using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{
    class Program
    {
        private const int Width = 50;
        private const int Height = 10;

        static void Main(string[] args)
        {
            //Main does not need to be unit tested.
            using var dataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            Mailboxes boxes = new Mailboxes(dataLoader.Load() ?? new List<MailBox>(), Width, Height);

            while (true)
            {
                int selection;
                do
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine(" 1. Add a new mailbox");
                    Console.WriteLine(" 2. List existing owners");
                    Console.WriteLine(" 3. Save changes");
                    Console.WriteLine(" 4. Show mailbox details");
                    Console.WriteLine(" 5. Quit");

                    if (!int.TryParse(Console.ReadLine(), out selection))
                    {
                        selection = 0;
                    }
                } while (selection == 0);

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter the first name");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("What size?");
                        if (!Enum.TryParse(Console.ReadLine(), out Sizes size))
                        {
                            size = Sizes.Small;
                        }

                        if (AddNewMailbox(boxes, firstName, lastName, size) is MailBox mailbox)
                        {
                            boxes.Add(mailbox);
                            Console.WriteLine("New mailbox added");
                        }
                        else
                        {
                            Console.WriteLine("No available location");
                        }

                        break;
                    case 2:
                        Console.WriteLine(GetOwnersDisplay(boxes));
                        break;
                    case 3:
                        dataLoader.Save(boxes);
                        Console.WriteLine("Saved");
                        break;
                    case 4:
                        Console.WriteLine("Enter box number as x,y");
                        string boxNumber = Console.ReadLine();
                        string[]? parts = boxNumber?.Split(',');
                        if (parts?.Length == 2 &&
                            int.TryParse(parts[0], out int x) &&
                            int.TryParse(parts[1], out int y))
                        {
                            Console.WriteLine(GetMailboxDetails(boxes, x, y));
                        }
                        else
                        {
                            Console.WriteLine("Invalid box number");
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        public static string GetOwnersDisplay(Mailboxes mailboxes)
        {
            if (mailboxes is null) throw new ArgumentNullException(nameof(mailboxes));

            string owners = "";
            foreach (var item in mailboxes)
            {
                owners += item.Owner;
            }
            return owners;
        }

        public static string? GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            foreach (MailBox mailbox in mailboxes)
            {
                if (mailbox.Location == (x, y))
                {
                    return mailbox.ToString();
                }
            }

            return null;
        }

        public static MailBox? AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes size)
        {
            Person person = new Person(firstName, lastName);
            for (int i = 0; i < mailboxes.Height; i++)
            {
                for (int j = 0; j < mailboxes.Width; j++)
                {
                    bool isOccupied = mailboxes.GetAdjacentPeople(i, j, out HashSet<Person> adjacentPeople);

                    if (!adjacentPeople.Contains(person) && isOccupied == false)
                    {
                        return new MailBox(size, (i, j), person);
                    }
                }
            }
            return null;
        }
    }
}
/*
 * The Main method has already been implemented for you. Unless you are doing the extra credit, you should not need to modify it. You will probably want to implement the other classes before implementing this class.
- Implement GetOwnersDisplay. This method should return a **distinct** list of people who are owners on the mailboxes.
- Implement GetMailboxDetails. This method should return a string that contains all of the details of the specified mailbox, or null if the mailbox cannot be found.
- Implement AddNewMailbox. This method should find an unoccupied location in the Mailboxes and return a new `Mailbox` instance if a location is found.
    A mailbox *may not be placed adjacent* to another mailbox that contains a person with the same name. Adjacent is defined as orthogonal.
    There is a method on `Mailboxes` that should be helpful here. It should **not** modify the passed in `mailboxes`.
*/
