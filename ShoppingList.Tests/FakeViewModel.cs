namespace ShoppingList.Tests
{
    class FakeViewModel : BaseViewModel
    {
        private int _FakeProperty;
        public int FakeProperty
        {
            get => _FakeProperty;
            set => SetProperty(ref _FakeProperty, value);
        }

        public FakeViewModel(int value) => _FakeProperty = value;
    }
}
