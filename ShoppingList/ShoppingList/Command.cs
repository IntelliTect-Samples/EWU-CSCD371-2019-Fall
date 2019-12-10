using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ShoppingList
{
    public class Command : ICommand
    {
        private Action Method { get; }
        public Func<bool> CanExecuteMethod { get; }

        public Command(Action method, Func<bool> canExecute = null)
        {
            Method = method ?? throw new ArgumentNullException(nameof(method));
            CanExecuteMethod = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) => Method?.Invoke();

        public event EventHandler CanExecuteChanged;

        public void InvokeCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
