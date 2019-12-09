using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();

        private Item? _SelectedItem;
        public Item? SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        private string _NameToAppend = "";
        public string NameToAppend
        {
            get => _NameToAppend;
            set => Set(ref _NameToAppend, value);
        }

        public RelayCommand AddItem { get; }
        public RelayCommand<Item> RemoveItem { get; }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NameToAppend))
            {
                var newItem = new Item { Name = NameToAppend };
                ShoppingList.Add(newItem);
                SelectedItem = newItem;
                NameToAppend = "";
            }
        }

        private void OnRemoveItem(Item item)
        {
            if (object.ReferenceEquals(SelectedItem, item))
                SelectedItem = null;

            ShoppingList.RemoveAt(
                ShoppingList.Zip(
                    Enumerable.Range(0, ShoppingList.Count))
                        .First(en => object.ReferenceEquals(en.First, item))
                            .Second);
        }

        public MainWindowViewModel()
        {
            AddItem = new RelayCommand(OnAddItem);
            RemoveItem = new RelayCommand<Item>(OnRemoveItem);
        }
    }
}
