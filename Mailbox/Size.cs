using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        None = 0b0000,
        Small = 0b0001,
        Medium = 0b0010,
        Large = 0b0100,
        Premium = 0b1000,
        // not adding premade combos like LargePremium, as it throws off the getstring method below
    }

    public static class SizeExtension
    {
        public static string GetString(this Sizes size)
        {
            if (size == Sizes.None) return "";

            return size.ToString().Replace(",", null);
        }

        // removes extraneous flags that dont make sense together
        // prioritizes largest size, strips off smaller sizes, preserves premium state
        public static Sizes Verify(this Sizes size)
        {
            if (size.HasFlag(Sizes.Large))
            {
                return size & (Sizes.Large | Sizes.Premium);
            }
            else if (size.HasFlag(Sizes.Medium))
            {
                return size & (Sizes.Medium | Sizes.Premium);
            }
            else if (size.HasFlag(Sizes.Small))
            {
                return size & (Sizes.Small | Sizes.Premium);
            }

            return Sizes.None;
        }
    }
}