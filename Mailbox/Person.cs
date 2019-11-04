using System;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string? firstName, string? lastName)
        {
            FirstName = firstName ?? "DefaultFirst";
            LastName = lastName ?? "DefaultLast";
        }

        public bool Equals(Person other) => (FirstName, LastName) == (other.FirstName, other.LastName);

        public override bool Equals(object? obj) => (obj is Person other) && Equals(other);

        public override int GetHashCode() => (FirstName, LastName).GetHashCode();

        public override string ToString() => $"{FirstName} {LastName}";

        public static bool operator ==(Person left, Person right) => left.Equals(right);

        public static bool operator !=(Person left, Person right) => !(left == right);
    }
}
