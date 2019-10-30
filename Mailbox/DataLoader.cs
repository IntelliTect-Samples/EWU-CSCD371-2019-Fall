using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; set; }
        public DataLoader(Stream source)
        {
            if(!source.Equals(null))
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
            List<Mailbox> mailboxes = new List<Mailbox>();
            //Source.Seek

            using (StreamReader sr = new StreamReader(Source))
            {
                //Check if JSON

                
            };

            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            using (StreamWriter sw = new StreamWriter(Source))
            {

            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
