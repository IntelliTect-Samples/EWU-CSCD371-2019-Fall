using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{

    [TestClass]
    public class ActorTests
    {

        [TestMethod]
        public void Sheldon_SpeaksCorrectly()
        {
            var sheldon = new Sheldon();

            Assert.AreEqual("Test", ActorMixins.Speak(sheldon, "Test"));
            Assert.AreEqual("", ActorMixins.Speak(sheldon, ""));
            Assert.AreEqual("Bazinga!", ActorMixins.Speak(sheldon, null));
        }

        [TestMethod]
        public void Penny_SpeaksCorrectly()
        {
            var penny = new Penny();

            Assert.AreEqual("Test", ActorMixins.Speak(penny, "Test"));
            Assert.AreEqual("", ActorMixins.Speak(penny, ""));
            Assert.AreEqual("Isn't this when he says \"bazooka\" or something?", ActorMixins.Speak(penny, null));
        }

        [TestMethod]
        public void Raj_SpeaksCorrectly()
        {
            var raj = new Raj();

            Assert.AreEqual("Test", ActorMixins.Speak(raj, "Test"));
            Assert.AreEqual("", ActorMixins.Speak(raj, ""));
            Assert.AreEqual("Aquaman sucks!", ActorMixins.Speak(raj, null));
            raj.WomenArePresent = true;
            Assert.AreEqual("*audible confusion*", ActorMixins.Speak(raj, "Should mumble"));
        }

    }

}
