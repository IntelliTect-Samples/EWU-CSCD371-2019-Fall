/*
#### DataLoader
This class will be responsible for saving and loading our mailbox data.
- I should take in a System.IO.Stream in its constructor. Though the stream being used here will point to a file, this is a generic way to save to a variety of sources.
- To read/write to the stream you will want to look at the `System.IO.StreamReader` and `System.IO.StreamWriter` classes.
    In particular you will want to look through the overloaded constructors to make sure that these classes do **not** close your stream.
- Before reading/writing to the `Stream` you will need to reset the stream pointer to the beginning. `Stream.Position` or `Stream.Seek` will be helpful here.
- The `StreamReader` and `StreamWriter` should be properly disposed of inside of the Load/Save methods.
- The data should be stored as [json](https://en.wikipedia.org/wiki/JSON). A popular library for working with json is
    [Newtonsoft.Json](https://www.newtonsoft.com/json). You will want to look at the static methods on the `JsonConvert` class
    for converting objects to and from strings of json data.
- The `DataLoader` should[properly implement](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#dispose-and-disposeboolean)
    the `IDispoable` interface. It should clean up the `Stream` that was passed in.
- The `DataLoader` should handle the `JsonReaderException`. This exception will be throw if the stream contents are not valid json. Such as "abc".
    If this is thrown the method should gracefully return `null`.
*/
using System;
using System.Collections.Generic;
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


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<Mailbox>? Load()
        {
            List<Mailbox> mailboxes = new List<Mailbox>();
            _source.Position = 0;

            using (StreamReader sr = new StreamReader(_source, leaveOpen: true))
            {
                try
                {
                    string? jsonLine;
                    while ((jsonLine = sr.ReadLine()) != null)
                    {
                        Mailbox mailbox = JsonConvert.DeserializeObject<Mailbox>(jsonLine);
                        mailboxes.Add(mailbox);
                    }
                    sr.Dispose();
                }
                catch (JsonReaderException)
                {
                    return null;
                }
            }
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            _source.Position = 0;

            string json = JsonConvert.SerializeObject(mailboxes);

            using (StreamWriter sw = new StreamWriter(_source, leaveOpen: true))
            {
                sw.WriteLine(json);
                sw.Dispose();
            }
        }

        private IDisposable? DisposableMember { get; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposableMember?.Dispose();
                }
                disposedValue = true;
            }
        }

        #endregion

    }
}
