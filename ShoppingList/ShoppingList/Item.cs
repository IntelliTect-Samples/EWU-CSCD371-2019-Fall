using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Item(string name, int price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }
    }
}
