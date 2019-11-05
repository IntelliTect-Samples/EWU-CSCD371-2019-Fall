using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Default = 0,
        Small = 1,
        Medium = 2,
        Large = 3,
        Premium = 4,

        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium
    }
}