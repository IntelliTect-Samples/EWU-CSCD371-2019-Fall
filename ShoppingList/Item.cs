namespace ShoppingList
{
    public class Item
    {
        public string Name { get; set; } = "New Item";

        public override bool Equals(object? obj) =>
            obj is Item item && Name == item.Name;

        public override int GetHashCode() =>
            Name.GetHashCode();
    }
}