using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ShoppingItem> ItemsList { get; } = new ObservableCollection<ShoppingItem>();

        private ShoppingItem? _SelectedItem;
        public ShoppingItem? SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        private string? _NewItem;
        public string? NewItem
        {
            get => _NewItem;
            set => Set(ref _NewItem, value);
        }

        public ICommand AddItem { get; }
        public ICommand DeleteItem { get; }
        public ICommand EditItem { get; }

        public MainWindowViewModel()
        {
            AddItem = new RelayCommand(OnAddItem);
            DeleteItem = new RelayCommand(OnDeleteItem);
            EditItem = new RelayCommand(OnEditItem);
        }

        private void OnEditItem()
        {
            DeselectListItem();
        }

        private void OnDeleteItem()
        {
            if (SelectedItem != null)
            {
                ItemsList.Remove(SelectedItem);
                SelectedItem = null;
            }
        }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                ItemsList.Add(new ShoppingItem(NewItem));
            }
            NewItem = "";
            DeselectListItem();
        }
        private void DeselectListItem()
        {
            SelectedItem = null;
        }
    }
}
