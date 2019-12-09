using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemVisibilityConverterTests
    {
        [TestMethod]
        public void Convert_NotNull_Visible()
        {
            var item = new Item();

            string visibility = (new ItemVisibilityConverter().Convert(item) as string)!;

            Assert.AreEqual<string>("Visible", visibility);
        }

        [TestMethod]
        public void Convert_Null_Hidden()
        {
            string visibility = (new ItemVisibilityConverter().Convert(null) as string)!;

            Assert.AreEqual<string>("Hidden", visibility);
        }

        [TestMethod]
        public void ConvertBack_ThrowsException()
        {
            Assert.ThrowsException<InvalidOperationException>(
                () => new ItemVisibilityConverter().ConvertBack(null));
        }
    }
}
