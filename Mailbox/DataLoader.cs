using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private bool _Disposed = false;
        public Stream Source { get; }
        public DataLoader(Stream source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes;
            Source.Position = 0;
            using var sr = new StreamReader(Source, leaveOpen: true);

            try
            {
                mailboxes = JsonConvert.DeserializeObject<List<Mailbox>>(sr.ReadToEnd());
                return mailboxes;
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;
            using var sw = new StreamWriter(Source, leaveOpen: true);

            sw.Write(JsonConvert.SerializeObject(mailboxes));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            if (disposing)
            {
                Source?.Dispose();
            }

            _Disposed = true;
        }

        ~DataLoader()
        {
            Dispose(false);
        }
    }
}
