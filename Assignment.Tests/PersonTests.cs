using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_Constructor_Qapla()
        {
            IPerson person = new Person("Jimmy", "John", "12345 6th ave.", "Cheney", "WA", "99004", "jimmyjohn@yahoo.com");
            Assert.AreEqual(person.FirstName, "Jimmy");
            Assert.AreEqual(person.LastName, "John");
            Assert.AreEqual(person.StreetAddress, "12345 6th ave.");
            Assert.AreEqual(person.City, "Cheney");
            Assert.AreEqual(person.State, "WA");
            Assert.AreEqual(person.Zip, "99004");
            Assert.AreEqual(person.Email, "jimmyjohn@yahoo.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Person_Constructor_Fail()
        {
            IPerson person = new Person(null!, null!, null!, null!, null!, null!, null!);
        }
    }
}
