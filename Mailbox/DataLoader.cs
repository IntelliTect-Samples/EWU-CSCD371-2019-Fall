using System.Collections.Generic;
using System.IO;
using System;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; }
        public DataLoader(Stream source)
        {
            Source = source;
        }

        public List<Mailbox> Load()
        {
            Source.Position = 0;
            using StreamReader reader = new StreamReader(Source, leaveOpen: true);
            string data = reader.ReadToEnd();
            List<Mailbox> ret = JsonConvert.DeserializeObject<List<Mailbox>>(data);
            return ret;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;
            using StreamWriter writer = new StreamWriter(Source, leaveOpen: true);
            string data = JsonConvert.SerializeObject(mailboxes);
            writer.Write(data);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (Source is object && dispose)
            {
                Source.Dispose();
            }
        }
    }
}
