using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

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

        public RelayCommand AddItem { get; }

        private void OnAddItem()
        {
            var newItem = new Item();
            Items.Add(newItem);
            SelectedItem = newItem;
        }

        public MainWindowViewModel()
        {
            AddItem = new RelayCommand(OnAddItem);
        }
    }
}
