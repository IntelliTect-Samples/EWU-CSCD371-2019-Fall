using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void Mailbox_ToString_EmptyStringOnSmallBox()
        {
            var person = new Person("Kevin", "Durant");
            var location = (X: 1, Y: 1);
            var sut = new Mailbox(Size.Small, (1, 1), person);
            Assert.AreEqual(
                    sut.ToString(),
                    $"Size: Location: X: {location.X} Y: {location.Y} Owner: {person.ToString()}");
        }
    }
}
