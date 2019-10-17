namespace Inheritance {
    public class Television : Item {
        public double Size { get; set; }
        public string Manufacturer { get; set; }
        public override string PrintInfo() {
            return Manufacturer + " - " + Size;
        }
    }
}