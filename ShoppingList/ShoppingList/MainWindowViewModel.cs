using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string? propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        private ShoppingItem? _CurrentItem;

        public ShoppingItem? CurrentItem
        {
            get => _CurrentItem;
            set => SetProperty(ref _CurrentItem, value);
        }

        public ObservableCollection<ShoppingItem> Items { get; private set; }

        public Command AddItemCommand { get; }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<ShoppingItem>
            {
                new ShoppingItem("Bananas"),
                new ShoppingItem("Pineapples")
            };
            AddItemCommand = new Command(OnAddItem);
        }

        public void OnAddItem()
        {
            Items.Add(new ShoppingItem("New Item"));
        }
    }
}