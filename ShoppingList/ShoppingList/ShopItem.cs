namespace ShoppingList
{
    internal class ShopItem
    {
        internal string Text { get; }

        internal ShopItem(string Text)
        {
            this.Text = Text ?? "";
        }
    }
}