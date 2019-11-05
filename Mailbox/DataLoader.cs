using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source { get; set; }
        public DataLoader(Stream source)
        {
            Source = source;
        }

        public List<Mailbox>? Load()
        {
            Source.Position = 0;
            List<Mailbox> mailboxes = new List<Mailbox>();
            try
            {
                using var reader = new StreamReader(Source);
                while (!(reader.EndOfStream))
                {
                    mailboxes.Add(JsonConvert.DeserializeObject<Mailbox>(reader.ReadLine()));
                }
            }
            catch (JsonReaderException)
            {
                return null;
            }
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            Source.Position = 0;
            using var writer = new StreamWriter(Source, leaveOpen:true);
            foreach(Mailbox mailbox in mailboxes)
            {
                writer.WriteLine(JsonConvert.SerializeObject(mailbox));
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
                    Source.Dispose();
                }
                disposedValue = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
