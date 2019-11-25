using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void CreatePersonGoodData()
        {
            //Arrange
            string first = "Jacob";
            string last = "Berger";
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string email = "jberger8@eagles.ewu.edu";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
            Assert.IsNotNull(person);
            Assert.AreEqual(person.FirstName, first);
            Assert.AreEqual(person.LastName, last);
            Assert.AreEqual(person.Address, address);
            Assert.AreEqual(person.Email, email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonNullFirstNameThrowsException()
        {
            //Arrange
            string ?first = null;
            string last = "Berger";
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string email = "jberger8@eagles.ewu.edu";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonNullLastNameThrowsException()
        {
            //Arrange
            string first = "Jacob";
            string ?last = null;
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string email = "jberger8@eagles.ewu.edu";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonNullAddressThrowsException()
        {
            //Arrange
            string first = "Jacob";
            string last = "Berger";
            IAddress ?address = null;
            string email = "jberger8@eagles.ewu.edu";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonNullEmailThrowsException()
        {
            //Arrange
            string first = "Kacob";
            string last = "Berger";
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string ?email = null;

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonEmptyFirstNameThrowsException()
        {
            //Arrange
            string first = "";
            string last = "Berger";
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string email = "jberger8@eagles.ewu.edu";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonEmptyLastNameThrowsException()
        {
            //Arrange
            string first = "Jacob";
            string last = "";
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string email = "jberger8@eagles.ewu.edu";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePersonEmptyEmailThrowsException()
        {
            //Arrange
            string first = "Jacob";
            string last = "Berger";
            IAddress address = new Address("1212 S. New Street", "Spokane", "WA", "99223");
            string email = "";

            //Act
            Person person = new Person(first, last, address, email);

            //Assert
        }
    }
}