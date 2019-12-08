using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingList
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<ShopItem> MyShoppingList { get; } = new ObservableCollection<ShopItem>();

        private ShopItem _SelectedShopItem;
        public ShopItem SelectedShopItem
        {
            get => _SelectedShopItem;
            set => SetProperty(ref _SelectedShopItem, value);
        }

        public RelayCommand AddItem { get; }
        public RelayCommand<ShopItem> RemoveItem { get; }

        public MainWindowViewModel()
        {
            MyShoppingList.Add(new ShopItem("Banana", 1.0));
            MyShoppingList.Add(new ShopItem("Apple", 1.50));
            MyShoppingList.Add(new ShopItem("Peach", 2.00));
            _SelectedShopItem = MyShoppingList.First();

            AddItem = new RelayCommand(OnAddItem);
            RemoveItem = new RelayCommand<ShopItem>(OnRemoveItem);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void OnAddItem()
        {

        }

        private void OnRemoveItem(ShopItem item)
        {

        }
    }
}
