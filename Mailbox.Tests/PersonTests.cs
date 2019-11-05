using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Equal_Return_True()
        {
            List<Person> people = listOfPeople();

            Assert.IsTrue(people[0].Equals(people[3]));
            Assert.IsTrue(people[0] == people[3]);
            Assert.IsTrue(people[0] != people[1]);
        }

        [TestMethod]
        public void Equal_Return_False()
        {
            List<Person> people = listOfPeople();

            Assert.IsFalse(people[0].Equals(people[1]));
            Assert.IsFalse(people[1].Equals(people[4]));
            Assert.IsFalse(people[2] == people[3]);
            Assert.IsFalse(people[0] != people[3]);
        }

        private List<Person> listOfPeople()
        {
            List<Person> people = new List<Person>
            {
                new Person() { FirstName = "Bob", LastName = "Jones"},
                new Person() { FirstName = "Steven", LastName = "Bills"},
                new Person() { FirstName = "John", LastName = "Doe"},
                new Person() { FirstName = "Bob", LastName = "Jones"},
                new Person() { FirstName = "Steven", LastName = "Jones"}
            };

            return people;
        }
    }
}
