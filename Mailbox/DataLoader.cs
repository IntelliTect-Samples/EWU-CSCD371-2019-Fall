using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream Source;
        private bool StreamDisposed = false;

        public DataLoader(Stream source)
        {
            if(source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            Source = source;
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            Source.Position = 0;

            try
            {
                using (StreamReader reader = new StreamReader(Source))
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
            Source.Position = 0;

            using (StreamWriter writer = new StreamWriter(Source, leaveOpen:true))
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
                Source.Dispose();
            }
            StreamDisposed = true;
        }

        ~DataLoader()
        {
            Dispose(false);
        }

    }
}
