using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        private (string firstName, string lastName) name;

        public Person(string firstName, string lastName)
        {
            if (firstName is null) { throw new ArgumentNullException(firstName, nameof(firstName) + " may not be null"); }
            if (lastName is null) { throw new ArgumentNullException(lastName, nameof(lastName) + " may not be null"); }

            name.firstName = firstName;
            name.lastName = lastName;
        }
        public bool Equals(Person other)
        {
            return name.firstName == other.getName().first
                && name.lastName == other.getName().last;
        }

        public override bool Equals(object? other)
        {
            if (other is null) { return false; }

            return Equals(other as Person?);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        private (string first, string last) getName()
        {
            return name;
        }

        public static bool operator ==(Person a, Person b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Person a, Person b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"{name.lastName}, {name.firstName}";
        }
    }
}