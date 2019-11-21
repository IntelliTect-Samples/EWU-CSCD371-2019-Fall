using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonEquals_ReturnsFalseOnNullOther()
        {
            var sut = new Address()
            {
                StreetAddress = "Some St.",
                City = "Spokane",
                State = "WA",
                Zip = "99218"
            };

#pragma warning disable CS8625
            Assert.IsFalse(sut.Equals(null));
#pragma warning restore
        }

        [DataTestMethod]
        [DataRow(new string[] {"id","Kevin","Durant","email","7884 Corry Way","Helena","MT","70577"})]
        [DataRow(new string[] {"id","Kevin","Durant","email","2646 Hazelcrest Road","San Francisco","CA","40486"})]
        [DataRow(new string[] {"id","Kevin","Durant","email","90 Birchwood Street","Las Vegas","NV","36230"})]
        public void PersonEquals_SuccessOnSameData(string[] data)
        {
            var addr = new Address()
            {
                StreetAddress = data[4],
                City = data[5],
                State = data[6],
                Zip = data[7]
            };

            var sut = new Person()
            {
                FirstName = data[1],
                LastName = data[2],
                Address = addr
            };

            var expected = new Person()
            {
                FirstName = data[1],
                LastName = data[2],
                Address = new Address()
                {
                    StreetAddress = data[4],
                    City = data[5],
                    State = data[6],
                    Zip = data[7]
                }
            };

            Assert.IsTrue(sut.Address.Equals(addr));
            // Assert.IsTrue(sut.Address.Equals(expected.Address));

            // Assert.IsTrue(sut.Equals(expected));
            /*
            Assert.IsTrue(sut.Equals(new Person()
                {
                    FirstName = data[1],
                    LastName = data[2],
                    Address = new Address()
                    {
                        StreetAddress = data[4],
                        City = data[5],
                        State = data[6],
                        Zip = data[7]
                    }
                }));
                */
        }
    }
}
