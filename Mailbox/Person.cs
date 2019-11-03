using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName;
        public string LastName;

        public Person(string fname, string lname)
        {
            if(fname is null)
            {
                throw new ArgumentNullException(nameof(FirstName));
            }
            if(lname is null)
            {
                throw new ArgumentNullException(nameof(LastName));
            }
            FirstName = fname;
            LastName = lname;
        }

        public bool Equals([AllowNull] Person other)
        {
            if(ReferenceEquals(other, null))
            {
                return false;
            }

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }

}