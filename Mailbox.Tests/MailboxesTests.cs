using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests {
    [TestClass]
    public class MailboxesTests {
        [TestMethod]
        public void FindValidLocation_DoesntPutPeopleWithSameNamesNextToEachOther() { //Holy method name batman
            //Arrange
            Mailboxes mailboxes = new Mailboxes(new Mailbox[3, 3]);
            Person person = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[3, 3];
            expected[0, 0] = new Mailbox(new Sizes(), (0, 0), person);
            expected[2, 2] = new Mailbox(new Sizes(), (0, 0), person);

            //Act
            while (!mailboxes.FindValidLocation(person).Equals((-1, -1))) {
                (int, int) temp = mailboxes.FindValidLocation(person);
                mailboxes.MailboxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, person);
            }

            //Assert
            Assert.AreEqual(expected.ToString(), mailboxes.MailboxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_ReturnsNegativeIfNoValidLocation() {
            //Arrange
            Mailboxes mailboxes = new Mailboxes(new Mailbox[0, 0]);

            //Act

            //Assert
            Assert.AreEqual((-1, -1), mailboxes.FindValidLocation(new Person("test", "test")));
        }

        [TestMethod]
        public void FindValidLocation_WorksForTallArraySize() {
            //Arrange
            Mailboxes tall = new Mailboxes(new Mailbox[1, 20]);
            Person person = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[1, 20];
            for (int i = 0; i < expected.Length; i += 2) {
                expected[0, i] = new Mailbox(new Sizes(), (0, i), person);
            }

            //Act
            while (!tall.FindValidLocation(person).Equals((-1, -1))) {
                (int, int) temp = tall.FindValidLocation(person);
                tall.MailboxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, person);
            }

            //Assert
            Assert.AreEqual(expected.ToString(), tall.MailboxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_WorksForLongArraySize() {
            //Arrange
            Mailboxes lengthy = new Mailboxes(new Mailbox[20, 1]);
            Person person = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[20, 1];
            for (int i = 0; i < expected.Length; i += 2) {
                expected[i, 0] = new Mailbox(new Sizes(), (i, 0), person);
            }

            //Act
            while (!lengthy.FindValidLocation(person).Equals((-1, -1))) {
                (int, int) temp = lengthy.FindValidLocation(person);
                lengthy.MailboxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, person);
            }

            //Assert
            Assert.AreEqual(expected.ToString(), lengthy.MailboxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_WorksForTinyArraySize() {
            //Arrange
            Mailboxes tiny = new Mailboxes(new Mailbox[1, 1]);
            Person person = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[1, 1];
            expected[0, 0] = new Mailbox(new Sizes(), (0, 0), person);

            //Act
            while (!tiny.FindValidLocation(person).Equals((-1, -1))) {
                (int, int) temp = tiny.FindValidLocation(person);
                tiny.MailboxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, person);
            }

            //Assert
            Assert.AreEqual(expected.ToString(), tiny.MailboxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_WorksForMassiveArraySize() {
            //Arrange
            Mailboxes massive = new Mailboxes(new Mailbox[100, 100]);
            Person person = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[100, 100];
            for (int i = 0; i < expected.GetLength(0); i += 2) {
                for (int j = i % 2; j < expected.GetLength(1); j += 2) {
                    expected[i, j] = new Mailbox(new Sizes(), (i, j), person);
                }
            }

            //Act
            while (!massive.FindValidLocation(person).Equals((-1, -1))) {
                (int, int) temp = massive.FindValidLocation(person);
                massive.MailboxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, person);
            }

            //Assert
            Assert.AreEqual(expected.ToString(), massive.MailboxesArray.ToString());
        }
    }
}
