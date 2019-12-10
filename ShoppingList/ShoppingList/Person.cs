using System;

namespace ShoppingList
{
    public class Person
    {
        public Person(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            //DOB = DateTime.Now.Subtract(TimeSpan.FromDays(30 * 365));
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}