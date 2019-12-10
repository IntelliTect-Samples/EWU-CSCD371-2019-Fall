using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShoppingItem
    {
        public ShoppingItem(string name)
        {
            Name = "~" + name;
        }

        public string Name { get; set; }
    }
}
