﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        [DataRow("Doug", "Student", Size.Premium | Size.Large, 12, 4)]
        [DataRow("James", "Hamish", Size.Small, 4, 16)]
        [DataRow("John", "Hodgins", Size.Default, 2, 24)]
        public void Mailbox_ToString_Returns_PropertyMembers(string firstName, string lastName, Size mailBoxSize, int x, int y)
        {
            Person p = new Person() { FirstName = firstName, LastName = lastName };
            Mailbox mailbox = new Mailbox() { Owner = p, Size = mailBoxSize, Location = (x, y) };

            string size;
            switch (mailBoxSize)
            {
                case Size.Premium:
                    size = "Premium";
                    break;
                case Size.SmallPremium:
                    size = "Small Premium";
                    break;
                case Size.MediumPremium:
                    size = "Medium Premium";
                    break;
                case Size.LargePremium:
                    size = "Large Premium";
                    break;
                default:
                    size = mailBoxSize.ToString();
                    break;
            }

            Assert.AreEqual($"Owner: {firstName} {lastName} Location: ({x}, {y}) Size: {(mailBoxSize == Size.Default ? "" : size)}", mailbox.ToString());
        }
    }
}
