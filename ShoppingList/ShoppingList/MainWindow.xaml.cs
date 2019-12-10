using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModelLocator ViewModel { get; }
        public MainWindow()
        {
            ViewModel = new ViewModelLocator();
            InitializeComponent();
        }

        private void TextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox? source = e.Source as TextBox;

            if (source != null)
            {
                source.Background = Brushes.Aquamarine;

                source.Clear();
            }
        }

        private void TextBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox? source = e.Source as TextBox;

            if (source != null)
            {
                source.Background = Brushes.White;
            }
        }

        private void ShoppingListListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
