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

        static void Main(string[] args)
        {
            //Main does not need to be unit tested.
            using DataLoader dataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

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
                            Console.WriteLine("New mailbox added: " + mailbox);
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
            List<string> owners = new List<string>();
            string s = "";
            foreach(Mailbox m in mailboxes)
            {
                bool isValid = true;
                if(owners.Count > 0)
                {
                    foreach(string name in owners) //check if name is distinct from previous names
                    {
                        if (name.ToLower().Equals(m.Owner.ToString().ToLower()))
                        {
                            isValid = false;
                        }
                    }
                    if (isValid) //if it is distinct, then add it
                    {
                        owners.Add(m.Owner.ToString());
                    }
                }
                else
                {
                    owners.Add(m.Owner.ToString());
                }
            }
            if(owners.Count > 0)
            {
                foreach(string name in owners)
                {
                    s += (name + "\n");
                }
            }

            return s;
        }

        public static string GetMailboxDetails(Mailboxes mailboxes, int x, int y)
        {
            string s = null;
            foreach(Mailbox m in mailboxes)
            {
                if(m.Location == (x, y))
                {
                    s = m.ToString();
                }
            }
            return s;
        }

        public static Mailbox AddNewMailbox(Mailboxes mailboxes, string firstName, string lastName, Size size)
        {
            int x=0, y = 0;
            HashSet<Person> people;
            Person newPerson = new Person(firstName, lastName);
            Mailbox m = new Mailbox(size, 0, 0, newPerson);
            for(y = 0; y < mailboxes.Height; y++)
            {
                for(x = 0; x < mailboxes.Width; x++)
                {
                    if (!mailboxes.GetAdjacentPeople(x, y, out people)) //If it's not occupied
                    {
                        bool isValid = true;
                        foreach(Person p in people) //Look through each return person from GetAdjacentPeople
                        {
                            if (p.Equals(newPerson)) //Check if they are the same person
                            {
                                isValid = false;
                            }
                        }
                        if (isValid) //If no adjacent person is the same owner as the new mailbox, return the mailbox
                        {
                            m.Location = (x, y);
                            return m;
                        }
                    }
                }
            }
            return null;
        }
    }
}
