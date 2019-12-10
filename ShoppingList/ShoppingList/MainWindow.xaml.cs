using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using MaterialDesignThemes.Wpf;

namespace ShoppingList
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowViewModel Vm { get; }

        public Command RemoveItemCommand { get; }

        public MainWindow()
        {
            var vm = new MainWindowViewModel();
            DataContext = vm;
            this.Vm = vm;
            RemoveItemCommand = vm.RemoveItemCommand;
            InitializeComponent();
        }

        private void Card_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Card card = (Card) sender;
                card.Background = Brushes.LightGray;
                Mouse.OverrideCursor = Cursors.Hand;
            }
        }

        private void Card_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Card card = (Card) sender;
                card.Background = Brushes.WhiteSmoke;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private void AddButton_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Button button = (Button) sender;
                button.Background = Brushes.Green;
                button.BorderBrush = Brushes.Black;
                Mouse.OverrideCursor = Cursors.Hand;
            }
        }

        private void AddButton_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                Button button = (Button) sender;
                button.Background = Brushes.LimeGreen;
                button.BorderBrush = Brushes.Green;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = Items.Items.IndexOf(item);
            Vm.SelectedIndex = index;
        }

    }

}