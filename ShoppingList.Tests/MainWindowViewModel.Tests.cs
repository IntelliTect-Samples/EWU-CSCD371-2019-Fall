using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(" 	")]
        [DataRow("	")]
        [DataRow("\n")]
        [DataRow("\r\n")]
        [DataRow("	\r\n	  ")]
        public void AddItem_EmptyOrWhitespace_DoesNothing(string name)
        {
            var vm = new MainWindowViewModel();
            vm.NewItemName = name;
            var initial = vm.Items.ToList();

            vm.AddItem.Execute(null);

            CollectionAssert.AreEqual(initial, vm.Items);
        }

        [DataTestMethod]
        [DataRow("Pineapple")]
        [DataRow("Pomegranate")]
        [DataRow("More pineapple")]
        [DataRow("Inconceivability")]
        [DataRow("Extra pineapple")]
        [DataRow("Back-up pineapple (just in case)")]
        public void AddItem_ValidString_AppendsItem(string name)
        {
            var vm = new MainWindowViewModel();
            vm.NewItemName = name;
            var initial = vm.Items.Append(new Item { Name = name }).ToList();

            vm.AddItem.Execute(null);

            CollectionAssert.AreEqual(
                initial.Select(item => item.Name).ToList(),
                vm.Items.Select(item => item.Name).ToList()
            );
            Assert.AreEqual<string>("", vm.NewItemName);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(6)]
        public void RemoveItem_Removesitem(int index)
        {
            var vm = new MainWindowViewModel();
            var target = new Item { Name = "Target" };
            var initial = new[] { "Not Target", "Also Not Target", "Target", "Still Not Target", "Definitely Not Target", "Walmart" }
                .Select(name => new Item { Name = name })
                .ToList();
            foreach (Item item in initial)
                vm.Items.Add(item);
            vm.Items.Insert(index, target);

            vm.RemoveItem.Execute(target);

            CollectionAssert.AreEqual(initial, vm.Items);
        }

        [TestMethod]
        public void RemoveItem_SelectedItem_ClearsSelection()
        {
            var vm = new MainWindowViewModel();
            var target = new Item { Name = "Target" };
            vm.Items.Add(new Item { Name = "Not Target" });
            vm.Items.Add(target);
            vm.SelectedItem = target;

            vm.RemoveItem.Execute(target);

            Assert.IsNull(vm.SelectedItem);
        }

        [TestMethod]
        public void RemoveItem_NotSelectedItem_KeepsSelection()
        {
            var vm = new MainWindowViewModel();
            var target = new Item { Name = "Target" };
            var notTarget = new Item { Name = "Not Target" };
            vm.Items.Add(notTarget);
            vm.Items.Add(target);
            vm.SelectedItem = notTarget;

            vm.RemoveItem.Execute(target);

            Assert.ReferenceEquals(notTarget, vm.SelectedItem);
        }
    }
}
