using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests {
    [TestClass]
    class PersonTests {
        [TestMethod]
        public void Person_ToString_ReturnsAsExpected() {
            //Arrange
            Person person = new Person("Joel", "Kalich");

            //Act

            //Assert
            Assert.AreEqual("Joel Kalich", person.toString());
        }
    }
}
