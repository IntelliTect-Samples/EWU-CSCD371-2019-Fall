using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName) 
        {
            FirstName = firstName ?? throw new ArgumentNullException($"First name cannot be null: {nameof(firstName)}");
            LastName = lastName ?? throw new ArgumentNullException($"Last name cannot be null: {nameof(lastName)}");
        }
        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public override bool Equals(Object obj) 
        {
            return obj is Person ? this.Equals((Person)obj) : false;
        }

        public static bool operator ==(Person person, Person other) => person.Equals(other);
        public static bool operator !=(Person person, Person other) => !person.Equals(other);

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}