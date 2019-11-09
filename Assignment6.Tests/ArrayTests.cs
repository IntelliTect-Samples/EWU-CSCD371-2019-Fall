using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(1)]
        public void Array_Add_AddsSuccessfully(int capacity)
        {
            // Arrange
            Array<int> sut = new Array<int>(capacity);

            // Act
            int i = 0;
            while(i < capacity)
            {
                sut.Add(i);
                i++;
            }

            // Assert
            i = 0;
            foreach(int value in sut)
            {
                Assert.AreEqual(i, value);
            }
        }
    }
}
