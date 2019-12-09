using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string? propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Text;
        public string Text 
        { 
            get => _Text;
            set => SetProperty(ref _Text, value);
        }

        private ShoppingItem _SelectedItem;
        public ShoppingItem SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        public ICommand AddNewItemCommand { get; }

        public ObservableCollection<ShoppingItem> ShoppingList { get; } = new ObservableCollection<ShoppingItem>();

        public MainWindowViewModel()
        {
            AddNewItemCommand = new Command(OnAddNewItem);
            Text = "";
            ShoppingList.Add(new ShoppingItem("Bologna"));
            ShoppingList.Add(new ShoppingItem("Bread"));

            SelectedItem = ShoppingList.First();
        }

        private void OnAddNewItem()
        {
            if(Text != "")
            {
                ShoppingList.Add(new ShoppingItem(Text));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
                Text = "";
            }

        }
    }
}
