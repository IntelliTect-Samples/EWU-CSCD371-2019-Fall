using System;
using System.Windows.Input;

namespace ShoppingList
{
    public class Command : ICommand
    {
        private Action Method { get; }

        public Command(Action method)
        {
            Method = method ?? throw new ArgumentNullException(nameof(method));
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => Method?.Invoke();

#pragma warning disable CS0067 // part of ICommand, unused in this instance but required to be defined.
        public event EventHandler? CanExecuteChanged;
    }
}
