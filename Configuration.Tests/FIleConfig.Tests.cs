using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        private static (string name, string value)[] ParseFile(string filename) =>
            (from line in File.ReadAllLines(filename)
             let split = line.Split('=')
             select (split[0], split[1])).ToArray();

        private static void WriteFile(string filename, (string name, string value)[] settings) =>
            File.WriteAllLines(filename, settings.Select(item => $"{item.name}={item.value}"));

        private static string Filename { get; } = $"{nameof(FileConfigTests)}.conf";

        public static IEnumerable<object[]> ValidSettings
        {
            get
            {
                yield return new object[] { new[] { ("name", "value") } };
                yield return new object[] { new[] { ("1plus2", "is3"), ("123", "456"), ("oaofuvono", "oarksocaufo") } };
                yield return new object[] { new[] { ("another_one", "bites_the_dust"), ("myName", "inigoMontoya"),
                                                    ("who-killed-my-father", "you"), ("asWhoWhishes", "you"),
                                                    ("RodentSize", "Unusual"), ("Storming-Destination", "The-Castle") } };
            }
        }

        public static IEnumerable<object[]> InvalidStrings
        {
            get
            {
                yield return new object[] { "" };
                yield return new object[] { "1plus2=3" };
                yield return new object[] { " " };
                yield return new object[] { "two words" };
                yield return new object[] { "three more words" };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ValidSettings))]
        public void SetConfigValue_ValidArgs_AddsSettings((string name, string value)[] settings)
        {
            try
            {
                File.Delete(Filename);

                var config = new FileConfig(Filename);
                foreach (var (name, value) in settings) config.SetConfigValue(name, value);

                foreach (var ((name, value), (readName, readValue)) in settings.Zip(ParseFile(Filename)))
                {
                    Assert.AreEqual(name, readName);
                    Assert.AreEqual(value, readValue);
                }
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        public void SetConfigValue_SettingExists_OverwritesSetting()
        {
            string name = "name";
            string value = "value";
            string newValue = "newValue";
            try
            {
                WriteFile(Filename, new[] { (name, value) });

                new FileConfig(Filename).SetConfigValue(name, newValue);

                var readSettings = ParseFile(Filename);
                Assert.AreEqual(readSettings.Length, 1);
                Assert.AreEqual(readSettings[0].name, name);
                Assert.AreEqual(readSettings[0].value, newValue);
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(InvalidStrings))]
        [ExpectedException(typeof(ArgumentException))]
        public void SetConfigValue_InvalidNames_ThrowsException(string name)
        {
            try
            {
                File.Delete(Filename);

                new FileConfig(Filename).SetConfigValue(name, "value");
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(InvalidStrings))]
        [ExpectedException(typeof(ArgumentException))]
        public void SetConfigValue_InvalidValues_ThrowsException(string value)
        {
            try
            {
                File.Delete(Filename);

                new FileConfig(Filename).SetConfigValue("name", value);
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
            File.Delete(Filename);
            try
            {
#nullable disable
                new FileConfig(Filename).SetConfigValue(null, "value");
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
            File.Delete(Filename);
            try
            {
#nullable disable
                new FileConfig(Filename).SetConfigValue("name", null);
#nullable enable
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
            File.Delete(Filename);
            try
            {
#nullable disable
                new FileConfig(Filename).GetConfigValue(null, out _);
#nullable enable
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(InvalidStrings))]
        [ExpectedException(typeof(ArgumentException))]
        public void GetConfigValue_InvaldName_ThrowsException(string name)
        {
            try
            {
                File.Delete(Filename);

                new FileConfig(Filename).GetConfigValue(name, out _);
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(ValidSettings))]
        public void GetConfigValue_SettingExists_ReadsValue((string name, string value)[] settings)
        {
            try
            {
                WriteFile(Filename, settings);
                var config = new FileConfig(Filename);

                foreach (var (name, value) in settings)
                {
                    bool success = config.GetConfigValue(name, out var readValue);

                    Assert.IsTrue(success);
                    Assert.AreEqual(readValue, value);
                }
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        public void GetConfigValue_SettingDoesntExist_ReturnsNone()
        {
            try
            {
                File.WriteAllText(Filename, string.Empty);

                bool success = new FileConfig(Filename).GetConfigValue("name", out var val);

                Assert.IsFalse(success);
                Assert.IsNull(val);
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        public void GetConfigValue_FileDoesntExist_ReturnsNone()
        {
            try
            {
                File.Delete(Filename);

                bool success = new FileConfig(Filename).GetConfigValue("name", out var val);

                Assert.IsFalse(success);
                Assert.IsNull(val);
            }
            finally
            {
                File.Delete(Filename);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_FilenameIsNull_ThrowsException()
        {
#nullable disable
            new FileConfig(null);
#nullable enable
        }
    }
}
