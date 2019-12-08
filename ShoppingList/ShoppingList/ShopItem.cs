using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShopItem
    {
        public string Name { get; set; }
        public double Price { get; set; }


        public ShopItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}