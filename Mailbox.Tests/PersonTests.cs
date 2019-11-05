using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_Equals_ReturnTrue()
        {
            Person personA = new Person("Hubbard", "Taty");
            Person personB = new Person("Hubbard", "Taty");

            Assert.IsTrue(personA.Equals(personB));
        }

        [TestMethod]
        [DataRow("abc","def")]
        [DataRow("Taty","Hubbard")]
        [DataRow("Inigo", "Montoya")]
        public void Person_ToString(string first, string last)
        {
            Assert.AreEqual($"{first} {last}", new Person(last,first).ToString());
        }

    }
}
