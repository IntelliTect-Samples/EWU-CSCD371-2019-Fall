using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void CreateFileConfig_EmptyConstructor_NoErrors()
        {
            _ = new FileConfig();
        }

        [TestMethod]
        public void GetCongfigValue_BadName_ReturnsNull()
        {
            IConfig fileConfig = new FileConfig();
            fileConfig.GetConfigValue("test", out string? output);
            Assert.IsNull(output);
        }

        [TestMethod]
        public void GetCongfigValue_BadName_ReturnsFalse()
        {
            IConfig fileConfig = new FileConfig();
            Assert.IsFalse(fileConfig.GetConfigValue("test", out string? _));
        }

        [TestMethod]
        public void SetCongfigValue_BadName_ReturnsFalse()
        {
            IConfig fileConfig = new FileConfig();
            Assert.IsFalse(fileConfig.SetConfigValue(" =", "validValue"));
        }

        [TestMethod]
        public void SetCongfigValue_NullValue_ReturnsFalse()
        {
            IConfig fileConfig = new FileConfig();
            Assert.IsFalse(fileConfig.SetConfigValue("validName", null));
        }
    }
}