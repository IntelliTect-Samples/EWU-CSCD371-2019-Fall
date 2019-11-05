using System;

namespace Mailbox
{
    [Flags]
    public enum Size 
    {
        Default,
        Small = 1,
        Medium = 2,
        Large = 4,
        Premium = 8
    }

}
