using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorExtensionsTests
    {
        [TestMethod]
        public void ActorExtensions_Speak_Sheldon()
        {
            Assert.AreEqual(new Sheldon().Speak(false), "The entropy of a black hole is proportional to its surface area");
        }

        [TestMethod]
        public void ActorExtensions_Speak_Penny()
        {
            Assert.AreEqual(new Penny().Speak(false), "How's it going!");
        }

        [TestMethod]
        public void ActorExtensions_Speak_RajWithoutWomen()
        {
            Assert.AreEqual(new Raj().Speak(false), "Hello!");
        }

        [TestMethod]
        public void ActorExtensions_Speak_RajWithWomen()
        {
            Assert.AreEqual(new Raj().Speak(true), "mbmthbm");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ActorExtensions_Speak_NullActor()
        {
            ActorExtensions.Speak(null, false);
        }
    }
}
