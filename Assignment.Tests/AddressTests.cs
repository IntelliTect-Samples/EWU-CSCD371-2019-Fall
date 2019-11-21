using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void AddressEquals_ThrowsExceptionOnNullOther()
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

        [TestMethod]
        public void AddressEquals_SuccessOnSameData()
        {
            var sut = new Address()
            {
                StreetAddress = "Some St.",
                City = "Spokane",
                State = "WA",
                Zip = "99218"
            };

            Assert.IsTrue(sut.Equals(new Address()
                {
                    StreetAddress = "Some St.",
                    City = "Spokane",
                    State = "WA",
                    Zip = "99218"
                }));
        }
    }
}
