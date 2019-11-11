using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Add_Success(int item)
        {
            var sut = new Array<int>
            {
                1,
                2,
                3
            };

            sut.Add(item);

            Assert.AreEqual(sut.Count, 4);
            Assert.AreEqual(sut[3], item);
        }

        [TestMethod]
        public void Clear_Success()
        {
            var sut = new Array<int>
            {
                1,
                2,
                3
            };

            sut.Clear();

            Assert.AreEqual(0, sut.Count);

        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Contains_Success(int item)
        {
            var sut = new Array<int>
            {
                1,
                2,
                3
            };

            bool doesContain = sut.Contains(item);

            Assert.IsTrue(doesContain);
        }

        [TestMethod]
        public void CopyTo_Success()
        {
            var sut = new Array<int>
            {
                1,
                2,
                3
            };
            var target = new int[3];

            sut.CopyTo(target, 0);

            CollectionAssert.AreEqual(sut.ToArray(), target);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Remove_Success(int item)
        {
            var sut = new Array<int>
            {
                1,
                2,
                3
            };

            sut.Remove(item);

            Assert.IsFalse(sut.Contains(item));
        }
    }
}
