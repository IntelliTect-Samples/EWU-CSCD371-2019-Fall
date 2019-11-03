using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream Stream;
        private bool StreamDisposed = false;

        public DataLoader(Stream source)
        {
            Stream = source ?? throw new ArgumentNullException(nameof(source));
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            Stream.Position = 0;

            try
            {
                using (StreamReader reader = new StreamReader(Stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string? readInLine = reader.ReadLine();
                        Mailbox jsonMailbox = JsonConvert.DeserializeObject<Mailbox>(readInLine);
                        mailboxes.Add(jsonMailbox);
                    }
                }
            }
            catch(JsonReaderException)
            {
                return null;
            }
            
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Stream.Position = 0;

            using (StreamWriter writer = new StreamWriter(Stream))
            {
                foreach(Mailbox mailbox in mailboxes)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(mailbox));
                }
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if(!StreamDisposed)
            {
                Stream.Dispose();
            }
            StreamDisposed = true;
        }

        ~DataLoader()
        {
            Dispose(false);
        }

    }
}
