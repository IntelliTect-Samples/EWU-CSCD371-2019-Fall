using System;

namespace Mailbox
{
    /*
     * Create a new flagged Size enum.
     * Ensure it has a reasonable default value
     * It should have values for Small, Medium, Large
     * All sizes should be able to be flagged as Premium
     *
     */
    [Flags]
    public enum Size
    {
        Small 	 = 1<<0,
        Medium 	 = 1<<1,
        Large 	 = 1<<2,
        Premium  = 1<<3,
        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium,
        SizeMask = 0xF>>1,
    }

    public static class SizeMixins
    {
        public static Size Parse(string inputString) =>
            inputString.ToLower() switch
            {
                "small" 			=> Size.Small,
                "medium" 			=> Size.Medium,
                "large" 			=> Size.Large,
                "small|premium" 	=> Size.SmallPremium,
                "medium|premium" 	=> Size.MediumPremium,
                "large|premium" 	=> Size.LargePremium,
                _                   => Size.Small
            };
    }
}
