using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public Stream stream { get; set; }
        public DataLoader(Stream source)
        {
            if (source == null)
                throw new ArgumentNullException("The source is null");
            stream = source;
        }

        public List<Mailbox> Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            stream.Position = 0;
            try
            {
                StreamReader reader = new StreamReader(stream);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Mailbox mailbox = JsonConvert.DeserializeObject<Mailbox>(line);
                    mailboxes.Add(mailbox);
                }
                return mailboxes;
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            if (mailboxes == null)
                throw new ArgumentNullException("mailboxes are null");

            stream.Position = 0;

            StreamWriter writer = new StreamWriter(stream);
            foreach (Mailbox mailbox in mailboxes)
            {
                writer.Write(JsonConvert.SerializeObject(mailbox));
            }
        }

        public void Dispose()
        {
            stream.Dispose();
        }
    }
}
