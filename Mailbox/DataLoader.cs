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
                Mailbox mailbox = new Mailbox(Sizes.Default, (0, 0), new Person("", ""));
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
            if (mailboxes is null)
                throw new ArgumentNullException(nameof(mailboxes));
            Source.Seek(0, SeekOrigin.Begin);
            using StreamWriter streamWriter = new StreamWriter(Source, new UTF8Encoding(), 1024, true);
            foreach (Mailbox mailbox in mailboxes)
            {
                streamWriter.WriteLine(mailbox.GetJson());
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                Source.Dispose();
                disposedValue = true;
            }
        }

        ~DataLoader()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}