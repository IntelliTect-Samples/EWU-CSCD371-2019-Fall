using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        string FirstName;
        string LastName;

        public bool Equals([AllowNull] Person other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }

}