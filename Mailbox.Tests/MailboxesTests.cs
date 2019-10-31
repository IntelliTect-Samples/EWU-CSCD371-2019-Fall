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
        public void Size_PremiumFlagDoesNotConflict_Success(int size)
        {
            var sut = Size.Premium | size;
            Assert.AreEqual(size, sut & Size.SizeMask);
        }
    }
}
