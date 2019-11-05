using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonEqualsMethod_ReflexiveProperty()
        {
            var sut = new Person("John", "Doe");

            Assert.AreEqual(sut, sut);
        }

        [TestMethod]
        public void PersonEqualsMethod_DifferentRefSameValue_AreEqual()
        {
            var personOne = new Person("John", "Doe");
            var personTwo = new Person("John", "Doe");

            Assert.AreEqual(personOne, personTwo);
        }

        [TestMethod]
        public void PersonEqualsOperator_EqualsOperatorReflexive()
        {
            var sut = new Person("John", "Doe");
            // Remove warning for comparing a variable to itself
            #pragma warning disable CS1718
            Assert.IsTrue(sut == sut);
            #pragma warning restore
        }

        [TestMethod]
        public void PersonEqualsOperator_EqualsOperatorSameValues()
        {
            var personOne = new Person("John", "Doe");
            var personTwo = new Person("John", "Doe");
            Assert.IsTrue(personOne == personTwo);
        }

        [TestMethod]
        public void PersonNotEqualsOperator_EqualsOperatorDiffValues()
        {
            var personOne = new Person("John", "Doe");
            var personTwo = new Person("Another", "Name");
            Assert.IsTrue(personOne != personTwo);
        }
    }
}
