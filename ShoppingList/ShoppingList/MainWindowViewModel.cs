using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        private Item? _SelectedItem = null;
        public Item? SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        private string _TextToAdd = "";
        public string TextToAdd
        {
            get => _TextToAdd;
            set => SetProperty(ref _TextToAdd, value);
        }

        public MainWindowViewModel()
        {
            DeleteItemCommand = new RelayCommand(OnDeleteItem);
            AddItemCommand = new RelayCommand(OnAddItem);
        }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(TextToAdd))
            {
                bool inList = false;
                foreach (Item item in ShoppingList)
                {
                    if (item.Name == TextToAdd)
                    {
                        inList = true;
                    }
                }
                if (!inList) ShoppingList.Add(new Item(TextToAdd));
                else
                {
                    MessageBoxResult result = MessageBox.Show("That item is already on the list!", "Your Shopping List");
                }
            }
            SelectedItem = null;
            TextToAdd = "";
        }

        private void OnDeleteItem()
        {
            if (SelectedItem != null)
            {
                ShoppingList.Remove(SelectedItem);
                SelectedItem = null;
            }
        }
    }
}