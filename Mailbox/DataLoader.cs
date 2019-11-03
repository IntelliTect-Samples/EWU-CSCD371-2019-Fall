using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream _source;

        public DataLoader(Stream source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        /*
        public void Dispose()
        {
            _source.Dispose();
        }
        */
        public List<Mailbox> Load()
        {
            /*
            using (StreamReader sr = new StreamReader(_source))
            {
                try
                {
                    string  = sr.ReadToEnd();

                    JsonConvert.SerializeObject
                    return new List<Mailbox>();
                }
                catch
                {

                }
            }
            */
            return new List<Mailbox>();
        }
        
        public void Save(List<Mailbox> mailboxes)
        {

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
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DataLoader()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
