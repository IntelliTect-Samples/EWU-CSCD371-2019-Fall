using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            //Arrange
            int[] items = { 25, 34, 2, 5, 0 };

            //Act
            SortUtility.InsertionSort(items,
                delegate(int first, int second)
                {
                    return first > second;
                }
            );

            //Assert
            Assert.AreEqual("0, 2, 5, 25, 34", string.Join(", ", items));
        }

        [TestMethod]
        public void SortUtility_ShouldSortDescending_UsingLamdaExpression()
        {
            //Arrange
            int[] items = { 25, 34, 2, 5, 0 };

            //Act
            SortUtility.InsertionSort(items, (first, second) => second > first);

            //Assert
            Assert.AreEqual("34, 25, 5, 2, 0", string.Join(", ", items));
        }

        [TestMethod]
        public void SortUtility_ShouldSortLexicographically_UsingLamdaStatement()
        {
            //Arrange
            int[] items = { 25, 34, 2, 5, 0 };

            //Act
            SortUtility.InsertionSort(items,
                (first, second) =>
                {
                    bool greater = first > second;
                    string numFirst = first.ToString();
                    string numSecond = second.ToString();

                    int compared = numFirst.ToCharArray()[0].CompareTo(numSecond.ToCharArray()[0]);

                    if(compared == 0)
                    {
                        return first > second;
                    }
                    else if(compared > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //Assert
            Assert.AreEqual("0, 2, 25, 34, 5", string.Join(", ", items));
        }
    }
}
