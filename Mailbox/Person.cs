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
        public string _FirstName { get; }
        public string _LastName { get; }

        public Person(string firstName, string lastName)
        {
            _FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            _LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public bool Equals(Person other)
        {
            return _FirstName == other._FirstName &&
                   _LastName == other._LastName;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person?);
        }

        public override int GetHashCode() => (_FirstName, _LastName).GetHashCode();

        public static bool operator ==(Person? a, Person? b) => a.Equals(b);
        
        public static bool operator !=(Person? a, Person? b) => !a.Equals(b);

        public override string ToString()
        {
            return $"{_FirstName} {_LastName}";
        }
    }
}
