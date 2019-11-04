using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests {
    [TestClass]
    public class PersonTests {
        [TestMethod]
        public void ToString_ReturnsAsExpected() {
            //Arrange
            Person person = new Person("Joel", "Kalich");

            //Act

            //Assert
            Assert.AreEqual("Joel Kalich", person.toString());
        }

        [TestMethod]
        public void Equals_Works() {
            //Arrange
            Person person1 = new Person("Joel", "Kalich");
            Person person2 = new Person("Joel", "Kalich");
            Person person3 = new Person("Notjoel", "Notkalich");

            //Act

            //Assert
            Assert.IsTrue(person1.Equals(person2));
            Assert.IsTrue(person2.Equals(person1));
            Assert.IsFalse(person1.Equals(person3));
            Assert.IsFalse(person3.Equals(person1));
        }
    }
}
