using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox {
    public struct Person : IEquatable<Person> {
        public string _FirstName { get; }
        public string _LastName { get; }

        public Person(string firstName, string lastName) {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public bool Equals([AllowNull] Person other) {
            return this.toString().Equals(other.toString());
        }

        public string toString() {
            return $"{_FirstName} {" "} {_LastName}";
        }
    }
}