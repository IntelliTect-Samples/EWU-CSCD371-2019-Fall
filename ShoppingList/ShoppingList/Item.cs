using System;

namespace ShoppingList
{
    public struct Item
    {
        public string Name;

        public Item(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
