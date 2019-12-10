using System;

namespace ShoppingList
{
    public class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}