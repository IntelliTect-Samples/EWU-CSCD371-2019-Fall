﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Configuration;

namespace SampleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void PrintAllSettings_ConfigNotInitialized()
        {
            Program.Config = null;
            Program.PrintAllSettings();
            string expectedResult = "Config not initialized!";

            Assert.AreEqual(expectedResult, Program.SettingList![0]);
        }

        [TestMethod]
        public void Program_RetrievesCorrectAmountOfSettings()
        {
            var mc = new MockConfig();
            Program.Config = mc;
            Program.Main();

            Assert.AreEqual(Program.SettingList!.Count, mc.Settings.Count);
        }

        [TestMethod]
        public void Program_NoSettingsToRetrieve()
        {
            // MMM Comment: Preferable not to use abbreviations IMO.
            var mc = new MockConfig();
            mc.ClearConfig();
            Program.Config = mc;
            Program.Main();
            string expectedResult = "No settings to display.";

            Assert.AreEqual(expectedResult, Program.SettingList![0]);
        }
    }
}
