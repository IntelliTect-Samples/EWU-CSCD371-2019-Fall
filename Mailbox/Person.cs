using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        string _FirstName;
        string _LastName;

        public Person(string fname, string lname)
        {
            if(fname is null)
            {
                throw new ArgumentNullException(nameof(_FirstName));
            }
            if(lname is null)
            {
                throw new ArgumentNullException(nameof(_LastName));
            }
            _FirstName = fname;
            _LastName = lname;
        }

        public bool Equals([AllowNull] Person other)
        {
            if(ReferenceEquals(other, null))
            {
                return false;
            }

            return _FirstName == other._FirstName && _LastName == other._LastName;
        }

        public override string ToString()
        {
            return $"{_LastName}, {_FirstName}";
        }
    }

}