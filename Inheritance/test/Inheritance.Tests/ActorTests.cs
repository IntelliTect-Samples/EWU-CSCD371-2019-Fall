using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Speak_RajWithWomenPresent_ReturnsMumble()
        {
            Actor actor = new Raj(true);

            Assert.AreEqual("...mmaksjdjsks", actor.Speak());
        }

        [TestMethod]
        public void Speak_RajWithNoWomenPresent_ReturnsSpeak()
        {
            Actor actor = new Raj(false);

            Assert.AreEqual("Hello", actor.Speak());
        }

        [TestMethod]
        public void Speak_PennySpeaks()
        {
            Actor actor = new Penny();

            Assert.AreEqual("Soft Kitty", actor.Speak());
        }

        [TestMethod]
        public void Speak_SheldonSpeaks()
        {
            Actor actor = new Sheldon();

            Assert.AreEqual("Bazinga", actor.Speak());
        }

    }
}
