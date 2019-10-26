using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
	[TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        [DataRow("name", "value")]
        [DataRow("123", "456")]
        [DataRow("oiaersnotiearnt", "yunawufhaouvhyuawfv")]
        [DataRow("+-\"/", " ")]
        public void SetConfigValue_ValidArgs_SetsEnvVar(string name, string value)
        {
            try
            {
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
            new EnvironmentConfig().SetConfigValue(null, null);
#nullable enable
        }

        [TestMethod]
        public void SetConfigValue_NullValue_DeletesVariable()
        {
            const string name = "varName";
            try
            {
                Environment.SetEnvironmentVariable(name, "value");

                new EnvironmentConfig().SetConfigValue(name, null);

                Assert.IsNull(Environment.GetEnvironmentVariable(name));
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

        [TestMethod]
        [DataRow("name", "value")]
        [DataRow("123", "456")]
        [DataRow("oiaersnotiearnt", "yunawufhaouvhyuawfv")]
        [DataRow("+-\"/", " ")]
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
