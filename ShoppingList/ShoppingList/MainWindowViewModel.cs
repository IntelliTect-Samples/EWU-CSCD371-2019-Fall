using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<Item> ShoppingItems { get; } = new ObservableCollection<Item>();

        private int SelectedIndex { get; set; }
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
                SelectedIndex = ShoppingItems.IndexOf(value!);
            }
        }

        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            DeselectCommand = new Command(OnDeselect);
            DeleteItemCommand = new Command(OnDeleteItem);
            MoveUpCommand = new Command(OnMoveUp);
            MoveDownCommand = new Command(OnMoveDown);
        }

        public ICommand AddItemCommand { get; }
        private void OnAddItem()
        {
            ShoppingItems.Add(new Item());
            SelectedListItem = ShoppingItems[ShoppingItems.Count - 1];
        }

        public ICommand DeselectCommand { get; }
        private void OnDeselect() => SelectedListItem = null;

        public ICommand DeleteItemCommand { get; }
        private void OnDeleteItem()
        {
            if (SelectedListItem is null) return;

            SelectedListItem.Text = "";
            OnDeselect();
        }

        // moves toward start of list
        public ICommand MoveUpCommand { get; }
        private void OnMoveUp()
        {
            if (SelectedListItem is null || SelectedIndex <= 0) return;

            ShoppingItems.Move(SelectedIndex, --SelectedIndex);
        }

        // moves toward end of list
        public ICommand MoveDownCommand { get; }
        private void OnMoveDown()
        {
            if (SelectedListItem is null || SelectedIndex == ShoppingItems.Count - 1) return;

            ShoppingItems.Move(SelectedIndex, ++SelectedIndex);
        }
    }
}
