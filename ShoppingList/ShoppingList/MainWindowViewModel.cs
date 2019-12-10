using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<ShoppingItem> ShoppingList { get; } = new ObservableCollection<ShoppingItem>();

        private ShoppingItem? _SelectedItem;
        public ShoppingItem? SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        private string _NewShoppingItem = "";
        public string NewShoppingItem
        {
            get => _NewShoppingItem;
            set => SetProperty(ref _NewShoppingItem, value);
        }

        public ICommand AddShoppingItemCommand  {get; }

        public MainWindowViewModel()
        {
            ShoppingList.Add(new ShoppingItem("Mayo"));
            ShoppingList.Add(new ShoppingItem("Ketchup"));
            ShoppingList.Add(new ShoppingItem("Red tomatoes"));
            ShoppingList.Add(new ShoppingItem("Eggs"));

            SelectedItem = ShoppingList.First();

            AddShoppingItemCommand = new Command(OnAddShoppingItem);
        }

        private void OnAddShoppingItem()
        {
            if(!String.IsNullOrWhiteSpace(NewShoppingItem))
            {
                var newShoppingItem = new ShoppingItem(NewShoppingItem);
                ShoppingList.Add(newShoppingItem);
                SelectedItem = newShoppingItem;
                NewShoppingItem = "";
            }
        }

    }
}
