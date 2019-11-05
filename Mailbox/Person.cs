/*
#### Person
- Create a new `Person` struct
- A person has a first and last name
- `Person` should implement `IEquatable<Person>`
- Ensure appropriate equality operators are also written
- Implement a reasonable ToString method
    */
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
            FirstName = firstName;
            LastName = lastName;
        }

        public override int GetHashCode() => (FirstName, LastName).GetHashCode();

        public override bool Equals(object? obj)
        {
            if (obj is Person)
                return this.Equals((Person)obj);
            return false;
        }

        public bool Equals(Person other) =>
             (this.FirstName == other.FirstName &&
              this.LastName == other.LastName);

         public static bool operator ==(Person? a, Person? b) => a.Equals(b);

         public static bool operator !=(Person? a, Person? b) => !a.Equals(b);

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
