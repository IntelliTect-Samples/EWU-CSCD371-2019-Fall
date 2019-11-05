using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class SizesTests
    {
        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Premium, Sizes.Small)]
        [DataRow(Sizes.Medium | Sizes.Premium, Sizes.Medium)]
        [DataRow(Sizes.Large | Sizes.Premium, Sizes.Large)]
        [DataRow(Sizes.Small, Sizes.Small)]
        [DataRow(Sizes.Medium, Sizes.Medium)]
        [DataRow(Sizes.Large, Sizes.Large)]
        public void Size_ValidSize_CorrectValue(Sizes input, Sizes size)
        {
            Assert.AreEqual(input.Size(), size);
        }

        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Premium, true)]
        [DataRow(Sizes.Medium | Sizes.Premium, true)]
        [DataRow(Sizes.Large | Sizes.Premium, true)]
        [DataRow(Sizes.Small, false)]
        [DataRow(Sizes.Medium, false)]
        [DataRow(Sizes.Large, false)]
        public void Premium_ValidSize_CorrectValue(Sizes input, bool premium)
        {
            Assert.AreEqual(input.Premium(), premium);
        }

        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Premium)]
        [DataRow(Sizes.Medium | Sizes.Premium)]
        [DataRow(Sizes.Large | Sizes.Premium)]
        [DataRow(Sizes.Small)]
        [DataRow(Sizes.Medium)]
        [DataRow(Sizes.Large)]
        public void IsValid_ValidSize_True(Sizes input)
        {
            Assert.IsTrue(input.IsValid());
        }

        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Large)]
        [DataRow(Sizes.Medium | Sizes.Large)]
        [DataRow(Sizes.Large | Sizes.Small)]
        [DataRow(Sizes.Small | Sizes.Medium)]
        [DataRow(Sizes.Undefined)]
        public void IsValid_InvalidSize_True(Sizes input)
        {
            Assert.IsFalse(input.IsValid());
        }
    }
}
