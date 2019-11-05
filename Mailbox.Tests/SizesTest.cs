using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class SizesTest
    {
        [TestMethod]
        public void IsValid_InvalidSizes_ReturnsFalse()
        {
            Assert.IsFalse(SizeExtensions.IsValid((Mailbox.Sizes)7));
            Assert.IsFalse(SizeExtensions.IsValid((Mailbox.Sizes)3));
            Assert.IsFalse(SizeExtensions.IsValid((Mailbox.Sizes)5));
            Assert.IsFalse(SizeExtensions.IsValid(Sizes.Premium));
            Assert.IsFalse(SizeExtensions.IsValid(Sizes.Small | Sizes.Medium));
        }

        [TestMethod]
        public void IsValid_ValidSizes_ReturnsTrue()
        {
            Assert.IsTrue(SizeExtensions.IsValid((Mailbox.Sizes)1));
            Assert.IsTrue(SizeExtensions.IsValid((Mailbox.Sizes)4));
            Assert.IsTrue(SizeExtensions.IsValid((Mailbox.Sizes)9));
            Assert.IsTrue(SizeExtensions.IsValid(Sizes.Premium | Sizes.Large));
            Assert.IsTrue(SizeExtensions.IsValid((Mailbox.Sizes)0));
        }
    }
}
