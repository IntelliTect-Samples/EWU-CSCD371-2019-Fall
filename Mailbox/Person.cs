using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{

    public struct Person : IEquatable<Person>
    {
        private string First { get; }
        private string Last { get; }

        public Person(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first))
            {
                throw new System.ArgumentException("First name is null or empty", nameof(first));
            }
            if (string.IsNullOrWhiteSpace(last))
            {
                throw new System.ArgumentException("Last name is null or empty", nameof(last));
            }

            First = first;
            Last = last;
        }

        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return First == other.First && Last == other.Last;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public static bool operator ==(Person a, Person b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Person a, Person b)
        {
            return !(a == b);
        }

        public string toString()
        {
            return $"{First} {Last}";
        }
    }

}