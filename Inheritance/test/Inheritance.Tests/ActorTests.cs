using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCanNotSpeak_ExpectedException()
        {
            //Arrange
            Sheldon sheldon = null;

            //Act
            string verify = sheldon.Speak();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ActorCanNotSpeak_ExpectedException()
        {
            //Arrange
            Actor actor = new Actor();

            //Act
            string verify = actor.Speak();
        }


        [TestMethod]
        public void SheldonCanSpeak()
        {
            //Arrange
            Sheldon sheldon = new Sheldon();

            //Act
            string verify = sheldon.Speak();

            //Assert
            Assert.AreEqual("Sheldon says something too smart to understand", verify);
        }


        [TestMethod]
        public void PennyCanSpeak()
        {
            //Arrange
            Penny penny = new Penny();

            //Act
            string verify = penny.Speak();

            //Assert
            Assert.AreEqual("Penny can talk", verify);
        }

        [TestMethod]
        public void RajCanSpeak()
        {
            //Arrange
            Raj raj = new Raj { WomenArePresent = false };
            //Act
            string verify = raj.Speak();

            //Assert
            Assert.AreEqual("No women are present, so Raj is able to speak.", verify);
        }

        [TestMethod]
        public void RajCanNotSpeak()
        {
            //Arrange
            Raj raj = new Raj { WomenArePresent = true };
            //Act
            string verify = raj.Speak();

            //Assert
            Assert.AreEqual("Women are present so Raj is just mumbling", verify);
        }
    }
}
