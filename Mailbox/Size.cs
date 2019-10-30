using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Unset = 0,
        Small = 1,
        Medium = 2,
        Large = 4,
        Premium = 8
    }

}
