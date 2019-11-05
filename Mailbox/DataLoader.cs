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
            var mailboxList = new List<Mailbox>();

            mailboxList.Add(new Mailbox());

            return mailboxList;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!_isDisposed)
            {
                if(dispose)
                {
                    Stream?.Dispose();
                }

                _isDisposed = true;
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
