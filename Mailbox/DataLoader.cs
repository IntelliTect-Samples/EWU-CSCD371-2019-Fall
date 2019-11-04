using System.Collections.Generic;
using System.IO;
using System;

namespace Mailbox
{
    public class DataLoader
    {
        Stream stream;
        public DataLoader(Stream source)
        {
            stream = source;
        }

        public List<Mailbox> Load()
        {
            stream.Position = 0;
            List<Mailbox> mailboxes = new List<Mailbox>();
            StreamReader reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] ls = line.Split(",");
                string[] personSplit = ls[3].Split(" ");
                Mailbox m = new Mailbox((Size)Enum.Parse(typeof(Size), ls[0]), int.Parse(ls[1]), int.Parse(ls[2]), new Person(personSplit[0], personSplit[1]));
            }

            reader.Dispose();
        }

        public void Save(List<Mailbox> mailboxes)
        {
            stream.Position = 0;
            StreamWriter writer = new StreamWriter(stream);
            foreach(Mailbox m in mailboxes)
            {
                writer.Write(m.MailboxSize + "," + m.Location.x + "," + m.Location.y + "," + m.Owner);
            }

            writer.Dispose();
        }
    }
}
