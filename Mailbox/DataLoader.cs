using Newtonsoft.Json;
using System;
using System.IO;

namespace Mailbox {
    public class DataLoader : IDisposable {
        bool disposed = false;

        private readonly Stream _Source;
        public DataLoader(Stream source) {
            _Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public Mailbox[,] Load() {
            _Source.Position = 0;
            Mailbox[,] result;
            using (StreamReader sr = new StreamReader(_Source, leaveOpen: true)) {
                try {
                    result = JsonConvert.DeserializeObject<Mailbox[,]>(sr.ReadLine());
                } catch (JsonReaderException) {
                    return null;
                }
            }
            return result;
        }

        public void Save(Mailbox[,] mailboxes) {
            _Source.Position = 0;
            using (StreamWriter sw = new StreamWriter(_Source, leaveOpen: true)) {
                sw.WriteLine(JsonConvert.SerializeObject(mailboxes));
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposed)
                return;

            if (disposing) {
                _Source.Dispose();
            }

            disposed = true;
        }
    }
}
