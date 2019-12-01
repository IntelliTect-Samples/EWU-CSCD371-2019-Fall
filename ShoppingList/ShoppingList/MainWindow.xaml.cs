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
            InitializeComponent();
            DataContext = new ListModel();
        }

        public void listBoxChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        public void AddBtnClick(object sender, RoutedEventArgs e)
        {

        }

        public void ChangeBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
