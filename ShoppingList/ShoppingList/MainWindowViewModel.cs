using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

        public string ItemName { get; set; } = "New Item";

        public Command AddItemCommand { get; }

        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
        }

        private void OnAddItem()
        {
            Items.Add(new Item { Name = ItemName});
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
        }
    }
}
