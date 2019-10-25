using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Configuration;
using Mock;

namespace SampleApp.Tests
{
    [TestClass]
    public class SampleAppTests
    {
        [TestMethod]
        public void SampleApp_MockConfig_SetValuesSuccess()
        {
            // arrange
            var sut = new Program()
            {
                Config = new MockConfig()
            };

            // act
            sut.SetValues();

            // assert
            foreach (var (name, value) in Program.SettingValues)
            {
                string? outValue;
                Assert.IsTrue(sut.Config.GetConfigValue(name, out outValue));
                Assert.IsNotNull(outValue);
                Assert.AreEqual(value, outValue);
            }
        }

        [TestMethod]
        public void SampleApp_EnvironmentConfig_SetValuesSuccess()
        {
            // arrange
            var sut = new Program();
            sut.Config = new EnvironmentConfig();

            // act
            sut.SetValues();

            // assert
            foreach (var (name, value) in Program.SettingValues)
            {
                string? outValue;
                Assert.IsTrue(sut.Config.GetConfigValue(name, out outValue));
                Assert.IsNotNull(outValue);
                Assert.AreEqual(value, outValue);
            }
        }

        [TestMethod]
        public void SampleApp_FileConfig_SetValuesSuccess()
        {
            // arrange
            var sut = new Program()
            {
                Config = new FileConfig()
            };

            // act
            sut.SetValues();

            // assert
            foreach (var (name, value) in Program.SettingValues)
            {
                string? outValue;
                Assert.IsTrue(sut.Config.GetConfigValue(name, out outValue));
                Assert.IsNotNull(outValue);
                Assert.AreEqual(value, outValue);
            }
        }

        [TestMethod]
        public void SampleApp_MockConfig_GetValuesSuccess()
        {
            // arrange
            var sut = new Program()
            {
                Config = new MockConfig()
            };

            // act
            sut.GetValues();

            // assert
        }

        [TestMethod]
        public void SampleApp_EnvironmentConfig_GetValuesSuccess()
        {
            // arrange
            var sut = new Program()
            {
                Config = new EnvironmentConfig()
            };

            // act
            sut.GetValues();

            // assert
        }

        [TestMethod]
        public void SampleApp_FileConfig_GetValuesSuccess()
        {
            // arrange
            var sut = new Program()
            {
                Config = new FileConfig()
            };

            // act
            sut.GetValues();

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SampleApp_RunApp_ThrowsExceptionOnBadArg()
        {
            Program.RunApp("SomeUnsupportedConfigtype");
        }
    }
}
