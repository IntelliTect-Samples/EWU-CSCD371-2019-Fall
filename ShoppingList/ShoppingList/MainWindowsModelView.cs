using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ShoppingList
{
    public class MainWindowsModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();


    }
}
