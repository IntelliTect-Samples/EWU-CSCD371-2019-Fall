using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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

        private string _NewName = "";
        public string NewName
        {
            get => _NewName;
            set => SetProperty(ref _NewName, value);
        }

        public RelayCommand AddItem { get; }

        public MainWindowViewModel()
        {
            MyShoppingList.Add(new ShopItem("Banana"));
            MyShoppingList.Add(new ShopItem("Apple"));
            MyShoppingList.Add(new ShopItem("Peach"));
            _SelectedShopItem = MyShoppingList.First();

            AddItem = new RelayCommand(OnAddItem);
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
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                var newItem = new ShopItem(NewName);
                MyShoppingList.Add(newItem);
                SelectedShopItem = newItem;
                NewName = "";
            }
        }

    }
}
