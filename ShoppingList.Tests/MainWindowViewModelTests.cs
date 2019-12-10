using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();

        [TestMethod]
        public void CanEdit_SelectedPerson_Text()
        {
            //Arrange
            string start = ViewModel.People.First().Text;

            //Act
            ViewModel.People.First().Text = "UnitTest";

            //Assert
            Assert.AreNotEqual(start, ViewModel.People.First().Text);
            Assert.AreEqual("UnitTest", ViewModel.People.First().Text);
        }

        [TestMethod]
        public void Constructor_SetsDefaultSelectedPerson()
        {
            Assert.AreEqual(ViewModel.People.First(), ViewModel.SelectedPerson);
        }

        [TestMethod]
        public void AddPersonCommand_AddsPerson()
        {
            // Arrange
            int initialCount = ViewModel.People.Count;

            // Act
            ViewModel.AddPersonCommand.Execute(null);

            // Assert
            Assert.AreEqual(initialCount + 1, ViewModel.People.Count);
        }

        [TestMethod]
        public void SelectedPerson_RaisesINPC()
        {
            // Arrange
            ViewModel.PropertyChanged += Vm_PropertyChanged;
            bool eventRaised = false;
            var person = new Person("Foo");

            // Act
            ViewModel.SelectedPerson = person;

            // Assert
            Assert.IsTrue(eventRaised);
            Assert.AreEqual(person, ViewModel.SelectedPerson);

            void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                Assert.AreEqual(nameof(MainWindowViewModel.SelectedPerson), e.PropertyName);
                eventRaised = true;
            }
        }

    }
}