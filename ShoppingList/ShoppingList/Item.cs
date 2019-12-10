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
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentNullException(nameof(name));
            } else
            {
                Name = name;
            }
        }
    }
}
