using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void SheldonSpeaks()
        {
            //Arrange
            Actor s = new Sheldon();
            //Act
            string output = s.Speak(false);
            //Assert
            Assert.AreEqual("I know the real reason you never made progress with that idea. " +
                "You thought of it September 22nd, 2007. Two days later, Penny moved in and so " +
                "much blood rushed to your genitals, your brain became a ghost town.", output);
        }

        [TestMethod]
        public void PennySpeaks()
        {
            //Arrange
            Actor p = new Penny();
            //Act
            string output = p.Speak(true);
            //Assert
            Assert.AreEqual("Woah, that's kind of a big step for a guy who only recently " +
                "agreed to take his socks off.", output);
        }

        [TestMethod]
        public void RajSpeaksWomenPresent()
        {
            //Arrange
            Actor r = new Raj();
            //Act
            string output = r.Speak(true);
            //Assert
            Assert.AreEqual("mumble", output);
        }

        [TestMethod]
        public void RajSpeaksWomenNotPresent()
        {
            //Arrange
            Actor r = new Raj();
            //Act
            string output = r.Speak(false);
            //Assert
            Assert.AreEqual("I've said this before and I'll say it again: Aquaman sucks!", output);
        }
    }
}