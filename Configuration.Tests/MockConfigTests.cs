using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("       ")]
        [DataRow("=")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Invalid_Name_Thrown_Exception(string name)
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            string? value = "";
            mock.GetConfigValue(name, out value);
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
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            mock.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test", "")]
        [DataRow("Test", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Value_Thrown_Exception(string name, string value)
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            mock.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test=", "")]
        [DataRow("T est", null)]
        [DataRow(null, "")]
        [DataRow("=", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_And_Value_Thrown_Exception(string name, string value)
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            mock.SetConfigValue(name, value);
        }

        [TestMethod]
        public void Get_Correct_Value()
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            string? value = "";
            mock.GetConfigValue("Example0", out value);
            Assert.AreEqual("0", value);

            mock.GetConfigValue("Example1", out value);
            Assert.AreEqual("1", value);

            mock.GetConfigValue("Example2", out value);
            Assert.AreEqual("2", value);
        }

        [TestMethod]
        public void Get_Correct_Return()
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            string? value = "";
            Assert.IsTrue(mock.GetConfigValue("Example0", out value));
            Assert.IsTrue(mock.GetConfigValue("Example1", out value));
            Assert.IsTrue(mock.GetConfigValue("Example2", out value));
        }

        [TestMethod]
        public void Get_Incorrect_Value()
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            string? value = "";
            mock.GetConfigValue("Example3", out value);
            Assert.AreEqual("", value);

            mock.GetConfigValue("Example6", out value);
            Assert.AreEqual("", value);

            mock.GetConfigValue("E", out value);
            Assert.AreEqual("", value);
        }

        [TestMethod]
        public void Get_Incorrect_Return()
        {
            IConfig mock = new MockConfig();
            SetValidDataForConfig(mock);

            string? value = "";
            Assert.IsFalse(mock.GetConfigValue("Example7", out value));
            Assert.IsFalse(mock.GetConfigValue("Exam", out value));
            Assert.IsFalse(mock.GetConfigValue("test", out value));
        }

        private void SetValidDataForConfig(IConfig config)
        {
            config.SetConfigValue("Example0", "0");
            config.SetConfigValue("Example1", "1");
            config.SetConfigValue("Example2", "2");
        }
    }
}