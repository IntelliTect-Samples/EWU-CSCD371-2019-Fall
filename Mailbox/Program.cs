using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MailRoom
{
    public static class Program
    {
        private const int Width = 50;
        private const int Height = 10;

        public static void Main(string[] args)
        {
            //Main does not need to be unit tested.
            using var dataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            MailboxCollection boxes = new MailboxCollection(dataLoader.Load() ?? new List<Mailbox>(), Width, Height);

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

        public static HashSet<Person> GetAllOwners(MailboxCollection mailboxes)
        {
            HashSet<Person> owners = new HashSet<Person>();
            if (mailboxes is null || mailboxes.Count == 0) return owners;

            foreach (Mailbox box in mailboxes) owners.Add(box.Owner);

            return owners;
        }

        public static string GetOwnersDisplay(MailboxCollection mailboxes)
        {
            if (mailboxes is null || mailboxes.Count == 0) return "";

            return string.Join(Environment.NewLine, GetAllOwners(mailboxes));
        }

        public static string? GetMailboxDetails(MailboxCollection mailboxes, int x, int y)
        {
            if (mailboxes is null || mailboxes.Count == 0) return null;

            (int, int) location = (x, y);
            Mailbox? target = mailboxes.Find(box => location == box.Location);

            return target?.ToString() ?? null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "using full multidimension array, jagged would just complicate it.")]
        public static Mailbox? AddNewMailbox(MailboxCollection mailboxes, string firstName, string lastName, Sizes size)
        {
            if (mailboxes is null) return null;

            (int, int) target = (-1, -1);

            // if the new owner doesn't have a box, we don't need to check adjacent cells
            // vastly cuts down the amount of list traversal if we dont need to check
            Person newOwner = new Person(firstName, lastName);
            HashSet<Person> currentOwners = GetAllOwners(mailboxes);
            bool checkAdjacent = currentOwners.Contains(newOwner);

            // create an array indicating occupied spots
            // avoids searching the entire mailboxes array on each spot, to see if occupied
            bool[,] occupied = new bool[mailboxes.Height, mailboxes.Width];
            foreach(Mailbox box in mailboxes) occupied[box.Location.Y, box.Location.X] = true;

            // proceed through list of boxes, checking unoccupied boxes if they're valid for use
            for (int y = 0; y < mailboxes.Height; y++)
            {
                for (int x = 0; x < mailboxes.Width; x++)
                {
                    if (occupied[y, x]) continue;

                    if (checkAdjacent)
                    {
                        mailboxes.GetAdjacentPeople(x, y, out HashSet<Person> adjacentPeople);
                        if (adjacentPeople.Contains(newOwner)) continue;
                    }

                    target = (x, y);
                    break;

                }
            }

            if (target == (-1, -1)) return null;

            return new Mailbox(newOwner, target, size);
        }
    }
}
