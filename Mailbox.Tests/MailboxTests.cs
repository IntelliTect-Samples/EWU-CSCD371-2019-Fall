using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailRoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailRoom.Tests
{
    [TestClass]
    public class MailboxTests
    {
        // just ensuring print works here, component tostrings are already tested in respective test classes
        [TestMethod]
        public void ToString_MailboxStringRepresentation_ReturnsConcatenatedStringsOfProperties()
        {
            Person testOwner = new Person("First", "Last");
            (int, int) testLocation = (1, 2);
            Sizes testSize = Sizes.Medium | Sizes.Premium;

            string expected = $"Name: {testOwner}; Location: {testLocation}; Mailbox Size: {testSize.GetString()}";

            Mailbox test = new Mailbox(testOwner, testLocation, testSize);

            string result = test.ToString();

            Assert.AreEqual<string>(expected, result);
        }

        [DataTestMethod]
        [DataRow(Sizes.None)]
        [DataRow(Sizes.Premium)]
        [DataRow(Sizes.Small|Sizes.Medium)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_InvalidSize_Throws(Sizes test)
        {
            _ = new Mailbox(new Person("", ""), default, test);
        }
    }
}
