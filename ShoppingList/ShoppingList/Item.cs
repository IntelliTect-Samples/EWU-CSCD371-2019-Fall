namespace ShoppingList
{
    public class Item
    {
        public string Name { get; set; } = "";

        public Item(string name)
        {
            Name = name;
        }

        public Item()
        {
            Name = "";
        }
    }
}