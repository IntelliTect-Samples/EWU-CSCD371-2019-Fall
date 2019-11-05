using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; }

        public DataLoader(Stream source) =>
            Source = source ?? throw new ArgumentNullException(nameof(source));

        public List<Mailbox>? Load()
        {
            Source.Position = 0;
            using var reader = new StreamReader(Source, leaveOpen: true);
            try
            {
                return JsonConvert.DeserializeObject<List<Mailbox>>(reader.ReadToEnd());
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            if (mailboxes is null) throw new ArgumentNullException(nameof(mailboxes));

            Source.Position = 0;
            using var writer = new StreamWriter(Source, leaveOpen: true);
            writer.WriteLine(JsonConvert.SerializeObject(mailboxes));
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing) Source.Dispose();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
