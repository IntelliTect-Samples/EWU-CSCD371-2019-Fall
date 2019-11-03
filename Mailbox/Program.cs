﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                        boxes.Add(AddNewMailbox(boxes, firstName, lastName, size));

                        Console.WriteLine("New mailbox added");
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
                        string[] parts = boxNumber?.Split(',');
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

            var sb = new StringBuilder();

            var hashSet = new HashSet<Person>();

            foreach(Mailbox mailbox in mailboxes)
            {
                hashSet.Add(mailbox.Owner);
            }

            foreach(Person person in hashSet)
            {
                sb.AppendLine(person.ToString());
            }

            return sb.ToString();
        }

        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes size)
        {
            //Find an unoccupied box that is not adjacent to another box with the same first or last name
            //Adjacent means orthogonal
            var newOwner = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            for (int y = 0; y < mailboxes.Height; y++)
            {
                for (int x = 0; x < mailboxes.Width; x++)
                {
                    if (!mailboxes.GetAdjacentPeople(x, y, out HashSet<Person> adjacentPeople) && 
                        !adjacentPeople.Contains(newOwner))
                    {
                        return new Mailbox((x, y), size, newOwner);
                    }
                }
            }

            return default;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            foreach (Mailbox mailbox in mailboxes)
            {
                if (mailbox.Location == (x, y))
                {
                    return mailbox.ToString();
                }
            }
            return null;
        }
    }
}
