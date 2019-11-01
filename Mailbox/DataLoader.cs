using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox {
    public class DataLoader {
        private Stream _Stream;
        public DataLoader(Stream source) {
            _Stream = source ?? throw new ArgumentNullException("DataLoader Stream cannot be null");
        }

        public List<Mailbox> Load() {
            List<Mailbox> result = new List<Mailbox>();
            _Stream.Position = 0;
            StreamReader sr = new StreamReader(_Stream);
            while (!sr.EndOfStream) {
                result.Add(JsonConvert.DeserializeObject<Mailbox>(sr.ReadLine()));
            }
            return result;
        }

        public void Save(Mailbox[,] mailboxes) {
            _Stream.Position = 0;
            StreamWriter sw = new StreamWriter(_Stream);
            sw.WriteLine(JsonConvert.SerializeObject(mailboxes));
        }
    }
}
