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
    }
}