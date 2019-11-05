using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
       [DataTestMethod]
       [DataRow(Size.Small)]
       [DataRow(Size.Medium)]
       [DataRow(Size.Large)]
       [DataRow(Size.SmallPremium)]
       [DataRow(Size.MediumPremium)]
       [DataRow(Size.LargePremium)]
        public void Mailbox_ToString_ReturnsCorrectlyFormattedString(Size size)
        {
            // Arrange
            Person testPerson = new Person("First", "Last");
            Mailbox sut = new Mailbox(size, (1, 1), testPerson);

            // Act

            // Assert
            Assert.AreEqual(sut.ToString(), $"Size: {size} Location: (1, 1) Owner: First Last");
        }

        [DataTestMethod]
        [DataRow(Size.Default)]
        public void Mailbox_ToString_EmptySizeString(Size size)
        {
            // Arrange
            Person testPerson = new Person("First", "Last");
            Mailbox sut = new Mailbox(size, (1, 1), testPerson);

            // Act

            // Assert
            Assert.AreEqual(sut.ToString(), $"Size:  Location: (1, 1) Owner: First Last");
        }
    }
}
