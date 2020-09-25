using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class BaseNotifyPropertyChangedTests
    {
        [TestMethod]
        public void SetProperty_SetsFieldNewValue()
        {
            BaseNotifyPropertyChanged sut = new BaseNotifyPropertyChanged();
            string field = "Scott";
            string value = "Rowland";

            sut.SetProperty(ref field, value);

            Assert.AreEqual(field, value);

        }

        [TestMethod]
        public void SetProperty_RaisesPropertyChanged()
        {
            BaseNotifyPropertyChanged sut = new BaseNotifyPropertyChanged();
            bool propertyChanged = false;
            sut.PropertyChanged += Sut_PropertyChanged;
            string field = "Scott";
            string value = "Rowland";

            sut.SetProperty(ref field, value);

            Assert.IsTrue(propertyChanged);


            void Sut_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                propertyChanged = true;
            }
        }

        [TestMethod]
        public void SetProperty_DoesNotRaisePropertyChangedIfSame()
        {
            BaseNotifyPropertyChanged sut = new BaseNotifyPropertyChanged();
            bool propertyChanged = false;
            sut.PropertyChanged += Sut_PropertyChanged;
            string field = "Scott";
            string value = "Scott";

            sut.SetProperty(ref field, value);

            Assert.IsFalse(propertyChanged);


            void Sut_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                propertyChanged = true;
            }
        }


    }
}
