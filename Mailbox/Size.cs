using System;
using System.ComponentModel;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Default = 0b_0000,
        Premium = 0b_1000,
        Small = 0b_0001,
        Medium = 0b_0010,
        Large = 0b_0100,
        LargePremium = Large | Premium,
        MediumPremium = Medium | Premium,
        SmallPremium = Small | Premium
    }
}
