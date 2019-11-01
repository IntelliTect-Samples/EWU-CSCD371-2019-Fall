using Newtonsoft.Json;
using System;
using System.IO;

namespace Mailbox {
    public class DataLoader {
        private String _FileName;
        public DataLoader(String fileName) {
            _FileName = fileName;
        }

        public Mailbox[,] Load() {
            Mailbox[,] result;
            if (!File.Exists(_FileName)) {
                return null;
            }
            using (StreamReader sr = new StreamReader(_FileName)) {
                try {
                    string temp = sr.ReadLine();
                    Console.WriteLine(temp);
                    result = JsonConvert.DeserializeObject<Mailbox[,]>(temp);
                } catch (JsonReaderException) {
                    return null;
                }
            }
            return result;
        }

        public void Save(Mailbox[,] mailboxes) {
            using (StreamWriter sw = new StreamWriter(_FileName)) {
                sw.WriteLine(JsonConvert.SerializeObject(mailboxes));
            }
        }
    }
}
