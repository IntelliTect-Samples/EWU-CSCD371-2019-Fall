using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests {
    [TestClass]
    public class ActorTests {
        [TestMethod]
        public void RajCantSpeakToWomen() {
            //arrange
            Raj raj = new Raj { womenArePresent = true };

            //act
            string outPut = raj.Speak();

            //Assert
            Assert.AreEqual("*Incoherent mumbles* *canned laughter*", outPut);
        }

        [TestMethod]
        public void RajCanSpeakWithoutWomen() {
            //arrange
            Raj raj = new Raj { womenArePresent = false };

            //act
            string outPut = raj.Speak();

            //Assert
            Assert.AreEqual("I'm so nerdy and awkward, it's hilarious! *canned laughter*", outPut);
        }

        [TestMethod]
        public void SheldonCanTalk() {
            //arrange
            Sheldon sheldon = new Sheldon();

            //act
            string outPut = sheldon.Speak();

            //Assert
            Assert.AreEqual("I really wish the programmer knew more about Big Bang Therory, so he could better make fun of me! *canned laughter*", outPut);
        }

        [TestMethod]
        public void PennyCanTalk() {
            //arrange
            Penny penny = new Penny();

            //act
            string outPut = penny.Speak();

            //Assert
            Assert.AreEqual("If the programmer isn't mistaken, I'm just the token hot chick. *canned laughter*", outPut);
        }
    }


}
