using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void PennySpeaks()
        {
            // Arrange
            var pennyTest = new Penny();

            // Act
            string phrase = "My name is Penny!";

            // Assert
            Assert.AreEqual(phrase, pennyTest.Phrase());
        }

        [TestMethod]
        public void SheldonSpeaks()
        {
            // Arrange
            var sheldonTest = new Sheldon();

            // Act
            string phrase = "My name is Sheldon!";

            // Assert
            Assert.AreEqual(phrase, sheldonTest.Phrase());
        }

        [TestMethod]
        public void RajSpeaks_WomenArePresent_False()
        {
            // Arrange
            var rajTest = new Raj();

            // Act
            string phrase = "My name is Raj!";

            // Assert
            Assert.AreEqual(phrase, rajTest.Phrase());
        }

        [TestMethod]
        public void RajSpeaks_WomenArePresent_True()
        {
            // Arrange
            var rajTest = new Raj();

            // Act
            string phrase = "mmhmhmhhmmhmhmmhmhm";

            // Assert
            Assert.AreEqual(phrase, rajTest.Mumble());
        }
    }
}
