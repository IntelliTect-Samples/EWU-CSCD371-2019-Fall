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
            if (firstName is null || lastName is null)
                throw new ArgumentNullException($"{nameof(firstName)}, {nameof(lastName)}");
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool Equals([AllowNull] Person other)
        {
            if (other.firstName.Equals(this.firstName) && other.lastName.Equals(this.lastName))
                return true;
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (obj is Person newPerson)
                return (this.Equals(newPerson));
            return true;
        }

        public override int GetHashCode()
        {
            return (this.firstName, this.lastName).GetHashCode();
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