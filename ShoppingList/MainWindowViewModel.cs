using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        private Item? _SelectedItem;
        public Item? SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        private string _NewItemName = "";
        public string NewItemName
        {
            get => _NewItemName;
            set => Set(ref _NewItemName, value);
        }

        public RelayCommand AddItem { get; }
        public RelayCommand<Item> RemoveItem { get; }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewItemName))
            {
                var newItem = new Item { Name = NewItemName };
                Items.Add(newItem);
                SelectedItem = newItem;
                NewItemName = "";
            }
        }

        private void OnRemoveItem(Item item)
        {
            if (object.ReferenceEquals(SelectedItem, item))
                SelectedItem = null;
            int index = Items.Zip(Enumerable.Range(0, Items.Count))
                             .First(en => object.ReferenceEquals(en.First, item))
                             .Second;

            Items.RemoveAt(index);
        }

        public MainWindowViewModel()
        {
            AddItem = new RelayCommand(OnAddItem);
            RemoveItem = new RelayCommand<Item>(OnRemoveItem);
        }
    }
}
