using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
//comment put here to enable pull request, delete later
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

        public event EventHandler CanExecuteChanged;
    }
}
