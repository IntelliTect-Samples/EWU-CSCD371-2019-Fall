using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Speak_NullActor_ThrowsNullArgument()
        {
            // Arrange

            // Act
            ActorExtension.Speak(null, "test");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Speak_UnsupportedActor_ThrowsNotSupported()
        {
            // Arrange

            // Act
            ActorExtension.Speak(new Actor(), "test");

            // Assert
        }

        [TestMethod]
        public void Speak_ActorIsSheldon_InputMatchesOutput()
        {
            // Arrange
            Sheldon sheldon = new Sheldon();
            string phrase = "test phrase";

            // Act

            // Assert
            Assert.AreEqual(phrase, sheldon.Speak(phrase));
        }

        [TestMethod]
        public void Speak_ActorIsPenny_InputMatchesOutput()
        {
            // Arrange
            Penny penny = new Penny();
            string phrase = "test phrase";

            // Act

            // Assert
            Assert.AreEqual(phrase, penny.Speak(phrase));
        }

        [TestMethod]
        public void Speak_ActorIsRaj_NoWomenPresent_InputMatchesOutput()
        {
            // Arrange
            Raj raj = new Raj() { WomenArePresent = false };
            string phrase = "test phrase";

            // Act

            // Assert
            Assert.AreEqual(phrase, raj.Speak(phrase));
        }

        [TestMethod]
        public void Speak_ActorIsRaj_WomenArePresent_OutputsMumble()
        {
            // Arrange
            Raj raj = new Raj() { WomenArePresent = true };

            // Act

            // Assert
            Assert.AreEqual("*mumbles something*", raj.Speak("test phrase"));
        }
    }
}