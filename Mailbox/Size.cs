using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Default = 0,
        Small = 1 << 0,
        Medium = 1 << 1,
        Large = 1 << 2,
        Premium = 1 << 3,

        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium
    }
}
