
using System.Windows;

namespace ShoppingList
{
    public partial class MainWindow : Window
    {
		public ViewModelLocator ViewModel { get; }
		
        public MainWindow()
        {
			ViewModel = new ViewModelLocator();
            InitializeComponent();
        }

		private void TextBoxGotKeyboardFocus(object sender,
				System.Windows.Input.KeyboardFocusChangedEventArgs e)
		{
			ViewModel.mainWindow.SelectedItem = null;
		}
    }
}
