namespace ShoppingList
{

    public class Item
    {

        public string Name   { get; set; }
        public int    Amount { get; set; } = 1;

        public string GetAmountString => Amount == 1 ? "" : "x " + Amount;

    }

}
