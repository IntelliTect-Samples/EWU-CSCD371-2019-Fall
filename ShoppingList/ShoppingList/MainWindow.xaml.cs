
using System.Windows;

namespace ShoppingList
{
    public partial class MainWindow : Window
    {
		public ViewModel ViewModel { get; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
			ViewModel = new ViewModel();
        }

		private void TextBoxGotKeyboardFocus(object sender,
				System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			ViewModel.MainWindow.SelectedItem = null;
		}
    }
}
