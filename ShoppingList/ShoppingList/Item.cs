namespace ShoppingList
{
    public class Item : BaseNotifyPropertyChanged
    {
        private string _ItemName = "";
        public string ItemName
        {
            get => _ItemName;
            set => SetProperty(ref _ItemName, value);
        }


        private int _ItemQuantity = 1;
        public int ItemQuantity
        {
            get => _ItemQuantity;
            set => SetProperty(ref _ItemQuantity, value);
        }
    }
}
