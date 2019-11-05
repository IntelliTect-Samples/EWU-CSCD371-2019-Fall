using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person>
    {
        public string fname;
        public string lname;

        public Person(string f, string l)
        {
            if (f is null || l is null) throw new ArgumentNullException();
            fname = f; lname = l;
        }

        public bool Equals(Person other)
        {
            if(other.lname.ToLower().Equals(lname.ToLower()) && other.fname.ToLower().Equals(fname.ToLower()))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return fname + " " + lname;
        }
    }
}