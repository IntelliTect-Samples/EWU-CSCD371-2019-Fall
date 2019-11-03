using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        string firstName;
        string lastName;
        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return firstName == other.firstName
                && lastName == other.lastName;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }
    }
}