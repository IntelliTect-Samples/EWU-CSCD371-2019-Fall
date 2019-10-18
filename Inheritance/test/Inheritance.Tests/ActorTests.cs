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
            Assert.AreEqual("This is something Penny would say", result);
        }

        [TestMethod]
        public void SheldonSpeak()
        {
            //Arrange
            //Act
            Sheldon sheldon = new Sheldon();
            string result = sheldon.Speak();

            //Assert
            Assert.AreEqual("This is something Sheldon would say", result);
        }

        [TestMethod]
        public void RajSpeak_NoWomen()
        {
            //Arrange
            //Act
            Raj raj = new Raj();
            string result = raj.SpeakWithoutWomenPresent();

            //Assert
            Assert.AreEqual("This is something Raj would say WITHOUT women present", result);
        }

        [TestMethod]
        public void RajSpeak_Women()
        {
            //Arrange
            //Act
            Raj raj = new Raj();
            string result = raj.SpeakWithWomenPresent();

            //Assert
            Assert.AreEqual("This is something Raj would say with women present", result);
        }
    }
}
