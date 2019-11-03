using System;
using System.Diagnostics.CodeAnalysis;

namespace MailRoom
{
    public readonly struct Person : IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public bool Equals(Person other) => LastName.Equals(other.LastName) && FirstName.Equals(other.FirstName);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;

            return Equals((Person) obj);
        }

        public static bool operator ==(Person leftSide, Person rightSide)
        {
            return leftSide.Equals(rightSide);
        }

        public static bool operator !=(Person leftSide, Person rightSide)
        {
            return !(leftSide.Equals(rightSide));
        }

        public override int GetHashCode() => (FirstName, LastName).GetHashCode();

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}