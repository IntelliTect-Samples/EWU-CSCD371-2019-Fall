using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class ListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Item> ShoppingList { get; } 
            = new ObservableCollection<Item>();

        public ICommand AddItemCommand { get; }

        public ListModel()
        {
            AddItemCommand = new Command(OnAppendItem);
        }

        public void OnAppendItem()
        {
            ShoppingList.Add(new Item() {
                Name="SomeName",
                Amount=1,
            });

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
        }
    }
}
