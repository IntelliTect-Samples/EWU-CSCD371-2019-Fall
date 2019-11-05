using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream source;
        private StreamWriter? streamWriter;
        private StreamReader? streamReader;

        public DataLoader(Stream source)
        {
            this.source = source;
        }

        public List<Mailbox> Load()
        {
            source.Position = 0;
            streamReader = new StreamReader(source);

            List<Mailbox> mailboxList = JsonConvert.DeserializeObject<List<Mailbox>>(streamReader.ReadToEnd());

            if(mailboxList == null)
            {
                return new List<Mailbox>();
            }

            List<Mailbox> mailboxes = new Mailboxes(mailboxList, 30, 10);
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            source.Position = 0;
            streamWriter = new StreamWriter(source);

            streamWriter.Write(JsonConvert.SerializeObject(mailboxes));
            streamWriter.Flush();
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
                    source.Dispose();
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
