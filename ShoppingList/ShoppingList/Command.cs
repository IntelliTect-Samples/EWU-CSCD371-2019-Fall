using System;
using System.Windows.Input;

namespace ShoppingList
{

    public class Command : ICommand
    {

        public Command(Action method)
        {
            Method = method ?? throw new ArgumentNullException(nameof(method));
        }

        private Action Method { get; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Method?.Invoke();
        }

        public event EventHandler CanExecuteChanged;

    }

}
