using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        
        public Stream Stream { get; }

        public DataLoader(Stream source) => Stream = source ?? throw new ArgumentNullException(nameof(source));

        public List<Mailbox> Load()
        {
            throw new NotImplementedException();
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
