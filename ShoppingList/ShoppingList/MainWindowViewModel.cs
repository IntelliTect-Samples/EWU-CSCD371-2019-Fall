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
        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetProperty<T>(ref T field, T value,
            [CallerMemberName]string propertyName = "Text")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Text = "";
        public string Text
        {
            get => _Text = "<Edit Me>";
            set => SetProperty(ref _Text, value);
        }

        private Person _SelectedPerson = new Person("");
        public Person SelectedPerson
        {
            get => _SelectedPerson;
            set => SetProperty(ref _SelectedPerson, value);
        }

        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public ICommand AddPersonCommand { get; }

        public MainWindowViewModel()
        {
            AddPersonCommand = new Command(OnAddPerson);

            People.Add(new Person("Steak"));
            People.Add(new Person("Potatoes"));

            SelectedPerson = People.First();
        }

        private void OnAddPerson()
        {
            People.Add(new Person(Text));
        }
    }
}
