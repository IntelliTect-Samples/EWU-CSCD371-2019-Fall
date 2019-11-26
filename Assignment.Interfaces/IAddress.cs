using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public interface IAddress
    {
        string StreetAddress { get; }
        string City { get; }
        string State { get; }
        string Zip { get; }

        bool Equal(IAddress address);
    }
}
