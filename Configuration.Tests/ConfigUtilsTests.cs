using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class ConfigUtilsTests
    {
        [DataTestMethod]
        [DataRow("validName", true)]
        [DataRow(" space name ", false)]
        [DataRow("=equals=name", false)]
        [DataRow(null, false)]
        public void IsValidName_ValidAndInvalidNames_ReturnsTrueOrFalse(string? name, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, ConfigUtils.IsValidName(name));
        }
    }
}