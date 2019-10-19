using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Actors_SpeakCorrectLine()
        {
            var penny = new Penny();
            var sheldon = new Sheldon();
            var raj = new Raj();

            Assert.AreEqual("I love him, but if he's broken, let's not get a new one.", penny.Speak());
            Assert.AreEqual("Interesting. You're afraid of insects and women. Ladybugs must render you catatonic.",
                sheldon.Speak());
            Assert.AreEqual("Oh man, first monster I see I'm gonna sneak up behind him," +
                            "whip out my wand and shoot my magic all over his ass!", raj.Speak());
            raj.WomenArePresent = true;
            Assert.AreEqual("*audible confusion*", raj.Mumble());
        }
    }
}