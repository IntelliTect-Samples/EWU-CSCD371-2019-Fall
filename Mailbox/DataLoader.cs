using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream Source;
        private bool StreamDisposed = false;
        public DataLoader(Stream source)
        {
            if(!(source is null))
            {
                Source = source;
            }
            else
            {
                throw new ArgumentNullException("DataLoader's Stream cannot be null");
            }
        }

        public List<Mailbox> Load()
        {
            Source.Position = 0;

            List<Mailbox> mailboxes = new List<Mailbox>();

            try
            {
                using (StreamReader sr = new StreamReader(Source))
                {
                    while(!sr.EndOfStream)
                    {
                       string? line = sr.ReadLine();
                       Mailbox newMailbox = JsonConvert.DeserializeObject<Mailbox>(line);
                       mailboxes.Add(newMailbox);
                    }

                    return mailboxes;
                };
            } 
            catch(JsonReaderException)
            {
                return null;
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;

            using (StreamWriter sw = new StreamWriter(Source))
            {
                foreach(Mailbox mailbox in mailboxes)
                {
                    sw.WriteLine(JsonConvert.SerializeObject(mailbox));
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
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
