using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Mailbox
{
    public class Program
    {
        private const int Width = 50;
        private const int Height = 10;

        static void Main(string[] args)
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
                        if (!Enum.TryParse(Console.ReadLine(), out Size size))
                        {
                            size = Size.Small;
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
                        string[] parts = boxNumber.Split(',');
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

        public static string? GetOwnersDisplay(Mailboxes mailboxes)
        {
            HashSet<Person> owners = new HashSet<Person>();

            foreach(Mailbox mailbox in mailboxes)
            {
                owners.Add(mailbox.Owner);
            }

            string output = "";
            foreach(Person owner in owners)
            {
                output += owner.ToString() + '\n';
            }

            return output;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            return "";//TODO
        }

        public static Mailbox? AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Size size)
        {
            int width = mailboxes.Width;
            int height = mailboxes.Height;

            for (int i = 0; i < width; i++)
            {
                for (int a = 0; a < height; i++)
                {
                    if (!mailboxes.GetAdjacentPeople(i, a, out HashSet<Person> personSet))
                    {
                        Boolean valid = true;

                        foreach (Person pers in personSet)
                        {
                            if (pers.Equals(new Person(firstName, lastName)))
                            {
                                valid = false;
                            }
                        }

                        if (i > width-1 || a > height-1) //the program is auto-stepping-over my "for" tests
                        {
                            return null;
                        }

                        if (valid)
                        {
                            return new Mailbox(size, (i, a), new Person(firstName, lastName));
                        }
                    }
                }
            }

            return null;
        }
    }
}
