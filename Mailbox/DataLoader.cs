using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; set; }

        public DataLoader(Stream source) => Source = source ?? throw new ArgumentNullException(nameof(source));

        public List<Mailbox>? Load()
        {
            Source.Seek(0, SeekOrigin.Begin);
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
            Source.Seek(0, SeekOrigin.Begin);
            using StreamWriter writer = new StreamWriter(Source, leaveOpen: true); //, encoding: System.Text.Encoding.

            writer.Write(JsonConvert.SerializeObject(mailboxes));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Source.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~DataLoader()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
