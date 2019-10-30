using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public Stream Stream { get; }

        public DataLoader(Stream source)
        {

        }

        public List<Mailbox> Load()
        {
            return new List<Mailbox>();
        }

        public void Save(List<Mailbox> mailboxes)
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
