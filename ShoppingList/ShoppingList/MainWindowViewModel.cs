using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;

namespace ShoppingList
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        private readonly Command _AddItemCommand;

        public ICommand AddItemCommand => _AddItemCommand;
        

        public MainWindowViewModel()
        {
            _AddItemCommand = new Command(OnAddItem);
            ShoppingList.Add(new Item("New Item", 1));
        }

        private void OnAddItem()
        {
            ShoppingList.Add(new Item("Temp", 10));
        }
    }
}