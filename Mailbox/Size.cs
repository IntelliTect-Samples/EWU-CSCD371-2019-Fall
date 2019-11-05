using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Undeclared = 0,
        Small = 1,
        Medium = 2,
        Large = 4,
        Premium = 8,

        SmallPremium = Small | Premium,
        MediumPremium = Medium | Premium,
        LargePremium = Large | Premium

    }
    public static class SizeExtensions
    {
        public static bool IsValid(this Sizes sizes) =>
            sizes == Sizes.Small ^ sizes == Sizes.Medium ^
            sizes == Sizes.Large ^ sizes == Sizes.SmallPremium ^
            sizes == Sizes.MediumPremium ^ sizes == Sizes.LargePremium ^
            sizes == Sizes.Undeclared;
    }
}
