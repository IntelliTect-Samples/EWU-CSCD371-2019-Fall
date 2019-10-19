using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void PennySpeak()
        {
            //Arrange
            //Act
            Penny penny = new Penny();
            string result = penny.Speak();

            //Assert
            Assert.AreEqual("Penny: \"I love him, but if he's broken, let's not get a new one.\"", result);
        }

        [TestMethod]
        public void SheldonSpeak()
        {
            //Arrange
            //Act
            Sheldon sheldon = new Sheldon();
            string result = sheldon.Speak();

            //Assert
            Assert.AreEqual("Sheldon: \"Bazinga!\"", result);
        }

        [TestMethod]
        public void RajSpeak_NoWomen()
        {
            //Arrange
            //Act
            Raj raj = new Raj();
            string result = raj.SpeakWithoutWomenPresent();

            //Assert
            Assert.AreEqual("Raj: \"I've said it before and I'll say it again, Aquaman sucks!\"", result);
        }

        [TestMethod]
        public void RajSpeak_Women()
        {
            //Arrange
            //Act
            Raj raj = new Raj();
            string result = raj.SpeakWithWomenPresent();

            //Assert
            Assert.AreEqual("Raj: \"*mumbles*\"", result);
        }
    }
}
