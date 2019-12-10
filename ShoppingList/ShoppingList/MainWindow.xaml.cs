using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace ShoppingList
{

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            var vm = new MainWindowViewModel();
            DataContext       = vm;
            Vm                = vm;
            RemoveItemCommand = vm.RemoveItemCommand;
            InitializeComponent();
        }

        private MainWindowViewModel Vm { get; }

        public Command RemoveItemCommand { get; }

        private void Card_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            var card = (Card) sender;
            card.Background      = Brushes.LightGray;
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Card_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            var card = (Card) sender;
            card.Background      = Brushes.WhiteSmoke;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void AddButton_OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            var button = (Button) sender;
            button.Background    = Brushes.Green;
            button.BorderBrush   = Brushes.Black;
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void AddButton_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (sender == null) return;
            var button = (Button) sender;
            button.Background    = Brushes.LimeGreen;
            button.BorderBrush   = Brushes.Green;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var item  = (sender as FrameworkElement)?.DataContext;
            var index = Items.Items.IndexOf(item ?? throw new ArgumentNullException(nameof(sender)));
            Vm.SelectedIndex = index;
        }

    }

}
