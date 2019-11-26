using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment {
    public interface IPerson {
        string FirstName { get; }
        string LastName { get; }
        string EmailAddress { get; }
        IAddress Address { get; }
    }
}
