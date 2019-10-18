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

            string sheldonScript = testActor.Speak(testActor.Script);

            Assert.AreEqual("Sheldon: Bazinga", sheldonScript);
        }

        [TestMethod]
        public void PennySpeak()
        {
            Penny testActor = new Penny { Script = "I'm Penny" };

            string pennyScript = testActor.Speak(testActor.Script);

            Assert.AreEqual("Penny: I'm Penny", pennyScript);
        }

        [TestMethod]
        public void RajSpeak_WomenPresentTrue()
        {
            Raj testActor = new Raj
            {
                Script = "I'm afraid of women",
                AreWomenPresent = true,
            };

            string rajScript = testActor.Speak(testActor.Script);

            Assert.AreEqual("Raj: mumble", rajScript);
        }

        [TestMethod]
        public void RajSpeak_WomenPresentFalse()
        {
            Raj testActor = new Raj 
            {
                Script = "I'm afraid of women",
                AreWomenPresent = false,
            };

            string rajScript = testActor.Speak(testActor.Script);

            Assert.AreEqual("Raj: mumble", rajScript);
        }
    }
}
