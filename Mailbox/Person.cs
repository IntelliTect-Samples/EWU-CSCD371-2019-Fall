using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox {
    public struct Person : IEquatable<Person> {
        private string FirstName;
        private string LastName;

        public Person(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals([AllowNull] Person other) {
            return this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName);
        }

        public string toString() {
            return $"{this.FirstName} {" "} {this.LastName}";
        }
    }
}