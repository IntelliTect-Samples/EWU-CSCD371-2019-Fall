using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override bool Equals(object? obj)
        {
            return obj is Person && Equals((Person)obj);
        }

        public Person(string? firstName, string? lastName)
        {
            if (firstName is null)
                throw new ArgumentNullException(nameof(firstName));
            else if (lastName is null)
                throw new ArgumentNullException(nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
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

        public override string ToString() => $"{FirstName} {LastName}";
    }
}