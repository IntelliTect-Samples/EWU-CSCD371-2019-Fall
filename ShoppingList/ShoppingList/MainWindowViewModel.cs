using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();

        private Item _SelectedItem; 
        public Item SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        private string _NewName;
        public string NewName
        {
            get => _NewName;
            set => Set(ref _NewName, value);
        }
        public RelayCommand AddItemCommand { get; }

        public MainWindowViewModel()
        {
            AddItemCommand = new RelayCommand(OnAddItem);
            ShoppingList.Add(new Item("Gallon of Milk"));
            ShoppingList.Add(new Item("Bread"));
            ShoppingList.Add(new Item("Oreos"));
            ShoppingList.Add(new Item("Busch"));
        }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                Item toAdd = new Item(NewName);
                ShoppingList.Add(toAdd);
                SelectedItem = toAdd;
                NewName = "";
            }
        }

    }
}