using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream _Stream;
        private bool _StreamDisposed = false;

        public DataLoader(Stream source)
        {
            _Stream = source ?? throw new ArgumentNullException(nameof(source));
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            _Stream.Position = 0;

            try
            {
                using (StreamReader reader = new StreamReader(_Stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string? readInLine = reader.ReadLine();
                        Mailbox jsonMailbox = JsonConvert.DeserializeObject<Mailbox>(readInLine);
                        mailboxes.Add(jsonMailbox);
                    }
                }
            }
            catch(JsonReaderException)
            {
                return null;
            }
            
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            _Stream.Position = 0;

            using (StreamWriter writer = new StreamWriter(_Stream))
            {
                foreach(Mailbox mailbox in mailboxes)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(mailbox));
                }
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if(!_StreamDisposed)
            {
                _Stream.Dispose();
            }
            _StreamDisposed = true;
        }

        ~DataLoader()
        {
            Dispose(false);
        }

    }
}
