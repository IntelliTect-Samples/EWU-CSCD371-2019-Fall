using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShopItem
    {
        public string Name { get; set; }

        public ShopItem(string name)
        {
            Name = name;
        }
    }
}