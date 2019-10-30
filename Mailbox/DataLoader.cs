using System.Collections.Generic;
using System.IO;
using System;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public DataLoader(Stream source)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Mailbox> Load()
        {
            return null;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            
        }
    }
}
