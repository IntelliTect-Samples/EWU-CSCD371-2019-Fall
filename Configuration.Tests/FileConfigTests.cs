using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestInitialize]
        [TestCleanup]
        public void Initialize()
        {
            FileConfig.DeleteFile();
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("       ")]
        [DataRow("=")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Invalid_Name_Thrown_Exception(string name)
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            string? value = "";
            file.GetConfigValue(name, out value);
        }

        [DataTestMethod]
        [DataRow("", " ")]
        [DataRow(" ", " ")]
        [DataRow("       ", " ")]
        [DataRow("=", " ")]
        [DataRow(null, " ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_Thrown_Exception(string name, string value)
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            file.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test", "")]
        [DataRow("Test", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Value_Thrown_Exception(string name, string value)
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            file.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test=", "")]
        [DataRow("T est", null)]
        [DataRow(null, "")]
        [DataRow("=", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_And_Value_Thrown_Exception(string name, string value)
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            file.SetConfigValue(name, value);
        }

        [TestMethod]
        public void Get_Correct_Value()
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            string? value = "";
            file.GetConfigValue("Example0", out value);
            Assert.AreEqual("0", value);

            file.GetConfigValue("Example1", out value);
            Assert.AreEqual("1", value);

            file.GetConfigValue("Example2", out value);
            Assert.AreEqual("2", value);
        }

        [TestMethod]
        public void Get_Correct_Return()
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            string? value = "";
            Assert.IsTrue(file.GetConfigValue("Example0", out value));
            Assert.IsTrue(file.GetConfigValue("Example1", out value));
            Assert.IsTrue(file.GetConfigValue("Example2", out value));
        }

        [TestMethod]
        public void Get_Incorrect_Value()
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            string? value = "";
            file.GetConfigValue("Example3", out value);
            Assert.AreEqual("", value);

            file.GetConfigValue("Example6", out value);
            Assert.AreEqual("", value);

            file.GetConfigValue("E", out value);
            Assert.AreEqual("", value);
        }

        [TestMethod]
        public void Get_Incorrect_Return()
        {
            IConfig file = new FileConfig();
            SetValidDataForConfig(file);

            string? value = "";
            Assert.IsFalse(file.GetConfigValue("Example7", out value));
            Assert.IsFalse(file.GetConfigValue("Exam", out value));
            Assert.IsFalse(file.GetConfigValue("test", out value));
        }

        private void SetValidDataForConfig(IConfig config)
        {
            config.SetConfigValue("Example0", "0");
            config.SetConfigValue("Example1", "1");
            config.SetConfigValue("Example2", "2");
        }
    }
}