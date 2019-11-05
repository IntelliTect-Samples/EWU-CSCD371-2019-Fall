using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        private readonly Stream Stream;

        public DataLoader(Stream source)
        {
            if (source is null)
                throw new ArgumentNullException($"{nameof(source)} was found to be null.");

            Stream = source;
        }

        public List<Mailbox> Load()
        {
            Stream.Position = 0;
            List<Mailbox> mailboxes = new List<Mailbox>();

            try
            {
                using (StreamReader sr = new StreamReader(Stream, leaveOpen: true))
                {
                    string? currLine;
                    while ((currLine = sr.ReadLine()) != null)
                    {
                        mailboxes.Add(JsonConvert.DeserializeObject<Mailbox>(currLine));
                    }
                }

                return mailboxes;
            }

            catch(JsonReaderException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            if (mailboxes is null || mailboxes.Count == 0)
                return;

            Stream.Position = 0;
            using StreamWriter sw = new StreamWriter(Stream, leaveOpen: true);
            foreach (Mailbox mail in mailboxes)
                sw.WriteLine(JsonConvert.SerializeObject(mail));
        }

        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}
