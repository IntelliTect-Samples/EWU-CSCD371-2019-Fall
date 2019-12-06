using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShoppingItem
    {
        public string ItemName { get; set; }

        public ShoppingItem(string itemName)
        {
            this.ItemName = itemName;
        }
    }
}
