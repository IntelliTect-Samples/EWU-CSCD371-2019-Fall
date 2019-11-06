using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(1357)]
        [DataRow(8734)]
        [DataRow(78)]
        [DataRow(385)]
        public void Constructor_ValidCapacity_CorrectCapacity(int capacity)
        {
            var array = new Array<int>(capacity);

            Assert.AreEqual(capacity, array.Capacity);
        }
    }
}
