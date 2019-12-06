using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<Item> ShoppingItems { get; } = new ObservableCollection<Item>();

        private Item? _SelectedListItem;
        public Item? SelectedListItem
        {
            get => _SelectedListItem;
            set
            {
                // intentially not using ?. as I dont want to confuse item==null with item.text==null
                if (_SelectedListItem != null && string.IsNullOrWhiteSpace(_SelectedListItem.Text))
                {
                    ShoppingItems.Remove(_SelectedListItem);
                }
                SetProperty(ref _SelectedListItem, value);
            }
        }

        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            DeselectCommand = new Command(OnDeselect);
        }

        public ICommand AddItemCommand { get; }
        private void OnAddItem()
        {
            ShoppingItems.Add(new Item());
            SelectedListItem = ShoppingItems[ShoppingItems.Count - 1];
        }

        public ICommand DeselectCommand { get; }
        private void OnDeselect() => SelectedListItem = null;
    }
}
