using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void TestSheldon()
        {
            ActorExtensionMethods sheldon = new ActorExtensionMethods();

            Assert.AreEqual("Hello, im Sheldon.", sheldon.Speak("Sheldon",false));
        }

        [TestMethod]
        public void TestPenny()
        {
            ActorExtensionMethods penny = new ActorExtensionMethods();

            Assert.AreEqual("Hello, im Penny.", penny.Speak("Penny", false));
        }

        [TestMethod]
        public void TestRaj_WithWomen()
        {
            ActorExtensionMethods raj = new ActorExtensionMethods();

            Assert.AreEqual("Hello, im Raj.", raj.Speak("Raj", true));
        }

        [TestMethod]
        public void TestRaj_WithoutWomen()
        {
            ActorExtensionMethods raj = new ActorExtensionMethods();

            Assert.AreEqual("Mumble mumble.", raj.Speak("Raj", false));
        }
    }
}
