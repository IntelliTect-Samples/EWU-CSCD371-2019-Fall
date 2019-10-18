namespace Inheritance
{
    public class Food : Item
    {
        public string Upc { get; set; }
        public string Brand { get; set; }
        public override string PrintInfo() => $"<{Upc}> - <{Brand}>";
    }
}
