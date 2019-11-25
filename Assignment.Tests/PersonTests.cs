using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Constructor_CsvRow_CorrectFirstName()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Person spongebob = new Person(csvRow);
            //Assert
            Assert.AreEqual<string>("Spongebob", spongebob.FirstName);
        }

        [TestMethod]
        public void Constructor_CsvRow_CorrectLastName()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Person spongebob = new Person(csvRow);
            //Assert
            Assert.AreEqual<string>("Squarepants", spongebob.LastName);
        }

        [TestMethod]
        public void Constructor_CsvRow_CorrectAddressEmailAddress()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Person spongebob = new Person(csvRow);
            //Assert
            Assert.AreEqual<string>("jellyfishgod@gmail.com", spongebob.EmailAddress);
        }

        [TestMethod]
        public void Constructor_CsvRow_CorrectAddress()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            Address expected = new Address("1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202");
            //Act
            Person spongebob = new Person(csvRow);
            //Assert
            Assert.AreEqual<IAddress>(expected, spongebob.Address);
        }

        [TestMethod]
        public void Equals_DifferentPerson_ReturnsFalse()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            string csvRowTwo = "2,Eugene,Krabs,moneymoneymoney@gmail.com,765 Calico Drive,Spokane,WA,99201";
            Person spongebob = new Person(csvRow);
            Person mrKrabs = new Person(csvRowTwo);
            //Act
            bool peopleAreEqual = spongebob.Equals(mrKrabs);
            //Assert
            Assert.IsFalse(peopleAreEqual);
        }

        [TestMethod]
        public void Equals_SamePerson_ReturnsTrue()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            Person spongebob = new Person(csvRow);
            Person spingebobTwo = new Person(csvRow);
            //Act
            bool peopleAreEqual = spongebob.Equals(spingebobTwo);
            //Assert
            Assert.IsTrue(peopleAreEqual);
        }

        [TestMethod]
        public void GetHashCode_DifferentPerson_ReturnsDifferentHashCodes()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            string csvRowTwo = "2,Eugene,Krabs,moneymoneymoney@gmail.com,765 Calico Drive,Spokane,WA,99201";
            Person spongebob = new Person(csvRow);
            Person mrKrabs = new Person(csvRowTwo);
            //Act
            bool HashCodesAreSame = spongebob.GetHashCode() == mrKrabs.GetHashCode();
            //Assert
            Assert.IsFalse(HashCodesAreSame);
        }

        [TestMethod]
        public void GetHashCode_SamePerson_ReturnsSameHashCodes()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            Person spongebob = new Person(csvRow);
            Person spongebobTwo = new Person(csvRow);
            //Act
            bool HashCodesAreSame = spongebob.GetHashCode() == spongebobTwo.GetHashCode();
            //Assert
            Assert.IsTrue(HashCodesAreSame);
        }
    }
}