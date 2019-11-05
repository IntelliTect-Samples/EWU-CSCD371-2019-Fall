using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{

    [TestClass]
    public class MailboxTests
    {

        [DataTestMethod]
        [DataRow("John", "Price", Size.Default, 0, 0, "")]
        [DataRow("Simon", "Riley", Size.Medium, 1, 2, " | Medium")]
        [DataRow("Kyle", "Garrick", Size.MediumPremium, 3, 4, " | Medium Premium")]
        public void ToString_PrintsCorrectly(string firstName,
                                             string lastName,
                                             Size   size,
                                             int    x,
                                             int    y,
                                             string friendlySize)
        {
            var owner = new Person(firstName, lastName);
            var box   = new Mailbox(owner, size, (x, y));

            Assert.AreEqual($"{(x, y)} | {owner}{friendlySize}", box.ToString());
        }

        /*
         * A test like this seems pretty hard to write, especially since I couldn't find a way to
         * assign 'null' to a tuple variable through the DataRow, even though it's possible
         * with (int x, int y)? as the parameter type in a normal method call...
         *
         * Is there a better way to do this?
         */
        [DataTestMethod]
        [DataRow(null, Size.Default)]
        [DataRow("FirstName", null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_GivenNullValues_ThrowsException(string? firstName, Size? size)
        {
            Person person;
            try
            {
                person = new Person(firstName, "LastName");
            } finally
            {
                var unused = new Mailbox(person, size, (0, 0));
            }
        }

    }

}
