using System.Collections.Generic;
using System.IO;
using System;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        Stream stream;
        public DataLoader(System.IO.Stream source)
        {
            stream = source;
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        public List<Mailbox> Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8, true, 1024, true))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    try
                    {
                        Mailbox m = JsonConvert.DeserializeObject<Mailbox>(line);
                        Console.WriteLine(m);
                        mailboxes.Add(m);
                    }
                    catch (JsonReaderException e)
                    {
                        Console.WriteLine(e);
                        return null;
                    }
                }
            }
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            using(StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8, 1024, true))
            {
                writer.BaseStream.Position = 0;
                foreach(Mailbox m in mailboxes)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(m));
                }
            }
        }
    }
}
