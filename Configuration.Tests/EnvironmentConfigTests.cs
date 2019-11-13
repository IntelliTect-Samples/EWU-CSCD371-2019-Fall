using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    // MMM Comment: Why didn't you derive from BaseConfig?  (You did such a great job with that...)
    [TestClass]
    public class EnvironmentConfigTests
    {
        // doing some extra testing on EnvironmentConfig, to make especially sure it's cleaning up

        [DataTestMethod]
        [DataRow("key", "value", DisplayName = "Valid K:V pair")]
        public void Cleanup_RemovesEnvironmentKeyValue_NullEnvironmentVariables(string key, string value)
        {
            // Arrange
            var sut = new EnvironmentConfig();

            // Act
            sut.SetConfigValue(key, value);
            sut.DeleteAllConfigs();

            string? envVar = Environment.GetEnvironmentVariable(key);

            // Cleanup
            Environment.SetEnvironmentVariable(key, null);

            // Assert
            Assert.IsNull(envVar);
        }
    }
}
