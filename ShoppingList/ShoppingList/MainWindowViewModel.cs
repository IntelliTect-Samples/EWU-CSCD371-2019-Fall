using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _Text = "";
        private Item _SelectedItem = new Item("");

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
        public Command AddItemCommand { get; }
        public Command RemoveItemCommand { get; }


        public MainWindowViewModel() {
            AddItemCommand = new Command(OnAddItem);
            RemoveItemCommand = new Command(OnRemoveItem);


            Items.Add(new Item("Doritos"));
            Items.Add(new Item("Mtn. Dew"));

            SelectedItem = Items.First();
        }

        private void OnRemoveItem() {
            if (!(SelectedItem is null)) {
                Items.Remove(SelectedItem);
            }
        }

        private void SetProperty<T>(ref T f, T v,
            [CallerMemberName]string property = "Text") {
            if (!EqualityComparer<T>.Default.Equals(f, v)) {
                f = v;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Text {
            get => _Text = "<Type Here>";
            set => SetProperty(ref _Text, value);
        }

        public Item SelectedItem {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }




        private void OnAddItem() {
            Items.Add(new Item(Text));
        }
    }
}