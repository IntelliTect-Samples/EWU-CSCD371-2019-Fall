using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _newItemText = "";
        private Item _selectedItem;

        public Item? SelectedItem
        {
            get => _selectedItem; 
            set => SetProperty(ref _selectedItem, value);
        }

        public string? NewItemText
        {
            get => _newItemText;
            set => SetProperty(ref _newItemText, value);
        }

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        public ICommand AddItemCommand { get; }



        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);

            NewItemText = "";
        }

        
        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(_newItemText))
            {
                Items.Add(new Item(_newItemText));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }

            _newItemText = "";
            _selectedItem = null;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
