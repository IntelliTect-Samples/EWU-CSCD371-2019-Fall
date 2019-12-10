using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value,
            [CallerMemberName]string propertyName = null)
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

        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get => _SelectedPerson;
            set => SetProperty(ref _SelectedPerson, value);
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public Command ChangeNameCommand { get; }

        public ICommand AddPersonCommand { get; }
        private Func<DateTime> GetNow { get; }

        private bool CanExecute { get; set; }

        public MainWindowViewModel(Func<DateTime> getNow)
        {
            Text = "Hello World";
            ChangeNameCommand = new Command(OnChangeName, () => CanExecute);
            AddPersonCommand = new Command(OnAddPerson);

            var dob = getNow().Subtract(TimeSpan.FromDays(30 * 365));

            People.Add(new Person("Kevin", "Bost", dob));
            People.Add(new Person("Mark", "Mc", dob));

            SelectedPerson = People.First();
            GetNow = getNow ?? throw new ArgumentNullException(nameof(getNow));
        }

        private void OnAddPerson()
        {
            var dob = GetNow().Subtract(TimeSpan.FromDays(30 * 365));
            People.Add(new Person("Foo", $"Bar {People.Count}", dob));
            CanExecute = true;
            ChangeNameCommand.InvokeCanExecuteChanged();
        }

        private void OnChangeName()
        {
            Text = "Kevin";
        }
    }
}
