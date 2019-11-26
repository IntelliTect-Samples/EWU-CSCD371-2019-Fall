using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        private const string csvRowSpongebob = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
        private const string csvRowMrKrabs = "2,Eugene,Krabs,moneymoneymoney@gmail.com,765 Calico Drive,Spokane,WA,99201";

        [TestMethod]
        public void Constructor_csvRowSpongebob_CorrectFirstName()
        {
            //Arrange
            //Act
            Person spongebob = new Person(csvRowSpongebob);
            //Assert
            Assert.AreEqual<string>("Spongebob", spongebob.FirstName);
        }

        [TestMethod]
        public void Constructor_csvRowSpongebob_CorrectLastName()
        {
            //Arrange
            //Act
            Person spongebob = new Person(csvRowSpongebob);
            //Assert
            Assert.AreEqual<string>("Squarepants", spongebob.LastName);
        }

        [TestMethod]
        public void Constructor_csvRowSpongebob_CorrectAddressEmailAddress()
        {
            //Arrange
            //Act
            Person spongebob = new Person(csvRowSpongebob);
            //Assert
            Assert.AreEqual<string>("jellyfishgod@gmail.com", spongebob.EmailAddress);
        }

        [TestMethod]
        public void Constructor_csvRowSpongebob_CorrectAddress()
        {
            //Arrange
            Address expected = new Address("1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202");
            //Act
            Person spongebob = new Person(csvRowSpongebob);
            //Assert
            Assert.AreEqual<IAddress>(expected, spongebob.Address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullCsvRowSpongebob_ThrowsException()
        {
            //Arrange
            //Act
            _ = new Person(null!);
            //Assert
        }

        [TestMethod]
        public void Equals_DifferentPerson_ReturnsFalse()
        {
            //Arrange
            Person spongebob = new Person(csvRowSpongebob);
            Person mrKrabs = new Person(csvRowMrKrabs);
            //Act
            bool peopleAreEqual = spongebob.Equals(mrKrabs);
            //Assert
            Assert.IsFalse(peopleAreEqual);
        }

        [TestMethod]
        public void Equals_SamePerson_ReturnsTrue()
        {
            //Arrange
            Person spongebob = new Person(csvRowSpongebob);
            Person spingebobTwo = new Person(csvRowSpongebob);
            //Act
            bool peopleAreEqual = spongebob.Equals(spingebobTwo);
            //Assert
            Assert.IsTrue(peopleAreEqual);
        }

        [TestMethod]
        public void GetHashCode_DifferentPerson_ReturnsDifferentHashCodes()
        {
            //Arrange
            Person spongebob = new Person(csvRowSpongebob);
            Person mrKrabs = new Person(csvRowMrKrabs);
            //Act
            bool HashCodesAreSame = spongebob.GetHashCode() == mrKrabs.GetHashCode();
            //Assert
            Assert.IsFalse(HashCodesAreSame);
        }

        [TestMethod]
        public void GetHashCode_SamePerson_ReturnsSameHashCodes()
        {
            //Arrange
            Person spongebob = new Person(csvRowSpongebob);
            Person spongebobTwo = new Person(csvRowSpongebob);
            //Act
            bool HashCodesAreSame = spongebob.GetHashCode() == spongebobTwo.GetHashCode();
            //Assert
            Assert.IsTrue(HashCodesAreSame);
        }
    }
}