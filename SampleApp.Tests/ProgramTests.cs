using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SampleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("       ")]
        [DataRow("=")]
        [DataRow(null)]
        [DataRow("Doesn'tExist")]
        [ExpectedException(typeof(ArgumentException))]
        public void FindSettings_Invalid_Name_Thrown_Exception(string name)
        {
            IConfig mock = new MockConfig();
            Program.FindSetting(mock, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindSettings_Null_Config_Thrown_Exception()
        {
            Program.FindSetting(null, "TestingOne");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindSettings_Null_Name_Thrown_Exception()
        {
            IConfig mock = new MockConfig();
            Program.FindSetting(mock, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Print_Null_Name_Thrown_Exception()
        {
            IConfig mock = new MockConfig();
            Program.PrintConfigSettings(mock, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Print_Null_Config_Thrown_Exception()
        {
            List<string> list = new List<string> { };
            Program.PrintConfigSettings(null, list);
        }

        [TestMethod]
        public void FindSettings_Correct_Values()
        {
            IConfig mock = new MockConfig();
            Assert.AreEqual("TestingOne=1", Program.FindSetting(mock, "TestingOne"));
            Assert.AreEqual("testingTwo=2", Program.FindSetting(mock, "testingTwo"));
            Assert.AreEqual("testingthree=3", Program.FindSetting(mock, "testingthree"));
        }
    }
}