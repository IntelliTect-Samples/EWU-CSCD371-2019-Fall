using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class VisibilityModifierTests
    {
        [TestMethod]
        public void VisibilityModifier_Convert_MakeVisible()
        {
            var item = new Item("test");
            string visible = (new VisibilityConverter().Convert(item) as string)!;
            Assert.AreEqual("Visible", visible);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VisibilityModifier_ConvertBack_ThrowsInvalidOperationException()
        {
            var item = new Item("test");
            string visible = (new VisibilityConverter().ConvertBack(item) as string)!;
        }
    }
}
