using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _StrToAdd = "";
        public string StrToAdd
    	{
        	get => _StrToAdd;
        	set => _StrToAdd = value;
        }
        
        private Item? _SelectedItem = null;
        public Item? SelectedItem
        {
        	get => _SelectedItem!;
        	set => _SelectedItem = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Item?> ShoppingList { get; } 
            = new ObservableCollection<Item?>();

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAppendItem);
            DeleteItemCommand = new Command(OnDeleteItem);
        }

        public void OnAppendItem()
        {
			if (!string.IsNullOrWhiteSpace(StrToAdd))
				ShoppingList.Add(new Item(StrToAdd));

			StrToAdd = "";
			SelectedItem = null;
        }

		public void OnDeleteItem()
		{
			if (!(SelectedItem is null))
			{
				ShoppingList.Remove(SelectedItem);
				SelectedItem = null;
			}
		}
    }
}
