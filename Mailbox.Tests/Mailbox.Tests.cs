using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(31)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mailbox_Row_RowOutOfBounds(int row)
        {
            Size size = Size.Small;
            ValueTuple<int, int> loc = new ValueTuple<int, int>(row, 1);
            Person person = new Person("Jimmy", "John");
            new Mailbox(size, loc, person);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(11)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Mailbox_Column_ColumnOutOfBounds(int column)
        {
            Size size = Size.Small;
            ValueTuple<int, int> loc = new ValueTuple<int, int>(1, column);
            Person person = new Person("Jimmy", "John");
            new Mailbox(size, loc, person);
        }
    }
}
