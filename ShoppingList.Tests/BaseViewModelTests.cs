using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace ShoppingList.Tests
{
    [TestClass]
    public class BaseViewModelTests
    {
        [TestMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Separation of actions for test format.")]
        public void SetProperty_UpdateProperty_PropertyHasUpdatedValue()
        {
            int initialValue = 0;
            int newValue = 10;
            FakeViewModel sut = new FakeViewModel(initialValue);

            sut.FakeProperty = newValue;

            Assert.AreNotEqual<int>(initialValue, sut.FakeProperty);
            Assert.AreEqual<int>(newValue, sut.FakeProperty);
        }

        [TestMethod]
        public void SetProperty_UpdateProperty_EventHandlerNotifiesListeners()
        {
            FakeViewModel sut = new FakeViewModel(0);
            sut.PropertyChanged += OnPropertyChanged;
            bool eventHandled = false;
            int newValue = 10;

            sut.FakeProperty = newValue;

            Assert.IsTrue(eventHandled);

            void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
            {
                Assert.AreEqual(nameof(sut.FakeProperty), args.PropertyName);
                eventHandled = true;
            }
        }
    }
}