using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName=null)
        {
            if(!EqualityComparer<T>.Default.Equals(field,value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }        }
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        private Item _SelectedItem;
        public Item SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }
        private string _NewItem;
        public string NewItem
        {
            get => _NewItem;
            set => SetProperty(ref _NewItem, value);
        }

        public RelayCommand ChangeNameCommand { get; }
        public ICommand AddItemCommand { get; }
        private bool CanExecute { get; set; }

        public MainWindowViewModel()
        {
            ChangeNameCommand = new RelayCommand(OnChangeName, () => CanExecute);
            AddItemCommand = new Command(OnAddItem);

            Items.Add(new Item("Cheese"));

            SelectedItem = Items.First();
        }

        private void OnAddItem()
        {
            if (NewItem != "" && NewItem != null)
            {
                Items.Add(new Item(NewItem));
                CanExecute = true;
                ChangeNameCommand.RaiseCanExecuteChanged();
            }
        }
        private void OnChangeName()
        {
            SelectedItem = null;
        }
    }
}
