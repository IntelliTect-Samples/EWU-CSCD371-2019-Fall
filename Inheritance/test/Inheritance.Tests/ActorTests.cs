using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void SheldonSpeak() 
        { 
            Sheldon testActor = new Sheldon { Script = "Bazinga" };

            string sheldonScript = testActor.Speak();

            Assert.AreEqual("Sheldon: Bazinga", sheldonScript);
        }

        [TestMethod]
        public void PennySpeak()
        {
            Penny testActor = new Penny { Script = "I'm Penny" };

            string pennyScript = testActor.Speak();

            Assert.AreEqual("Penny: I'm Penny", pennyScript);
        }

        [TestMethod]
        public void RajSpeak_AreWomenPresent_True()
        {
            Raj testActor = new Raj{ AreWomenPresent = true };

            string rajScript = testActor.Speak();

            Assert.AreEqual("Raj: mumble", rajScript);
        }

        [TestMethod]
        public void RajSpeak_AreWomenPresent_False()
        {
            Raj testActor = new Raj { AreWomenPresent = false };

            string rajScript = testActor.Speak();

            Assert.AreEqual("Raj: I am afraid of women", rajScript);
        }

        [TestMethod]
        public void ActorSpeak() 
        {
            Actor testActor = new Actor();

            string actorScript = testActor.Speak();

            Assert.AreEqual(string.Empty, actorScript);
        }

        [TestMethod]
        public void NullSpeak()
        {
            Actor testActor = null;

            Assert.ThrowsException<ArgumentNullException>(() => testActor.Speak());
        }
    }
}
