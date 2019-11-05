using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox
{
    internal class Program
    {
        private const int Width = 2;
        private const int Height = 1;

#pragma warning disable IDE0060 // Remove unused parameter

        private static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
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
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Mailbox mailbox in mailboxes)
            {
                stringBuilder.Append($"{mailbox.Owner.ToString()}, ");
            }
            if (stringBuilder.Length > 2)
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            return stringBuilder.ToString();
        }

        public static string? GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            foreach (Mailbox mailbox in mailboxes)
            {
                if (mailbox.Location.x == x && mailbox.Location.y == y)
                    return mailbox.ToString();
            }
            return null;
        }

        public static Mailbox? AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Sizes size)
        {
            Person personToAdd = new Person(firstName, lastName);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    bool isOccupied = mailboxes.GetAdjacentPeople(x, y, out HashSet<Person> adjecentPeople);
                    if (!isOccupied && !adjecentPeople.Contains(personToAdd))
                    {
                        return new Mailbox(size, (x, y), personToAdd);
                    }
                }
            }
            return null;
        }
    }
}