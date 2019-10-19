namespace Inheritance
{
    public class Television : Item
    {
        public string Size { get; set; }
        public string Manufacturer { get; set; }

        public override string PrintInfo() => $"{Manufacturer} - {Size}";
    }
}