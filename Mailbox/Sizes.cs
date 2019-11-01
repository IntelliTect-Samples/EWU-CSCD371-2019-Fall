using System;

namespace Mailbox {
    [Flags]
    public enum Sizes {
        Default = 0b_0000,
        Small = 0b_0001,
        Medium = 0b_0010,
        Large = 0b_0100,
        Premium = 0b_1000,

        SmallPremium = Small + Premium,
        MediumPremium = Medium + Premium,
        LargePremium = Large + Premium
    }
}