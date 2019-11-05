using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Unspecified = 0b_0000,
        Small = 0b_001,
        Medium = 0b_010,
        Large = 0b_100,
        Premium = 0b_0000,

        PremiumSmall = Small | Premium,
        PremiumMedium = Medium | Premium,
        PremiumLarge = Large | Premium
    }
}
