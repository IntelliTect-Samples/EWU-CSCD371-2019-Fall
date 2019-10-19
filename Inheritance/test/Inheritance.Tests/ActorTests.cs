using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void UnknownActorSpeak()
        {
            var actor = new Actor();

            Assert.AreEqual("Who am I?", actor.Speak());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullActorSpeak()
        {
            ActorExtension.Speak(null);
        }

        [TestMethod]
        public void PennySpeak()
        {
            var actor = new Penny();

            Assert.AreEqual("My name is Penny", actor.Speak());
        }

        [TestMethod]
        public void SheldonSpeak()
        {
            var actor = new Sheldon();

            Assert.AreEqual("My name is Sheldon", actor.Speak());
        }

        [TestMethod]
        public void RajSpeak_WomenArePresent()
        {
            var actor = new Raj { WomenArePresent = true };

            Assert.AreEqual("*mumble*", actor.Speak());
        }

        [TestMethod]
        public void RajSpeak_WomenAreNotPresent()
        {
            var actor = new Raj { WomenArePresent = false };

            Assert.AreEqual("My name is Raj", actor.Speak());
        }
    }
}
