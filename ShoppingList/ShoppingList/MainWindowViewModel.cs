using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<ShoppingItem> ShoppingList { get; } = new ObservableCollection<ShoppingItem>();
    }
}
