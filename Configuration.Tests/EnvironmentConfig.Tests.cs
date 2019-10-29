using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [DataTestMethod]
        [DataRow("name", "value")]
        [DataRow("123", "456")]
        [DataRow("oiaersnotiearnt", "yunawufhaouvhyuawfv")]
        [DataRow("+-\"/", "!!")]
        public void SetConfigValue_ValidArgs_SetsEnvVar(string name, string value)
        {
            try
            {
                Environment.SetEnvironmentVariable(name, null);

                new EnvironmentConfig().SetConfigValue(name, value);
                Assert.AreEqual(Environment.GetEnvironmentVariable(name), value);
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetConfigValue_NullName_ThrowsException()
        {
#nullable disable
            new EnvironmentConfig().SetConfigValue(null, "value");
#nullable enable
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("1plus2=3")]
        [DataRow("two words")]
        [DataRow("three more words")]
        public void SetConfigValue_InvalidName_ThrowsException(string name)
        {
            try
            {
                Environment.SetEnvironmentVariable(name, null);

                new EnvironmentConfig().SetConfigValue(name, "value");
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetConfigValue_NullValue_ThrowsException()
        {
            string name = "name";
            try
            {
#nullable disable
                new EnvironmentConfig().SetConfigValue(name, null);
#nullable enable
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("1plus2=3")]
        [DataRow("two words")]
        [DataRow("three more words")]
        public void SetConfigValue_InvalidValue_ThrowsException(string value)
        {
            string name = "name";
            try
            {
                Environment.SetEnvironmentVariable(name, null);

                new EnvironmentConfig().SetConfigValue(name, value);
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConfigValue_NullName_ThrowsException()
        {
#nullable disable
            new EnvironmentConfig().GetConfigValue(null, out _);
#nullable enable
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("1plus2=3")]
        [DataRow("two words")]
        [DataRow("three more words")]
        public void GetConfigValue_InvalidName_ThrowsException(string name)
        {
            new EnvironmentConfig().GetConfigValue(name, out _);
        }

        [DataTestMethod]
        [DataRow("name", "value")]
        [DataRow("123", "456")]
        [DataRow("oiaersnotiearnt", "yunawufhaouvhyuawfv")]
        [DataRow("+-\"/", "!!")]
        public void GetConfigValue_VariableExists_ReadsValue(string name, string value)
        {
            try
            {
                Environment.SetEnvironmentVariable(name, value);

                bool success = new EnvironmentConfig().GetConfigValue(name, out var val);

                Assert.IsTrue(success);
                Assert.AreEqual(val, value);
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        [TestMethod]
        public void GetConfigValue_VariableDoesntExist_ReturnsNone()
        {
            const string name = "fakeVar";
            try
            {
                Environment.SetEnvironmentVariable(name, null);

                bool success = new EnvironmentConfig().GetConfigValue(name, out var val);

                Assert.IsFalse(success);
                Assert.IsNull(val);
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
