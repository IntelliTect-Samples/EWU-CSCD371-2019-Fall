using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Default = 0,
        Small = 1 << 1,
        Medium = 1 << 2,
        Large = 1 << 3,
        Premium = 1 << 4,
        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium
    }
}
