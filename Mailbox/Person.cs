using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals([AllowNull] Person other)
        {
            if (other.Equals(null) || other.FirstName is null || other.LastName is null || FirstName is null || LastName is null)
                return false;

            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person other)
                return Equals(other);

            return false;
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }

        public static bool operator ==(Person left, Person right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null)) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}