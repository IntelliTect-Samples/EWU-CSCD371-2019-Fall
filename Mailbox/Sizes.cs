using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Undefined = 0b0000,
        Small     = 0b0001,
        Medium    = 0b0010,
        Large     = 0b0100,
        Premium   = 0b1000,
    }

    public static class SizesExtensions
    {
        public static Sizes Size(this Sizes sizes) => sizes & ~Sizes.Premium;

        public static bool Premium(this Sizes sizes) => sizes.HasFlag(Sizes.Premium);

        public static bool IsValid(this Sizes sizes) =>
            (sizes &= ~Sizes.Premium) != Sizes.Undefined &&
            ((sizes & Sizes.Small)    == Sizes.Small ^
             (sizes & Sizes.Medium)   == Sizes.Medium ^
             (sizes & Sizes.Large)    == Sizes.Large);
    }
}
