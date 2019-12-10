using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Item? _SelectedItem;
        private string? _NewItemName;

        public Item? SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        public string? NewItemName
        {
            get => _NewItemName;
            set => Set(ref _NewItemName, value);
        }

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        public RelayCommand AddItemCommand { get; }

        public MainWindowViewModel()
        {
            AddItemCommand = new RelayCommand(OnAddItem);
        }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewItemName) && !string.IsNullOrEmpty(NewItemName))
            {
                Items.Add(new Item() { Name = NewItemName });
                NewItemName = "";
            }
        }
    }
}
