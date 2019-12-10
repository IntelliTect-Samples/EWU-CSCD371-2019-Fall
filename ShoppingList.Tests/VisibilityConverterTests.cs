using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class VisibilityConverterTests
    {
        [TestMethod]
        public void Convert_ShoppingItem_BecomesVisible()
        {
            ShoppingItem item = new ShoppingItem("Apple");
            string visible = (new VisibilityConverter().Convert(item) as string)!;

            Assert.AreEqual("Visible", visible);
        }

        [TestMethod]
        public void Convert_NonShoppingItem_BecomesHidden()
        {
            string item = new string("Apple");
            string visible = (new VisibilityConverter().Convert(item) as string)!;

            Assert.AreEqual("Hidden", visible);
        }

        [TestMethod]
        public void Convert_NullItem_BecomesHidden()
        {
            string visible = (new VisibilityConverter().Convert(null) as string)!;

            Assert.AreEqual("Hidden", visible);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ConvertBack_ThrowsException()
        {
           _ = new VisibilityConverter().ConvertBack(null);
        }
    }
}
