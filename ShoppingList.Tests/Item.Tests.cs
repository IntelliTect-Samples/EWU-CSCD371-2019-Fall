using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemTests
    {
        [DataTestMethod]
        [DataRow("Pine")]
        [DataRow("Apple")]
        [DataRow("Pineapple")]
        [DataRow("Pinepineapple")]
        [DataRow("Applepineapple")]
        [DataRow("Pineapplepineapple")]
        public void Equals_Equal_True(string name)
        {
            var item1 = new Item { Name = name };
            var item2 = new Item { Name = name };

            Assert.AreEqual<Item>(item1, item2);
        }

        [DataTestMethod]
        [DataRow("Pine", "Pineapplepineapple")]
        [DataRow("Apple", "Pine")]
        [DataRow("Pineapple", "Apple")]
        [DataRow("Pinepineapple", "Pineapple")]
        [DataRow("Applepineapple", "Pinepineapple")]
        [DataRow("Pineapplepineapple", "Applepineapple")]
        public void Equals_NotEqual_False(string name1, string name2)
        {
            var item1 = new Item { Name = name1 };
            var item2 = new Item { Name = name2 };

            Assert.AreNotEqual<Item>(item1, item2);
        }
    }
}
