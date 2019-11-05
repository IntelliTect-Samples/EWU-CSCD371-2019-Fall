using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
#pragma warning disable CA1067 // Override Object.Equals(object) when implementing IEquatable<T>
    public struct Person : IEquatable<Person>
#pragma warning restore CA1067 // Override Object.Equals(object) when implementing IEquatable<T>
    {
        private string? FirstName { get; set; }
        private string? LastName { get; set; }

        public Person(String? firstName, String? lastName)
        {
            if(firstName is null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }
            else if(lastName is null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(Person other)
        {
            if(LastName == other.LastName)
            {
                if(FirstName == other.FirstName)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
        }

        public static bool operator ==(Person left, Person right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
    }
}