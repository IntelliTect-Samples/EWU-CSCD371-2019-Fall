﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public class Person : IEquatable<Person>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Person(string lastName, string firstName)
        {
            if(lastName.Equals(null) || firstName.Equals(null))
            {
                throw new ArgumentNullException("The name can not be null");
            }

            LastName = lastName;
            FirstName = firstName;
        }

        public override bool Equals(object obj)
        {
            return obj is Person && Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            return (FirstName,LastName).GetHashCode();
        }

        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public static bool operator ==(Person a, Person b) => (a == b);

        public static bool operator !=(Person a, Person b) => !(a == b);


        public override string ToString()
        {
            return $"{FirstName} {LastName} ";
        }
    }
}