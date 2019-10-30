using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Default = 0,
        Small = 2,
        Premium = 2,
        Medium = 4,
        Large = 8
    }
}
