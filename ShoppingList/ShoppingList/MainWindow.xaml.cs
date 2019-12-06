using System.Windows;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        private void AddItemEvent(object? sender, RoutedEventArgs? e)
        {
            ((MainWindowViewModel) DataContext).AddItemCommand.Execute(null);
            FocusItemEditorEvent(null, null);
        }

        private void FocusItemEditorEvent(object? sender, RoutedEventArgs? e)
        {
            ItemEditor.Focus();
            ItemEditor.CaretIndex = ItemEditor.Text.Length;
        }

        private void DeselectEvent(object? sender, RoutedEventArgs? e)
            => ((MainWindowViewModel) DataContext).DeselectCommand.Execute(null);
    }
}
