using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<ShoppingItem> ShoppingList { get; } = new ObservableCollection<ShoppingItem>();
    
    
        public MainWindowViewModel()
        {
            ShoppingList.Add(new ShoppingItem("Mayo"));
            ShoppingList.Add(new ShoppingItem("Ketchup"));
            ShoppingList.Add(new ShoppingItem("Red tomatoes"));
            ShoppingList.Add(new ShoppingItem("Eggs"));

            SelectedItem = ShoppingList.First();
        }

        private ShoppingItem _SelectedItem;
        public ShoppingItem SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }


    }
}
