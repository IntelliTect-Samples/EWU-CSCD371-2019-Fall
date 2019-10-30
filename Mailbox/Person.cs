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
            return false;
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
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
    }
}