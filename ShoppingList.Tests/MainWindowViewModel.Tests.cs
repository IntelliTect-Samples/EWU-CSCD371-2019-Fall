using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(" 	")]
        [DataRow("\n")]
        [DataRow(" \n")]
        [DataRow("  ")]
        public void AddItem_EmptyOrWhitespace_DoesNothing(string name)
        {
            var sut = new MainWindowViewModel();
            sut.NameToAppend = name;
            var initial = sut.ShoppingList.ToList();

            sut.AddItem.Execute(null);

            CollectionAssert.AreEqual(initial, sut.ShoppingList);
        }

        [DataTestMethod]
        [DataRow("one")]
        [DataRow("two")]
        [DataRow("three")]
        public void AddItem_ValidString_AppendsItem(string name)
        {
            var sut = new MainWindowViewModel();
            sut.NameToAppend = name;
            var initial = sut.ShoppingList.Append(new Item { Name = name }).ToList();

            sut.AddItem.Execute(null);

            CollectionAssert.AreEqual(
                initial.Select(item => item.Name).ToList(),
                sut.ShoppingList.Select(item => item.Name).ToList()
            );
            Assert.AreEqual<string>("", sut.NameToAppend);
        }

        [TestMethod]
        public void RemoveItem_SelectedItem_ClearsSelection()
        {
            var sut = new MainWindowViewModel();
            var target = new Item
            { 
                Name = "Target"
            };

            sut.ShoppingList.Add(new Item 
                { 
                    Name = "Not Target" 
                });

            sut.ShoppingList.Add(target);
            sut.SelectedItem = target;

            sut.RemoveItem.Execute(target);
            Assert.IsNull(sut.SelectedItem);
        }

        [TestMethod]
        public void RemoveItem_NotSelectedItem_KeepsSelection()
        {
            var sut = new MainWindowViewModel();

            var expected = new Item 
            { 
                Name = "expected" 
            };

            var other = new Item 
            { 
                Name = "other"
            };

            sut.ShoppingList.Add(expected);
            sut.ShoppingList.Add(other);
            sut.SelectedItem = other;

            sut.RemoveItem.Execute(expected);

            Assert.ReferenceEquals(other, sut.SelectedItem);
        }
    }
}
