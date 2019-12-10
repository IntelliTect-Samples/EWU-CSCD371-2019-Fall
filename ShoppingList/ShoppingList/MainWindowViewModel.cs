using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ShopItem> MyShoppingList { get; } = new ObservableCollection<ShopItem>();

        private ShopItem _SelectedShopItem;
        public ShopItem SelectedShopItem
        {
            get => _SelectedShopItem;
            set => Set(ref _SelectedShopItem, value);
        }

        private string _NewName;
        public string NewName
        {
            get => _NewName;
            set => Set(ref _NewName, value);
        }

        public RelayCommand AddItem { get; }

        public MainWindowViewModel()
        {
            AddItem = new RelayCommand(OnAddItem);
            _NewName = "";
        }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                ShopItem newItem = new ShopItem(NewName);
                MyShoppingList.Add(newItem);
                SelectedShopItem = newItem;
                NewName = "";
            }
        }
    }
}
