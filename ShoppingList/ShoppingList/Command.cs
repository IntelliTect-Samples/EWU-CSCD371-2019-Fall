﻿using System;
using System.Collections.Generic;
using System.Text;
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

#pragma warning disable CS0067 //this isn't my code, so I disabled the warning
        public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067

    }
}
