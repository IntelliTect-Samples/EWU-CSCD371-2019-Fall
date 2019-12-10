using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShoppingList
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private int    _NewAmount;
        private string _NewName = "";

        private Item? _SelectedItem;

        public MainWindowViewModel()
        {
            for (var x = 1; x <= 10; x++) Amounts.Add(x);

            Items.Add(new Item {Name = "Apples", Amount = 3});
            Items.Add(new Item {Name = "1 lb. Ground Beef"});
            Items.Add(new Item {Name = "Various Soda", Amount = 2});
            AddItemCommand    = new Command(OnAddItem);
            RemoveItemCommand = new Command(OnRemoveItem);
        }

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        public int SelectedIndex { get; set; } = -1;

        public Item? SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                NewName       = _SelectedItem?.Name ?? "";
                NewAmount     = _SelectedItem?.Amount - 1 ?? 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public string NewName
        {
            get => _SelectedItem?.Name ?? _NewName;
            set
            {
                _NewName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewName)));
            }
        }

        public int NewAmount
        {
            get => _SelectedItem?.Amount - 1 ?? 0;
            set
            {
                _NewAmount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewAmount)));
            }
        }

        public Command AddItemCommand    { get; }
        public Command RemoveItemCommand { get; }

        public List<int> Amounts { get; } = new List<int>();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(_NewName))
            {
                if (SelectedIndex == -1)
                {
                    Items.Add(new Item {Name = _NewName, Amount = _NewAmount + 1});
                } else
                {
                    Items[SelectedIndex] = new Item {Name = _NewName, Amount = _NewAmount + 1};
                    SelectedIndex        = -1;
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }

            SelectedItem = null;
        }

        private void OnRemoveItem()
        {
            if (SelectedIndex == -1) return;
            Items.RemoveAt(SelectedIndex);
            SelectedIndex = -1;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
        }

    }

}
