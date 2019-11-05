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
            List<Mailbox> mailboxes = new List<Mailbox>();
            Source.Position = 0;
            try
            {
                using (var reader = new StreamReader(Source,leaveOpen:true))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Mailbox mailbox = JsonConvert.DeserializeObject<Mailbox>(line);
                        mailboxes.Add(mailbox);
                    }
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
            using (StreamWriter writer = new StreamWriter(Source, leaveOpen: true))
            {
                foreach (Mailbox mailbox in mailboxes)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(mailbox));
                }
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
