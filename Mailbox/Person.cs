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

        public override bool Equals(Object obj) 
        {
            return obj is Person ? this.Equals((Person)obj) : false;
        }

        public static bool operator ==(Person person, Person other) => person.Equals(other);
        public static bool operator !=(Person person, Person other) => person.Equals(other);

        public override string ToString()
        {
            return $"{firstName} {lastName}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(firstName, lastName);
        }
    }
}