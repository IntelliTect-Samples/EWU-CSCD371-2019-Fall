using System;
namespace Inheritance
{
    public class Television : Item
    {
        public string? Size { get; set; }
        public string? Manufacturer { get; set; }

        public string PrintInfo() => (Manufacturer, Size) switch
        {
            (null, _) => throw new ArgumentNullException(nameof(Manufacturer)),
            (_, null) => throw new ArgumentNullException(nameof(Size)),
            (_, _) => $"<{Manufacturer}> - <{Size}>"
        };
    }
}
