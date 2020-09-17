using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private Item _SelectedItem = new Item();
        public Item SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();

        public ICommand AddListItemCommand { get; }

        public MainWindowViewModel()
        {
            AddListItemCommand = new Command(OnAddListItem);
            //ShoppingList.Add(");
        }

        private void OnAddListItem()
        {
            ShoppingList.Add(new Item()
            {
                ItemName = $"List item",
                ItemQuantity = ShoppingList.Count
            });
            OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
        }
    }
}
