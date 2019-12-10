using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class Item
    {
        public string ItemName { get; set; }

        public Item() => ItemName = "";

        public Item(string itemName) => ItemName = itemName;
        
    }
}
