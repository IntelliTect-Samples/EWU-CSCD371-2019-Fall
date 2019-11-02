using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        undefined = 0,
        small = 1,
        medium = 2,
        large = 4,
        premium = 8
    }
}
