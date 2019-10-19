using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Check_What_Raj_Speak_When_WomenPresent()
        {
            Raj raj = new Raj();
            raj.womenArePresent = true;

            Assert.AreEqual("*mumbles*", raj.Speak("should not be this"));
        }

        [TestMethod]
        public void Check_What_Raj_Speak_When_WomenNotPresent()
        {
            Raj raj = new Raj();
            raj.womenArePresent = false;

            Assert.AreEqual("test", raj.Speak("test"));
        }

        [TestMethod]
        public void Check_What_Penny_Speak()
        {
            Penny penny = new Penny();

            Assert.AreEqual("test", penny.Speak("test"));
        }

        [TestMethod]
        public void Check_What_Sheldon_Speak()
        {
            Sheldon sheldon = new Sheldon();

            Assert.AreEqual("test", sheldon.Speak("test"));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Check_Empty_Actor()
        {
            Actor actor = new Actor();

            Assert.AreEqual("", actor.Speak(""));
        }
     


    }
}
