using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        private Item? _SelectedItem;
        private string _NewItemName;
        public RelayCommand? AddItem { get; }
        public Item? SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        public string NewItemName
        {
            get => _NewItemName;
            set => Set(ref _NewItemName, value);
        }

        public MainWindowViewModel()
        {
            AddItem = new RelayCommand(OnAddItem);
            _NewItemName = "";
        }
      
        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewItemName))
            {
                var newItem = new Item(NewItemName);
                Items.Add(newItem);
                SelectedItem = newItem;
                NewItemName = "";
            }
        }
    }
}
