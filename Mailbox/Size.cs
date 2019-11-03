using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Undeclared = 0,
        Small = 1,
        Medium = 2,
        Large = 4
    }
}
