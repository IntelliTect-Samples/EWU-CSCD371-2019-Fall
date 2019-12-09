using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

using MvvmDialogs;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
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

        public ObservableCollection<Item?> ShoppingList { get; } 
            = new ObservableCollection<Item?>();

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        public MainWindowViewModel()
        {
            AddItemCommand = new RelayCommand(OnAppendItem);
            DeleteItemCommand = new RelayCommand(OnDeleteItem);
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
			if (SelectedItem != null)
			{
				ShoppingList.Remove(SelectedItem);
				SelectedItem = null;
			}
		}
    }
}
