using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public Stream Source { get; set; }

        public DataLoader(Stream source)
        {
            Source = source;
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            Source.Seek(0, SeekOrigin.Begin);
            using StreamReader streamReader = new StreamReader(Source, new UTF8Encoding(), false, 1024, true);
            while (!(streamReader.EndOfStream))
            {
                string mailboxString = streamReader.ReadLine() ?? "";
                Mailbox mailbox = new Mailbox(Size.Default,(0,0),new Person("",""));
                try
                {
                    mailbox = JsonConvert.DeserializeObject<Mailbox>(mailboxString);
                }
                catch (JsonReaderException jsonReaderException)
                {
                    Console.WriteLine(nameof(jsonReaderException));
                    return null;
                }
                mailboxes.Add(mailbox);
            }
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Seek(0, SeekOrigin.Begin);
            using StreamWriter streamWriter = new StreamWriter(Source, new UTF8Encoding(), 1024, true);
            foreach (Mailbox mailbox in mailboxes)
            {
                streamWriter.WriteLine(mailbox.GetJson());
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                Source.Dispose();
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

        #endregion IDisposable Support
    }
}