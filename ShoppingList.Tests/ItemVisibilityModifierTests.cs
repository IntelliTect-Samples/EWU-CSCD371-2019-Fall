using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemVisibilityModifierTests
    {
        [TestMethod]
        public void Convert_IsItem()
        {
            var sut = new ItemVisibilityConverter();
            Item objectToPass = new Item("a");

            string result = sut.Convert(objectToPass, null,null,null) as string;

            Assert.AreEqual("Visible", result);
        }

        [TestMethod]
        public void Convert_IsNotItem()
        {
            var sut = new ItemVisibilityConverter();
            string objectToPass = new string("ABC");

            string result = sut.Convert(objectToPass, null, null, null) as string;

            Assert.AreEqual("Hidden", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConvertBack_()
        {
            var sut = new ItemVisibilityConverter();

            string result = sut.ConvertBack(new Item(), null, null, null) as string;
        }

    }
}
