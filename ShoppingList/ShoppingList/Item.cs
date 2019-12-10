using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
