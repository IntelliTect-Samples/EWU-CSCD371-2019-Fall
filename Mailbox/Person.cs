using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox {
    public struct Person : IEquatable<Person> {
        public string _FirstName { get; }
        public string _LastName { get; }

        public Person(string _FirstName, string _LastName) {
            this._FirstName = _FirstName;
            this._LastName = _LastName;
        }

        public bool Equals([AllowNull] Person other) {
            return this.toString().Equals(other.toString());
        }

        public string toString() {
            return $"{_FirstName} {" "} {_LastName}";
        }
    }
}