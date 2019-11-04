using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source;

        public DataLoader(Stream source)
        {
            Source = source;
        }

        public void Dispose()
        {
            if (Source != null)
                Source.Dispose();
        }

        public List<Mailbox> Load()
        {
            var mailboxes = new List<Mailbox>();
            
            using (var sr = new StreamReader(Source)) 
            {
                Source.Position = 0;
                do 
                {
                    string line = sr.ReadLine();

                    mailboxes.Add(JsonConvert.DeserializeObject<Mailbox>(line));
                } 
                while (sr.EndOfStream is false);
            }

            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            using (var sw = new StreamWriter(Source))
            {
                foreach (Mailbox mailbox in mailboxes) 
                {
                    sw.WriteLine(JsonConvert.SerializeObject(mailbox));
                }
            }
        }
    }
}
