using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configuration;
using Configuration.Tests;
using System.Collections.Generic;

namespace SampleApp.Tests
{
    // MMM Comment: I would have expected you to use MockConfig from here and replace the
    // default use of FileConfig.
    [TestClass]
    public class SampleAppTests
    {
        public static IEnumerable<string[][]> GetData()
        {
            // MMM Comment: Tuples perhaps? :)
            yield return new string[][] { new string[] { "Key1", "Key2", "Key3" }, new string[] { "Value1", "Value2", "Value3" } };
        }

        // MMM Comment: Great use of the DynamicData attribute. :)
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        // MMM Comment: Agreed... I'd disable it for the entire project actually. 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Passing in hardcoded test values that guarantees no null.")]
        public void Iterate_StepsIntoAllKeys_ReturnsCorrectKeyValuePairs(string[] keys, string[] values)
        {
            // Arrange
            BaseConfig config = ConfigFactory.Create("MockConfig");
            for (int i = 0; i < keys.Length; i++) config.SetConfigValue(keys[i], values[i]);

            List<KeyValuePair<string, string>> kvPairs;

            // Act
            kvPairs = Program.IterateKVPairs(config, keys);

            // Cleanup
            config.DeleteAllConfigs();

            // Assert
            for (int i = 0; i < keys.Length; i++)
            {
                Assert.AreEqual<string>(keys[i], kvPairs[i].Key);
                Assert.AreEqual<string>(values[i], kvPairs[i].Value);
            }
        }
    }
}
