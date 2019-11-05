using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [DataTestMethod]
        [DataRow("name", null)]
        [DataRow(null, "name")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Person_Constructor_NullInputs(string firstname, string lastname)
        {
            Person person = new Person(firstname, lastname);
        }

        [TestMethod]
        public void Person_Constructor_Qapla()
        {
            Person person1 = new Person("Itsame", "Mario");
            Assert.AreEqual("Itsame", person1.FirstName);
            Assert.AreEqual("Mario", person1.LastName);
        }

        [TestMethod]
        public void Person_Equals()
        {
            Person person1 = new Person("Ima", "Clone");
            Person person2 = new Person("Ima", "Clone");
            Assert.AreEqual(person1, person2);
        }

        [TestMethod]
        public void Person_toString()
        {
            Person person1 = new Person("Jimmy", "John");
            Assert.AreEqual("John, Jimmy", person1.ToString());
        }


    }
}
