using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Mailbox
{
    public class Program
    {
        private const int Width = 50;
        private const int Height = 10;

        static void Main(string[] _)
        {
            //Main does not need to be unit tested.
            using var dataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

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
                        if (!Enum.TryParse(Console.ReadLine(), out Sizes size))
                        {
                            size = Sizes.Small;
                        }

                        if (AddNewMailbox(boxes, firstName, lastName, size) is Mailbox mailbox)
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                        string[] parts = boxNumber?.Split(',');
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
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
            if (mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }

            List<Person> people = new List<Person>();
            
            foreach (Mailbox box in mailboxes)
            {
                if (!people.Contains(box.Owner))
                {
                    people.Add(box.Owner);
                }
            }
            
            StringBuilder builder = new StringBuilder();
            foreach (Person person in people)
            {
                builder.AppendLine(person.ToString());
            }


            return builder.ToString();
            
        }

        public static string? GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            if (mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }

            foreach (Mailbox box in mailboxes)
            {
                if (box.Location.Item1 == x && box.Location.Item2 == y)
                {
                    return box.ToString();
                }
            }
            return null;
        }

        public static Mailbox? AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes size)
        {
            if (mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("message", nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("message", nameof(lastName));
            }

            Person owner = new Person()
            {
                FirstName = firstName,
                LastName = lastName
            };

            for (int x = 0; x < mailboxes.Width; x++)
            {
                for (int y = 0; y < mailboxes.Height; y++)
                {
                    if (!mailboxes.GetAdjacentPeople(x,y, out HashSet<Person> adjacentPeople)
                            && !adjacentPeople.Contains(owner))
                    {
                        return new Mailbox(size, (x, y), owner);
                    }
                }
            }

            return null;
        }
    }
}
