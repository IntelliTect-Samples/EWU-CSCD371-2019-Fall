using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string firstName;
        public string lastName;

        public Person(string? firstName, string? lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool Equals([AllowNull] Person other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
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
            return $"{this.firstName} {this.lastName}";
        }
    }
}