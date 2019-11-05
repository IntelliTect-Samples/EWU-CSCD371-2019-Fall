using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Constructor_ValidParams_ValuesMatch()
        {
            var person = new Person();
            var size = Sizes.Small;
            var location = (0, 0);

            var sut = new Mailbox(location, person, size);

            Assert.AreEqual(sut.Owner, person);
            Assert.AreEqual(sut.Size, size);
            Assert.AreEqual(sut.Location, location);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_InvalidSize_ThrowsException()
        {
            new Mailbox((0, 0), new Person(), Sizes.Undefined);
        }

        [TestMethod]
        public void ToString_LargePremium_CorrectRepresentation()
        {
            Assert.AreEqual(new Mailbox((0, 0), new Person("Inigo", "Montoya"), Sizes.Large | Sizes.Premium).ToString(),
                "Inigo Montoya's Premium Large mailbox at (0, 0)");
        }

        [TestMethod]
        public void ToString_SmallRegular_CorrectRepresentation()
        {
            Assert.AreEqual(new Mailbox((0, 0), new Person("Inigo", "Montoya"), Sizes.Small).ToString(),
                "Inigo Montoya's Small mailbox at (0, 0)");
        }
    }
}
