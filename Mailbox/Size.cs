using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Undefined = 0,
        Small = 1,
        Medium = 2,
        Large = 4,
        Premium = 8,

        SmallPremium = Small | Premium,
        MediumPremium = Small | Premium,
        LargePremium = Small | Premium
    }
}
