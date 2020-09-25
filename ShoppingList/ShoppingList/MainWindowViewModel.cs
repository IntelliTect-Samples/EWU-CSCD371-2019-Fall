using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private Item? _SelectedItem;
        public Item? SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();

        public ICommand AddListItemCommand { get; }
        public ICommand DeleteListItemCommand { get; }

        public MainWindowViewModel()
        {
            AddListItemCommand = new Command(OnAddListItem);
            DeleteListItemCommand = new Command(OnDeleteListItem);
        }

        private void OnAddListItem()
        {
            SelectedItem = new Item()
            {
                ItemName = "",
                ItemQuantity = 0
            };
            ShoppingList.Add(SelectedItem);
            OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
        }

        private void OnDeleteListItem()
        {
            if (SelectedItem is null)
            {
                return;
            }
            ShoppingList.Remove(SelectedItem);
            SelectedItem = null;
            OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
        }
    }
}
