using System;

namespace MailRoom
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

        public static bool IsValid(this Sizes size)
        {
            // automatically invalid if none or only premium
            if (size == Sizes.None || size == Sizes.Premium) return false;

            // dont care what premium is beyond this point
            if (size.HasFlag(Sizes.Large))
            {
                // valid if large doesn't contain medium or small flags
                return !(size.HasFlag(Sizes.Medium)||size.HasFlag(Sizes.Small));
            }
            else if (size.HasFlag(Sizes.Medium))
            {
                // already checked if it has the large flag; medium valid if doesn't have small
                return !size.HasFlag(Sizes.Small);
            }

            // only small flag, automatically acceptable
            return true;
        }
    }
}
