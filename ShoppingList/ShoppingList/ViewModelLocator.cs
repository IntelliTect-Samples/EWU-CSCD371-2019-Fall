using GalaSoft.MvvmLight.Ioc;

namespace ShoppingList
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel mainWindow => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
    }
}
