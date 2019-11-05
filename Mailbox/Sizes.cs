using System;

namespace Mailbox
{
    [Flags]
    public enum Sizes
    {
        Undefined = 0b0000,
        Small     = 0b0001,
        Medium    = 0b0010,
        Large     = 0b0100,
        Premium   = 0b1000,
    }
}
