using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingList
{
    class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<string> ShoppingItems { get; } = new ObservableCollection<string>();

        private string? _SelectedItem;
        public string? SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            ItemClickedCommand = new Command(OnItemClicked);
        }

        public ICommand AddItemCommand { get; }
        public void OnAddItem()
        {
            if (SelectedItem is null)
            {
                ShoppingItems.Add($"Item {ShoppingItems.Count + 1}");
            }
            else
            {
                ShoppingItems.Add($"{SelectedItem} +");
            }
        }

        public ICommand ItemClickedCommand { get; }
        public void OnItemClicked()
        {
            ShoppingItems.RemoveAt(ShoppingItems.Count - 1);
        }
    }
    /*
    private string _Text;
    public string Text
    {
        get => _Text;
        set => SetProperty(ref _Text, value, nameof(Text));
    }

    public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

    public MainWindowViewModel()
    {
        ChangeNameCommand = new Command(OnChangedName);
        AddPersonCommand = new Command(OnAddPerson);

        _Text = "Hello World";

        People.Add(new Person("Mario", "Mario"));
        People.Add(new Person("Luigi", "Mario"));
    }

    public ICommand ChangeNameCommand { get; }
    public void OnChangedName()
    {
        Text = "test";
    }

    public ICommand AddPersonCommand { get; }
    public void OnAddPerson()
    {
        People.Add(new Person("Toad", ""));
    }
}

public class Person
{
    public Person(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}
*/
}
