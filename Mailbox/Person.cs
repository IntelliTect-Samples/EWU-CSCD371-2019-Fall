using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox {
    public struct Person : IEquatable<Person> {
        private string _FirstName { get; }
        private string _LastName { get; }

        public Person(string firstName, string lastName) {
            _FirstName = firstName;
            _LastName = lastName;
        }

        public bool Equals([AllowNull] Person other) {
            return _FirstName.Equals(other._FirstName) && _LastName.Equals(other._LastName);
        }

        public string toString() {
            return $"{_FirstName} {" "} {_LastName}";
        }
    }
}