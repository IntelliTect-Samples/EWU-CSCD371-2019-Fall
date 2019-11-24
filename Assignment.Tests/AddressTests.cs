using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Constructor_CsvRow_CorrectStreetAddress()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Address spongebobsAddress = new Address(csvRow);
            //Assert
            Assert.AreEqual("1391 Mudlick Road", spongebobsAddress.StreetAddress);
        }

        [TestMethod]
        public void Constructor_CsvRow_CorrectCity()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Address spongebobsAddress = new Address(csvRow);
            //Assert
            Assert.AreEqual("Spokane", spongebobsAddress.City);
        }

        [TestMethod]
        public void Constructor_CsvRow_CorrectState()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Address spongebobsAddress = new Address(csvRow);
            //Assert
            Assert.AreEqual("WA", spongebobsAddress.State);
        }

        [TestMethod]
        public void Constructor_CsvRow_CorrectZip()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            //Act
            Address spongebobsAddress = new Address(csvRow);
            //Assert
            Assert.AreEqual("99202", spongebobsAddress.Zip);
        }

        [TestMethod]
        public void Equals_SameAddresses_ReturnsTrue()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            Address spongebobsAddress = new Address(csvRow);
            Address spongebobsAddressTwo = new Address(csvRow);
            //Act
            bool addressesAreEqual = spongebobsAddress.Equals(spongebobsAddressTwo);
            //Assert
            Assert.IsTrue(addressesAreEqual);
        }

        [TestMethod]
        public void Equals_DifferentAddresses_ReturnsFalse()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            string csvRowTwo = "2,Eugene,Krabs,moneymoneymoney@gmail.com,765 Calico Drive,Spokane,WA,99201";
            Address spongebobsAddress = new Address(csvRow);
            Address mrKrabsAddress = new Address(csvRowTwo);
            //Act
            bool addressesAreEqual = spongebobsAddress.Equals(mrKrabsAddress);
            //Assert
            Assert.IsFalse(addressesAreEqual);
        }

        [TestMethod]
        public void GetHashCode_SameAddresses_ReturnsSameHashcode()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            Address spongebobsAddress = new Address(csvRow);
            Address spongebobsAddressTwo = new Address(csvRow);
            //Act
            bool hashCodesAreSame = spongebobsAddress.GetHashCode() == spongebobsAddressTwo.GetHashCode();
            //Assert
            Assert.IsTrue(hashCodesAreSame);
        }

        [TestMethod]
        public void GetHashCode_DifferentAddresses_ReturnsDifferentHashcode()
        {
            //Arrange
            string csvRow = "1,Spongebob,Squarepants,jellyfishgod@gmail.com,1391 Mudlick Road,Spokane,WA,99202";
            string csvRowTwo = "2,Eugene,Krabs,moneymoneymoney@gmail.com,765 Calico Drive,Spokane,WA,99201";
            Address spongebobsAddress = new Address(csvRow);
            Address mrKrabsAddress = new Address(csvRowTwo);
            //Act
            bool hashCodesAreSame = spongebobsAddress.GetHashCode() == mrKrabsAddress.GetHashCode();
            //Assert
            Assert.IsFalse(hashCodesAreSame);
        }
    }
}