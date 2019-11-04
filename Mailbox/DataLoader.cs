using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private Stream Source;
        private bool disposedValue = false;
        public DataLoader(Stream source)
        {
            if (source is null)
            {
                throw new System.ArgumentNullException(nameof(source), "Source is null");
            }
            Source = source;
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            Source.Position = 0;
            using StreamReader streamReader = new StreamReader(Source, leaveOpen: true);
            try
            {
                string? mailboxIn = streamReader.ReadLine();
                Mailbox mailbox = JsonConvert.DeserializeObject<Mailbox>(mailboxIn);
                mailboxes.Add(mailbox);

                return mailboxes;
            } catch (ArgumentNullException)
            {
                return null;
            } catch (JsonReaderException)
            {
                return null;
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            if (mailboxes is null)
            {
                throw new ArgumentNullException(nameof(mailboxes), "List of mailboxes is null");
            }

            using StreamWriter streamWriter = new StreamWriter(Source, leaveOpen: true);
            Source.Position = 0;

            foreach (Mailbox mailbox in mailboxes)
            {
                string mailboxOut = JsonConvert.SerializeObject(mailbox);
                streamWriter.WriteLine(mailboxOut);
            }
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataLoader()
        {
            Dispose(false);
        }
    }
}
