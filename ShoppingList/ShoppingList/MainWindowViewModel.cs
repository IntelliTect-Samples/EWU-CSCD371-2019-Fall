using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ShopItem> ShopList { get; } =  new ObservableCollection<ShopItem>();

        public ICommand AddListItemCommand { get; }

        public string ItemText { get; private set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            AddListItemCommand = new Command(OnAddItem);
        }

        private void OnAddItem()
        {
            if (ItemText.Length > 0)
            {
                ShopList.Add(ItemText);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemText)));
                ItemText = "";
            }
            
        }
    }
}