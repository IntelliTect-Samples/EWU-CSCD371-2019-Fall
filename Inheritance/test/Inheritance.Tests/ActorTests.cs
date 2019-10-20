using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Actor_Sheldon_Speak()
        {
            Actor sheldon = new Sheldon();
            Assert.AreEqual(sheldon.Speak(), "AAHHH!!! OH GOD, NOT EUCLID AVENUE!!!");
        }

        [TestMethod]
        public void Actor_Penny_Speak()
        {
            Actor penny = new Penny();
            Assert.AreEqual(penny.Speak(), "What's the gist, physicist?");
        }

        [TestMethod]
        public void Actor_Howard_Speak()
        {
            Actor howard = new Howard();
            Assert.AreEqual(howard.Speak(), "Settle this.Those little animated pictures on the Internet, are they called 'gifs' or 'jifs'?");
        }
        [TestMethod]
        public void Actor_Raj_SpeakWomenNotPresent()
        {
            Actor raj = new Raj() { WomenPresent = false };
            Assert.AreEqual(raj.Speak(), "I've said this before and I'll say it again: Aquaman sucks!");
        }

        [TestMethod]
        public void Actor_Raj_SpeakWomenPresent()
        {
                Actor raj = new Raj() { WomenPresent = true };
                Assert.AreEqual(raj.Speak(), "---silence....mumble....silence---");
            }
        }
}
