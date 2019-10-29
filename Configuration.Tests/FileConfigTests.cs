using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        private static IEnumerable<object[]> ValidSettings
        {
            get
            {
                yield return new object[] { new[] { ("name", "value") } };
                yield return new object[] { new[] { ("name2", "value2"), ("name3", "value3"), ("value4", "value4") } };
                yield return new object[] { new[] { ("name5", "value5"), ("name6", "value6"),
                                                     ("name7", "value7"), ("name8", "value8"),
                                                     ("name9", "value9"), ("final_name", "final_value") } };
            }
        }

        private static IEnumerable<object[]> InValidName =>
        new List<object[]> {
        new object[] { "name 1", "goodValue" },
        new object[] { "name=2", "alsoGoodValue" },
        new object[] { string.Empty, "lastGoodValue"}
        };

        private static IEnumerable<object[]> InValidValue =>
        new List<object[]> {
        new object[] { "name 1", "bad Value" },
        new object[] { "name=2", "alsobad=Value" },
        new object[] { string.Empty, string.Empty}
        };

        private static string Filename { get; } = "ConfigTestFile";


        [TestMethod]
        [DynamicData(nameof(ValidSettings))]
        public void GetConfigValue_ValidSettings_ReturnsTrue((string name, string value)[] settings)
        {
            if (settings != null)
            {
                try
                {
                    FileConfig config = new FileConfig(Filename);
                    File.WriteAllLines(config.Filename, settings.Select(item => $"{item.name}={item.value}"));

                    foreach (var (name, value) in settings)
                    {
                        Assert.IsTrue(config.ReadConfigValue(name, out var readValue));
                        Assert.AreEqual(value, readValue);
                    }
                }
                finally
                {
                    File.Delete(Filename);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateFile_NullName_ThrowsException()
        {
#nullable disable
            _ = new FileConfig(null);
#nullable enable
        }

        [TestMethod]
        [DynamicData(nameof(ValidSettings))]
        public void GetConfigValue_NoSuchName_ReturnsFalse((string name, string value)[] settings)
        {
            try
            {
                FileConfig config = new FileConfig(Filename);
                File.WriteAllLines(config.Filename, settings.Select(item => $"{item.name}={item.value}"));

                Assert.IsFalse(config.ReadConfigValue("NonExistentName", out var readValue));
                Assert.IsNull(readValue);

            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConfigValue_NullName_ThrowsException()
        {
            try
            {
                FileConfig config = new FileConfig(Filename);
#nullable disable
                config.ReadConfigValue(null, out _);
#nullable enable

            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [DynamicData(nameof(InValidName))]
        [ExpectedException(typeof(ArgumentException))]
        public void GetConfigValue_InvalidName_ThrowsException(string name, string? value)
        {
            try
            {
                FileConfig config = new FileConfig(Filename);

               config.ReadConfigValue(name, out value);
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [DynamicData(nameof(InValidName))]
        [ExpectedException(typeof(ArgumentException))]
        public void SetConfigValue_InvalidName_ThrowsException(string name, string value)
        {
            try
            {
                FileConfig config = new FileConfig(Filename);

                config.WriteConfigValue(name, value);

            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [DynamicData(nameof(InValidValue))]
        [ExpectedException(typeof(ArgumentException))]
        public void SetConfigValue_InvalidValues_ThrowsException(string name, string value)
        {
            try
            {
                FileConfig config = new FileConfig(Filename);

                config.WriteConfigValue(name, value);

            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetConfigValue_NullName_ThrowsException()
        {
            try
            {
#nullable disable
                new FileConfig(Filename).WriteConfigValue(null, "value");
#nullable enable
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetConfigValue_NullValue_ThrowsException()
        {
            try
            {
#nullable disable
                new FileConfig(Filename).WriteConfigValue("name", null);
#nullable enable
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [DynamicData(nameof(ValidSettings))]
        public void SetConfigValue_ValidSettings_ReturnsTrue((string name, string value)[] settings)
        {
            if (settings != null)
            {
                try
                {
                    FileConfig config = new FileConfig(Filename);

                    foreach (var (name, value) in settings)
                    {
                        Assert.IsTrue(config.WriteConfigValue(name, value));
                    }


                    string[] lines = File.ReadAllLines(Filename);

                    int i = 0;
                    foreach (var line in lines)
                    {
                        string[] readSettings = line.Split("=");
                        Assert.AreEqual(readSettings[0], settings[i].ToTuple().Item1);
                        Assert.AreEqual(readSettings[1], settings[i].ToTuple().Item2);
                        i++;
                    }
                }
                finally
                {
                    File.Delete(Filename);
                }
            }
        }
    }

}
