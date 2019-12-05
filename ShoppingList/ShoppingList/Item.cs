namespace ShoppingList
{
    public class Item
    {
        public string Text { get; set; }
        public Item() => Text = "";
        public Item(string text) => Text = text;
    }
}
