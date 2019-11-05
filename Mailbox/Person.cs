using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string _FirstName, string _LastName)
        {
            FirstName = _FirstName;
            LastName = _LastName;
        }


        public bool Equals([AllowNull] Person other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return Equals(obj as Person?);
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public static bool operator ==(Person a, Person b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Person a, Person b) => !(a == b);
    }
}