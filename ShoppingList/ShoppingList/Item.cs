using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
