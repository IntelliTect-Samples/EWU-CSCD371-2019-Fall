using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{

    public struct Person : IEquatable<Person>
    {

        public string? FirstName { get; }
        public string? LastName  { get; }

        public Person(string? firstName, string? lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName  = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public bool Equals([NotNull] Person other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override string ToString() => $"{LastName}, {FirstName}";

    }

}
