using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox {
    public struct Person : IEquatable<Person> {
        public string _FirstName;
        public string _LastName;

        public Person(string firstName, string fastName) {
            _FirstName = firstName;
            _LastName = fastName;
        }

        public bool Equals([AllowNull] Person other) {
            return toString().Equals(other.toString());
        }

        public string toString() {
            return $"{_FirstName} {_LastName}";
        }
    }
}