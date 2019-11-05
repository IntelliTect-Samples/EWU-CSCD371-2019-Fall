using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class SizeTests
    {
        [DataTestMethod]
        [DataRow(Size.Default, "Default")]
        [DataRow(Size.Small, "Small")]
        [DataRow(Size.Medium, "Medium")]
        [DataRow(Size.Large, "Large")]
        [DataRow(Size.Small | Size.Premium, "Small, Premium")]
        [DataRow(Size.Medium | Size.Premium, "Medium, Premium")]
        [DataRow(Size.Large | Size.Premium, "Large, Premium")]
        public void ExpectedStringValue(Size size, string expectedValue)
        {
            string result = size.ToString();

            Assert.AreEqual(expectedValue, result);
        }

        [DataTestMethod]
        [DataRow(Size.Default, 0)]
        [DataRow(Size.Small, 1)]
        [DataRow(Size.Medium, 2)]
        [DataRow(Size.Large, 4)]
        [DataRow(Size.Small | Size.Premium, 9)]
        [DataRow(Size.Medium | Size.Premium, 10)]
        [DataRow(Size.Large | Size.Premium, 12)]
        public void ExpectedIntValue(Size size, int expectedValue)
        {
            int result = (int)size;

            Assert.AreEqual(expectedValue, result);
        }
    }
}
