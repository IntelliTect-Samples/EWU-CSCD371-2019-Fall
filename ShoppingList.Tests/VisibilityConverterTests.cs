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
        public void Convert_Item_Visible()
        {
            Item item = new Item();
            VisibilityConverter converter = new VisibilityConverter();

            string result = converter.Convert(item) as string;
            Assert.AreEqual<string>("Visible", result);
        }

        [TestMethod]
        public void Convert_Item_Hidden()
        {
            VisibilityConverter converter = new VisibilityConverter();

            string result = converter.Convert(null) as string;
            Assert.AreEqual<string>("Hidden", result);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void ConvertBack_ThrowsException()
        {
            VisibilityConverter converter = new VisibilityConverter();

            converter.ConvertBack(null);
        }
    }
}
