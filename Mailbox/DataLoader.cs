using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{

    public class DataLoader : IDisposable
    {

        public Stream Stream { get; }

        private bool _disposed;

        public DataLoader(Stream? source) => Stream = source ?? throw new ArgumentNullException(nameof(source));

        public List<Mailbox> Load()
        {
            Stream.Position = 0;
            using var reader = new StreamReader(Stream, leaveOpen: true);

            try
            {
                return JsonConvert.DeserializeObject<List<Mailbox>>(reader.ReadToEnd());
            } catch (JsonReaderException)
            {
                return null;
            } finally
            {
                reader.Dispose();
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            if (mailboxes is null) throw new ArgumentNullException(nameof(mailboxes));

            Stream.Position = 0;
            using var writer = new StreamWriter(Stream, leaveOpen: true);
            writer.Write(JsonConvert.SerializeObject(mailboxes));
            writer.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Stream.Dispose();
            }

            _disposed = true;
        }

        ~DataLoader()
        {
            Dispose(false);
        }

    }

}
