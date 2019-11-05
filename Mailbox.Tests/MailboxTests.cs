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
        [DataRow(Size.Small, 0)]
        [DataRow(Size.Medium, 1)]
        [DataRow(Size.Large, 2)]
        public void CreateNewMailbox_SizeNonPremium_ToString(Size s, int loc)
        {
            Person p = new Person("Tony", "Fatt");
            Mailbox m = new Mailbox(s, 0, 0, p);

            string mString = m.ToString();
            string[] expectedStrings = 
            { 
                "size: Small location: (0, 0) owner: Tony Fatt",
                "size: Medium location: (0, 0) owner: Tony Fatt",
                "size: Large location: (0, 0) owner: Tony Fatt"
            };

            string expectedString = expectedStrings[loc];
            Assert.AreEqual(expectedString, mString);
        }

        [TestMethod]
        [DataRow(Size.Small, 0)]
        [DataRow(Size.Medium, 1)]
        [DataRow(Size.Large, 2)]
        public void CreateNewMailbox_SizePremium_ToString(Size s, int loc)
        {
            Person p = new Person("Tony", "Fatt");
            Size size = Size.Premium | s;
            Mailbox m = new Mailbox(size, 0, 0, p);

            string mString = m.ToString();
            string[] expectedStrings =
            {
                "size: Premium Small location: (0, 0) owner: Tony Fatt",
                "size: Premium Medium location: (0, 0) owner: Tony Fatt",
                "size: Premium Large location: (0, 0) owner: Tony Fatt"
            };
            string expectedString = expectedStrings[loc];

            Assert.AreEqual(expectedString, mString);
        }
    }
}
