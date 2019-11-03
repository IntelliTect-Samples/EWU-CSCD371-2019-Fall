using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Mailbox
{
    class Program
    {
        private const int Width = 50;
        private const int Height = 10;

        public static void Main(string[] args)
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

        public static string GetOwnersDisplay(Mailboxes mailboxes)
        {
            string allMailboxes = "";
            foreach(Mailbox mailbox in mailboxes)
            {
                allMailboxes += mailbox.ToString() + "\n";
            }
            return allMailboxes;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            foreach(Mailbox mailbox in mailboxes)
            {
                if(mailbox.Location == (x,y))
                {
                    return mailbox.ToString();
                }
            }
            return null;
        }

        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Size size)
        { 
            if(mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes));
            }
            Person newPerson = new Person(firstName, lastName);
            for (int i = 1; i < 30; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    foreach (Mailbox mailbox in mailboxes)
                    {
                        HashSet<Person> adjacentPeople = new HashSet<Person>();
                        bool goodSpot = mailboxes.GetAdjacentPeople(mailbox.Location.Column, mailbox.Location.Row, out adjacentPeople);
                        if (!goodSpot  && !adjacentPeople.Contains(newPerson))
                        {
                            ValueTuple<int, int> newLocation = new ValueTuple<int, int>(i, j);
                            Mailbox newMailbox = new Mailbox(size, newLocation, newPerson);
                            return newMailbox;
                        }
                    }
                }
            }
            return null;            
        }
    }
}
