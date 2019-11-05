using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream _source;

        public DataLoader(Stream source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }
        public List<MailBox>? Load()

        {
            _source.Position = 0;
            using var reader = new StreamReader(_source, leaveOpen: true);
            try
            {
                return JsonConvert.DeserializeObject<List<MailBox>>(reader.ReadToEnd());
            }
            catch (JsonReaderException)
            {
                return null;
            }

        }
        {
        public void Save(List<MailBox> mailboxes)
            _source.Position = 0;

            using var writer = new StreamWriter(_source, leaveOpen: true);
            writer.WriteLine(JsonConvert.SerializeObject(mailboxes));
            writer.Flush();
        #region IDisposable Support

        }
        private bool disposedValue = false; // To detect redundant calls

        {
        protected virtual void Dispose(bool disposing)
            if (!disposedValue)
            {
                if (disposing)
                {
                    _source.Dispose();
                }
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
        #endregion

    }
}
