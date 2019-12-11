namespace ShoppingList {
    public class Item {
        private string Name { get; set; }

        public Item(string text) {
            Name = text;
        }

        public override string ToString() {
            return Name;
        }
    }
}