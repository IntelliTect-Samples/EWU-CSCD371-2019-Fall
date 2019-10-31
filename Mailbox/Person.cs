using System;

namespace Mailbox
{
    /*
     * Create a new Person struct
     * A person has a first and last name
     * Person should implement IEquatable<Person>
     * Ensure appropriate equality operators are also written
     * Implement a reasonable ToString method
     */
    public struct Person : IEquatable<Person>
    {
        public string? FirstName;
        public string? LastName;

        public Person(string firstName, string lastName)
        {
            if (firstName is null)
                throw new ArgumentNullException($"{nameof(firstName)} cannot be null.");
            if (lastName is null)
                throw new ArgumentNullException($"{nameof(lastName)} cannot be null.");

            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
                return this.Equals((Person)obj);
            return false;
        }

        public override int GetHashCode() =>
            (FirstName, LastName).GetHashCode();

        public bool Equals(Person other) =>
            (this.FirstName==other.FirstName &&
             this.LastName==other.LastName);

        public static bool operator ==(Person lhs, Person rhs) =>
            lhs.Equals(rhs);

        public static bool operator !=(Person lhs, Person rhs) =>
            !(lhs.Equals(rhs));

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
