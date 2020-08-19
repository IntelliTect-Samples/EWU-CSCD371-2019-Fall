using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        public bool Equals(Person other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override bool Equals([AllowNull] object obj)
        {
            return obj is Person && Equals((Person)obj);
        }

        public static bool operator ==(Person left, Person right)
        {
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

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }
    }

}