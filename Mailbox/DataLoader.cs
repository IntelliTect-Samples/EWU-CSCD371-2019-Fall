using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public Stream? Stream { get; }
        private bool _isDisposed;

        public DataLoader(Stream source)
        {
            this.Stream = source;
        }

        public List<Mailbox> Load()
        {
            return new List<Mailbox>();
        }

        public void Save(List<Mailbox> mailboxes)
        {
            
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!_isDisposed && dispose)
            {
                Stream?.Dispose();
            }
        }
        ~DataLoader()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
