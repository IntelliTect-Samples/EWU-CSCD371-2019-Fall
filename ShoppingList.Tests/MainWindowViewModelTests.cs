using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void OnAddItem_NoParameters_LastItemIsNewItem()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            //Act
            model.OnAddItem();
            //Assert
            Assert.AreEqual<string>("New Item", model.Items.Last().Name);
        }

        [TestMethod]
        public void OnAddItem_NoParameters_CountIncremented()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            int excpectedCount = model.Items.Count + 1;
            //Act
            model.OnAddItem();
            //Assert
            Assert.AreEqual<int>(excpectedCount, model.Items.Count);
        }

        [TestMethod]
        public void AddItemCommand_NoParameters_IsNotNull()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            //Act

            //Assert
            Assert.IsNotNull(model.AddItemCommand);
        }

        [TestMethod]
        public void CurrentItem_NoParameters_IsNull()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            //Act
            //Assert
            Assert.IsNull(model.CurrentItem);
        }

        [TestMethod]
        public void CurrentItem_SetToApple_ReturnsApple()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel
            {
                //Act
                CurrentItem = new ShoppingItem("apple")
            };
            //Assert
            Assert.AreEqual<string>("apple", model.CurrentItem.Name);
        }
    }
}