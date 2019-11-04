using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MailRoom
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; }

        public DataLoader(Stream source) => Source = source ?? throw new ArgumentNullException(nameof(source));

        public List<Mailbox>? Load()
        {
            Source.Position = 0;
            using StreamReader reader = new StreamReader(Source, leaveOpen: true);

            List<Mailbox> ret;
            try
            {
                ret = JsonConvert.DeserializeObject<List<Mailbox>>( reader.ReadToEnd() );
            }
            catch(JsonReaderException)
            {
                return null;
            }

            return ret;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;
            using StreamWriter writer = new StreamWriter(Source, leaveOpen: true);

            writer.Write(JsonConvert.SerializeObject(mailboxes));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing) Source.Dispose();

                disposedValue = true;
            }
        }

        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        ~DataLoader() => Dispose(false);

        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
