using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemVisibilityConverterTests
    {
        [TestMethod]
        public void Convert_SelectedItemNull_ReturnsCollapsed()
        {
            var visibilityConverter = new ItemVisibilityConverter();

            Item? item = null;

            var visible = visibilityConverter.Convert(item!);

            Assert.AreEqual(Visibility.Collapsed, visible);
        }

        [TestMethod]
        public void Convert_SelectedItemNotNull_ReturnsVisible()
        {
            var visibilityConverter = new ItemVisibilityConverter();

            Item? item = new Item();

            var visible = visibilityConverter.Convert(item);

            Assert.AreEqual(Visibility.Visible, visible);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConvertBack_ThrowsInvalidOperationException_ForAnyInput()
        {
            var visibilityConverter = new ItemVisibilityConverter();
            Visibility visible = Visibility.Visible;

            visibilityConverter.ConvertBack(visible, null!, null!, null!);
        }
    }
}
