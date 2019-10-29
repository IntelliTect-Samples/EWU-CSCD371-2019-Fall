using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
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
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            string? value = "";
            environment.GetConfigValue(name, out value);
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
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            environment.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test", "")]
        [DataRow("Test", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Value_Thrown_Exception(string name, string value)
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            environment.SetConfigValue(name, value);
        }

        [DataTestMethod]
        [DataRow("Test=", "")]
        [DataRow("T est", null)]
        [DataRow(null, "")]
        [DataRow("=", null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_Invalid_Name_And_Value_Thrown_Exception(string name, string value)
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            environment.SetConfigValue(name, value);
        }

        [TestMethod]
        public void Get_Correct_Value()
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            string? value = "";
            environment.GetConfigValue("Example0", out value);
            Assert.AreEqual("0", value);

            environment.GetConfigValue("Example1", out value);
            Assert.AreEqual("1", value);

            environment.GetConfigValue("Example2", out value);
            Assert.AreEqual("2", value);
        }

        [TestMethod]
        public void Get_Correct_Return()
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            string? value = "";
            Assert.IsTrue(environment.GetConfigValue("Example0", out value));
            Assert.IsTrue(environment.GetConfigValue("Example1", out value));
            Assert.IsTrue(environment.GetConfigValue("Example2", out value));
        }

        [TestMethod]
        public void Get_Incorrect_Value()
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            string? value = "";
            environment.GetConfigValue("Example3", out value);
            Assert.IsNull(value);

            environment.GetConfigValue("Example6", out value);
            Assert.IsNull(value);

            environment.GetConfigValue("E", out value);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void Get_Incorrect_Return()
        {
            IConfig environment = new EnvironmentConfig();
            SetValidDataForConfig(environment);

            string? value = "";
            Assert.IsFalse(environment.GetConfigValue("Example7", out value));
            Assert.IsFalse(environment.GetConfigValue("Exam", out value));
            Assert.IsFalse(environment.GetConfigValue("test", out value));
        }

        private void SetValidDataForConfig(IConfig config)
        {
            config.SetConfigValue("Example0", "0");
            config.SetConfigValue("Example1", "1");
            config.SetConfigValue("Example2", "2");
        }
    }
}
