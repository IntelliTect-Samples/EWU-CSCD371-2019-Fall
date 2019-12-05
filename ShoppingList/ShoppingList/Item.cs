using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class Item
    {
        public string ItemName { get; set; }

        public Item(string name)
        {
            ItemName = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
