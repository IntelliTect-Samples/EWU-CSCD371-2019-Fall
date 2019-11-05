using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void toString_Success()
        {
            List<Mailbox> mailboxes = getTestMail();

            foreach (Mailbox mail in mailboxes)
            {
                string sizeStr = mail.Size.ToString();

                if (sizeStr.Contains("Premium"))
                    sizeStr.Replace("Premium", " Premium");

                else if (sizeStr.Equals("Default"))
                    sizeStr = "";

                Assert.AreEqual($"Owner: {mail.Owner.ToString()}, Mailbox Size: {sizeStr}, Location: {mail.Location.X}, {mail.Location.Y}", mail.ToString());
            }
        }

        private List<Mailbox> getTestMail()
        {
            List<Mailbox> mailboxes = new List<Mailbox>()
            {
                new Mailbox() { Owner = new Person() { FirstName = "Bob", LastName = "Jones"}, Location = (1, 1), Size = Sizes.Small },
                new Mailbox() { Owner = new Person() { FirstName = "Steven", LastName = "Bills"}, Location = (1, 2), Size = Sizes.Medium },
                new Mailbox() { Owner = new Person() { FirstName = "John", LastName = "Doe"}, Location = (1, 3), Size = Sizes.LargePremium }
            };

            return mailboxes;
        }
    }
}
