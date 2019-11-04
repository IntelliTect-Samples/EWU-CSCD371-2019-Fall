using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GetOwnersDisplay_OneMailBox_ReturnsCorrectPerson()
        {
            //Arrange
            List<Mailbox> mailboxList = new List<Mailbox>();
            Mailbox homersMailbox = new Mailbox(Size.Small, (0, 0), new Person("Homer", "Simpson"));
            mailboxList.Add(homersMailbox);
            Mailboxes mailboxes = new Mailboxes(mailboxList, 1, 1);
             
            //Act
            
            //Assert
        }
    }
}