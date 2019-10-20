using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullValuePassedToSpeak_ExceptionExpected()
        {
            ExtensionClass.Speak(null);
        }

        [TestMethod]
        public void PennySpeakTest_()
        {
            //Arrange
            Penny penny = new Penny();

            //Act
            string speech = ExtensionClass.Speak(penny);

            //Assert
            Assert.AreEqual(speech, "My Name is Penny");
        }
        [TestMethod]
        public void SheldonSpeakTest_()
        {
            //Arrange
            Sheldon sheldon = new Sheldon();

            //Act
            string speech = ExtensionClass.Speak(sheldon);

            //Assert
            Assert.AreEqual(speech, "Bazinga!");
        }

        [TestMethod]
        public void RajSpeakTest_WomanArePresentIsFalse()
        {
            //Arrange
            Raj raj = new Raj
            {
                WomenArePresent = false
            };

            //Act
            string speech = ExtensionClass.Speak(raj);

            //Assert
            Assert.AreEqual(speech, "My name is Raj");
        }

        [TestMethod]
        public void RajSpeakTest_WomanArePresentIsTrue()
        {
            //Arrange
            Raj raj = new Raj
            {
                WomenArePresent = true
            };

            //Act
            string speech = ExtensionClass.Speak(raj);

            //Assert
            Assert.AreEqual(speech, "Mumble mumble");
        }
    }
}
