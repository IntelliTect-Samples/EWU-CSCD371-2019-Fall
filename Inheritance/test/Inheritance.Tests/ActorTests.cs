using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void Speak_Raj_WomenArePresentIsTrue_Mumbles()
        {
            //Arrange
            Raj raj = new Raj();

            //Act
            raj.Speak(true);

            //Assert
            Assert.AreEqual(raj.lastSaid, "Raj is mumbling.");
        }

        [TestMethod]
        public void Speak_Raj_WomenArePresentIsFalse_Speaks()
        {
            //Arrange
            Raj raj = new Raj();

            //Act
            raj.Speak(false);

            //Assert
            Assert.AreEqual(raj.lastSaid, "Raj is speaking.");
        }

        [TestMethod]
        public void Speak_Sheldon()
        {
            //Arrange
            Sheldon shel = new Sheldon();
            //Act
            shel.Speak();

            //Assert
            Assert.AreEqual(shel.lastSaid, "Sheldon is speaking.");
        }

        [TestMethod]
        public void Speak_Penny()
        {
            //Arrange
            Penny penn = new Penny();

            //Act
            penn.Speak();

            //Assert
            Assert.AreEqual(penn.lastSaid, "Penny is speaking.");
        }
    }
}
