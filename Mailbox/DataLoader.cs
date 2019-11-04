using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader
    {
        Stream stream;
        public DataLoader(Stream source)
        {
            stream = source;
        }

        public List<Mailbox> Load()
        {
        }

        public void Save(List<Mailbox> mailboxes)
        {
            
        }
    }
}
