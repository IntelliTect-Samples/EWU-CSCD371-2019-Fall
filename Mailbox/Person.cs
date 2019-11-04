using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
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
    }
}