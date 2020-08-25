using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        public void Mailboxes_ConstructorCreates()
        {
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            List<Mailbox> mailboxList = new List<Mailbox>()
            {
                new Mailbox(Sizes.Large, (2,3), person)
            };
            var value = new Mailboxes(mailboxList, 30, 10);

            Assert.AreEqual(1, value.Count);
            Assert.AreEqual(30, value.Width);
            Assert.AreEqual(10, value.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Mailboxes_ConstructorNullList()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Mailboxes? _ = new Mailboxes(null, 1, 1);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }



        [TestMethod]
        public void Mailboxes_GetAdjacent_OccupiedReturnsTrue()
        {
            Person person = new Person()
            {
                FirstName = "Scott",
                LastName = "Rowland"
            };
            List<Mailbox> mailboxList = new List<Mailbox>()
            {
                new Mailbox(Sizes.Large, (2,3), person)
            };
            var value = new Mailboxes(mailboxList, 30, 10);

            //Act
            bool result = value.GetAdjacentPeople(2, 3, out HashSet<Person> _);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Mailboxes_GetAdjacent_PeopleMatch()
        {
            //Setup a cross of people
            var person1 = new Person() { FirstName = "person1", LastName = "person1" };
            var person2 = new Person() { FirstName = "person2", LastName = "person2" };
            var person3 = new Person() { FirstName = "person3", LastName = "person3" };
            var person4 = new Person() { FirstName = "person4", LastName = "person4" };

            /*
             *          person1
             *  person2 TESTING person3
             *          person4
             */

            Mailbox mailbox1 = new Mailbox(Sizes.Small, (1, 0), person1);
            Mailbox mailbox2 = new Mailbox(Sizes.Small, (0, 1), person2);
            Mailbox mailbox3 = new Mailbox(Sizes.Small, (2, 1), person3);
            Mailbox mailbox4 = new Mailbox(Sizes.Small, (1, 2), person4);

            var mailboxList = new List<Mailbox>()
            {
                mailbox1,
                mailbox2,
                mailbox3,
                mailbox4
            };

            var mailboxes = new Mailboxes(mailboxList, 10, 10);


            //Act
            bool occupied = mailboxes.GetAdjacentPeople(1, 1, out HashSet<Person> adjacentPeople);


            //Assert
            Assert.IsFalse(occupied);
            Assert.AreEqual(mailboxList.Count, adjacentPeople.Count);
            
            for (int i = 0; i < mailboxList.Count; i++)
            {
                Assert.IsTrue(adjacentPeople.Contains(mailboxList[i].Owner));
            }

        }
    }
}
