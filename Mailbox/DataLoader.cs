using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public Stream Stream { get; }
        private bool _isDisposed;

        public DataLoader(Stream source)
        {
            this.Stream = source;
        }

        public List<Mailbox> Load()
        {
            var mailboxList = new List<Mailbox>();

            using var reader = new StreamReader(Stream, leaveOpen: true);
            string serialData = reader.ReadToEnd();

            mailboxList = JsonConvert.DeserializeObject<List<Mailbox>>(serialData);

            return mailboxList;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            using var streamWriter = new StreamWriter(Stream, leaveOpen: true);

            string mailboxData = JsonConvert.SerializeObject(mailboxes);

            streamWriter.WriteLine(mailboxData);
            streamWriter.Flush();

            Stream.Position = 0;
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
