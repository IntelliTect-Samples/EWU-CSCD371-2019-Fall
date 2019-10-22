using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorMixinsTests
    {

        [TestMethod]
        public void ActorMixins_Penny_Speaks()
        {
            //Arrange
            Actor penny = new Penny();

            //Act

            //Assert
            Assert.AreEqual("Hey I'm Penny", penny.Speak());
        }

        [TestMethod]
        public void ActorMixins_Sheldon_Speaks()
        {
            //Arrange
            Actor sheldon = new Sheldon();

            //Act

            //Assert
            Assert.AreEqual("Bapzingus", sheldon.Speak());
        }

        [TestMethod]
        public void ActorMixins_Raj_NoWomenPresent_Speaks()
        {
            //Arrange
            Actor raj = new Raj { WomenArePresent = false};

            //Act

            //Assert
            Assert.AreEqual("Hello friends", raj.Speak());
        }

        [TestMethod]
        public void ActorMixins_Raj_WomenPresent_Speaks()
        {
            //Arrange
            Actor raj = new Raj { WomenArePresent = true };

            //Act

            //Assert
            Assert.AreEqual("mumble", raj.Speak());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ActorMixins_NullActor_ThrowsException()
        {
            //Arrange

            //Act
            Actor nullActor = new Actor();

            //Assert
        }
    }
}
