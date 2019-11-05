using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void ToString_NotPremium_IsCorrect()
        {
            //Arrange
            Mailbox mBox = new Mailbox(Size.Medium, (0, 0), new Person("Josh", "Lini"));

            //Act
            string mBoxOut = mBox.ToString();

            //Assert
            Assert.AreEqual(mBoxOut, "Mailbox: Location: (0,0) - Owner: Lini, Josh - Size: Medium");
        }

        [TestMethod]
        public void ToString_Premium_IsCorrect()
        {
            //Arrange
            Mailbox mBox = new Mailbox(Size.Medium | Size.Premium, (0, 0), new Person("Josh", "Lini"));

            //Act
            string mBoxOut = mBox.ToString();

            //Assert
            Assert.AreEqual(mBoxOut, "Mailbox: Location: (0,0) - Owner: Lini, Josh - Size: Medium Premium");
        }
    }
}
