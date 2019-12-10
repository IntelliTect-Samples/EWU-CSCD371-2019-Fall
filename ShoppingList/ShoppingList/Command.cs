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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) => Method?.Invoke();

#pragma warning disable CS0067 // CanExecuteChanged is never used

        public event EventHandler? CanExecuteChanged;

#pragma warning restore CS0067 // Just making the interface work
    }
}