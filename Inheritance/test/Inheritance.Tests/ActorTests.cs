using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void SheldonSpeaksAlone()
        {
            //Arrange
            Actor sheldon = new Sheldon();
            string spokenWords = "";
            string expectedWords = "Hello, I am Sheldon.";

            //Act
            spokenWords = sheldon.Speak();

            //Assert
            Assert.AreEqual(spokenWords, expectedWords);
            Assert.IsFalse(Situation.WomenArePresent);
        }

        [TestMethod]
        public void RajSpeaksAlone()
        {
            //Arrange
            Actor raj = new Raj();
            string spokenWords = "";
            string expectedWords = "Hello, I am Raj.";

            //Act
            spokenWords = raj.Speak();

            //Assert
            Assert.AreEqual(spokenWords, expectedWords);
            Assert.IsFalse(Situation.WomenArePresent);
        }

        [TestMethod]
        public void PennySpeaksAlone()
        {
            //Arrange
            Actor penny = new Penny();
            string spokenWords = "";
            string expectedWords = "Hello, I am Penny.";

            //Act
            spokenWords = penny.Speak();

            //Assert
            Assert.IsTrue(Situation.WomenArePresent);
            Assert.AreEqual(spokenWords, expectedWords);
        }

        [TestMethod]
        public void RajAndSheldonSpeak()
        {
            //Arrange
            Situation.WomenArePresent = false;
            Actor sheldon = new Sheldon();
            Actor raj = new Raj();
            string spokenWordsSheldon = "";
            string expectedWordsSheldon = "Hello, I am Sheldon.";
            string spokenWordsRaj = "";
            string expectedWordsRaj = "Hello, I am Raj.";

            //Act
            spokenWordsSheldon = sheldon.Speak();
            spokenWordsRaj = raj.Speak();

            //Assert
            Assert.AreEqual(spokenWordsSheldon, expectedWordsSheldon);
            Assert.AreEqual(spokenWordsRaj, expectedWordsRaj);
            Assert.IsFalse(Situation.WomenArePresent);
        }

        [TestMethod]
        public void RajAndPennySpeak()
        {
            //Arrange
            Situation.WomenArePresent = false;
            Actor penny = new Penny();
            Actor raj = new Raj();
            string spokenWordsPenny = "";
            string expectedWordsPenny = "Hello, I am Penny.";
            string spokenWordsRaj = "";
            string expectedWordsRaj = "mumble...";

            //Act
            spokenWordsPenny = penny.Speak();
            spokenWordsRaj = raj.Speak();

            //Assert
            Assert.IsTrue(Situation.WomenArePresent);
            Assert.AreEqual(spokenWordsPenny, expectedWordsPenny);
            Assert.AreEqual(spokenWordsRaj, expectedWordsRaj);
        }
    }
}
