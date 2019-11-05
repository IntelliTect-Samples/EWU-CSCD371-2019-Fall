using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Mailbox
{

    public static class Program
    {

        private const int Width  = 50;
        private const int Height = 10;

        static void Main(string[] args)
        {
            //Main does not need to be unit tested.
            using var dataLoader =
                new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            Mailboxes boxes = new Mailboxes(dataLoader.Load() ?? new List<Mailbox>(), Width, Height);

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
                        if (!Enum.TryParse(Console.ReadLine(), out Size size))
                        {
                            size = Size.Small;
                        }

                        if (AddNewMailbox(boxes, firstName, lastName, size) is Mailbox mailbox)
                        {
                            boxes.Add(mailbox);
                            Console.WriteLine("New mailbox added");
                        } else
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
                        string   boxNumber = Console.ReadLine();
                        string[] parts     = boxNumber?.Split(',');
                        if (parts?.Length == 2
                         && int.TryParse(parts[0], out int x)
                         && int.TryParse(parts[1], out int y))
                        {
                            Console.WriteLine(GetMailboxDetails(boxes, x, y));
                        } else
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

            var owners = new StringBuilder();
            foreach (var person in mailboxes.Select(mailbox => mailbox.Owner).Distinct())
            {
                owners.Append(person).Append(Environment.NewLine);
            }

            return owners.ToString();
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            if (mailboxes is null) throw new ArgumentNullException(nameof(mailboxes));

            return mailboxes.Find(mailbox => mailbox.Location == (x, y))?.ToString();
        }

        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Size size)
        {
            if (mailboxes is null) throw new ArgumentNullException(nameof(mailboxes));
            if (firstName is null) throw new ArgumentNullException(nameof(firstName));
            if (lastName is null) throw new ArgumentNullException(nameof(lastName));

            var person = new Person(firstName, lastName);
            for (var x = 0; x < mailboxes.Width; x++)
            {
                for (var y = 0; y < mailboxes.Height; y++)
                {
                    if (!mailboxes.GetAdjacentPeople(x, y, out var people) && !people.Contains(person))
                    {
                        return new Mailbox(person, size, (x, y));
                    }
                }
            }

            return null;
        }

    }

}
