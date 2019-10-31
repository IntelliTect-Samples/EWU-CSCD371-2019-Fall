using System;

namespace Mailbox
{
    /*
     * Create a new flagged Size enum.
     * Ensure it has a reasonable default value
     * It should have values for Small, Medium, Large
     * All sizes should be able to be flagged as Premium
     *
     */
    [Flags]
    public enum Size
    {
        Small 	 = 1<<0,
        Medium 	 = 1<<1,
        Large 	 = 1<<2,
        Premium  = 1<<3,
        SizeMask = 0xF>>1,
    }
}
