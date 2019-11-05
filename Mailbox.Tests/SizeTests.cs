using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class SizeTests
    {
        [TestMethod]
        [DataRow(Size.Small)]
        [DataRow(Size.Medium)]
        [DataRow(Size.Large)]
        public void Size_PremiumFlagDoesNotConflict_Success(Size size)
        {
            var sut = Size.Premium | size;
            Assert.AreEqual(size, sut & Size.SizeMask);
        }

        [TestMethod]
        [DataRow(Size.Small)]
        [DataRow(Size.Medium)]
        [DataRow(Size.Large)]
        public void Size_NonPremiumFlagDoesNotConflict_Success(Size size)
        {
            var sut = Size.Premium | size;
            Assert.AreEqual(Size.Premium, sut & ~Size.SizeMask);
        }

        [TestMethod]
        [DataRow("small" 		 , Size.Small)]
        [DataRow("medium" 		 , Size.Medium)]
        [DataRow("large" 		 , Size.Large)]
        [DataRow("small|premium" , Size.SmallPremium)]
        [DataRow("medium|premium", Size.MediumPremium)]
        [DataRow("large|premium" , Size.LargePremium)]
        public void SizeMixins_Parse_ReturnsCorrectSize(string input, Size size)
        {
            Assert.AreEqual(SizeMixins.Parse(input), size);
        }

        [TestMethod]
        public void SizeMixins_Parse_GetsEmptyStringOnBadInput()
        {
            Assert.AreEqual(Size.Small, SizeMixins.Parse("Bad Input"));
        }
    }
}
