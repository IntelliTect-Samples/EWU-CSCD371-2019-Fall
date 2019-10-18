using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void SheldonSpeak()
        {
            Sheldon testActor = new Sheldon { Script = "Bazinga" };

            string sheldonScript = testActor.SayLine();

            Assert.AreEqual("Sheldon: Bazinga", sheldonScript);
        }

        [TestMethod]
        public void PennySpeak()
        {
            Penny testActor = new Penny { Script = "I'm Penny" };

            string pennyScript = testActor.SayLine();

            Assert.AreEqual("Penny: I'm Penny", pennyScript);
        }

        [TestMethod]
        public void RajSpeak_WomenPresentTrue()
        {
            Raj testActor = new Raj
            {
                AreWomenPresent = true
            };

            string rajScript = testActor.SayLine();

            Assert.AreEqual("Raj: mumble", rajScript);
        }

        [TestMethod]
        public void RajSpeak_WomenPresentFalse()
        {
            Raj testActor = new Raj 
            {
                AreWomenPresent = false
            };

            string rajScript = testActor.SayLine();

            Assert.AreEqual("Raj: I am afraid of women", rajScript);
        }
    }
}
