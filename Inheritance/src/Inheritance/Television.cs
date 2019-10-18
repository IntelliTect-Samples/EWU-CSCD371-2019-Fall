namespace Inheritance
{
    public class Television : Item
    {
        public string Manufacturer { get; set; }
        public string Size { get; set; }

        public override string PrintInfo()
        {
            return this.Manufacturer + " - " + this.Size;
        }
    }
}