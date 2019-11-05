using System.Collections.Generic;
using System.IO;
using System;

using Newtonsoft.Json;

namespace Mailbox
{
    /*
     * This class will be responsible for saving and loading our mailbox data.
     *
     * I should take in a System.IO.Stream in its constructor. Though the
     * stream being used here will point to a file, this is a generic 
     * way to save to a variety of sources.
     *
     * To read/write to the stream you will want to look at the System.IO.StreamReader
     * and System.IO.StreamWriter classes. In particular you will want to look
     * through the overloaded constructors to make sure that these classes do not close 
     * your stream.
     *
     * Before reading/writing to the Stream you will need to reset the stream pointer to 
     * the beginning. Stream.Position or Stream.Seek will be helpful here.
     * The StreamReader and StreamWriter should be properly disposed of inside of 
     * the Load/Save methods.
     *
     * The data should be stored as json. A popular library for working with json 
     * is Newtonsoft.Json. You will want to look at the static methods on the 
     * JsonConvert class for converting objects to and from strings of json data.
     *
     * The DataLoader should properly implement the IDispoable interface. It should 
     * clean up the Stream that was passed in.
     *
     * The DataLoader should handle the JsonReaderException. This exception will 
     * be throw if the stream contents are not valid json. Such as "abc". 
     * If this is thrown the method should gracefully return null.
     *
     */
    public class DataLoader : IDisposable
    {
        private Stream? Source;
        
        public void Dispose()
        {
            if (!(Source is null))
            {
                Source.Dispose();
            }
        }

        public DataLoader(Stream source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            Source = source;
        }

        public List<Mailbox>? Load()
        {
            if (Source is null)
                throw new InvalidOperationException($"{nameof(Source)} must be initialized to load data.");
            List<Mailbox> mailboxes = new List<Mailbox>();
            Source.Position = 0;

            using var sr = new StreamReader(Source);

            try
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    Mailbox mailbox = JsonConvert.DeserializeObject<Mailbox>(line);
                    mailboxes.Add(mailbox);
                }
                return mailboxes;
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        public void Save(List<Mailbox> mailboxes)
        {
            using var sw = new StreamWriter(Source);

            foreach (var mailbox in mailboxes)
            {
                sw.WriteLine(JsonConvert.SerializeObject(mailbox));
            }
        }

        ~DataLoader() => Dispose();
    }
}
