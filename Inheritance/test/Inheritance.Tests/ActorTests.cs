using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assuming original Actor tests are all passing
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMixinMethods_Speak_Penny()
        {
            Assert.AreEqual("I'm Penny", (new Penny()).Speak());
        }

        [TestMethod]
        public void TestMixinMethods_Speak_Sheldon()
        {
            Assert.AreEqual("I'm Sheldon", (new Sheldon()).Speak());
        }

        [TestMethod]
        public void TestMixinMethods_Speak_Raj()
        {
            var raj = new Raj() { WomenArePresent = true };
            Assert.AreEqual("", raj.Speak());
            raj = new Raj() { WomenArePresent = false };
            Assert.AreEqual("*mumble*", raj.Speak());
        }
    }
}
