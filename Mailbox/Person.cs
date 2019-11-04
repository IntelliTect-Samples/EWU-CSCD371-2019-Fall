using System;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName;
        public string LastName;

        public Person(string? firstName, string? lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public bool Equals(Person other)
        {
            if (other.FirstName.Equals(FirstName) && other.LastName.Equals(LastName))
                return true;
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (obj is Person newPerson)
                return (Equals(newPerson));
            return false;
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

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}