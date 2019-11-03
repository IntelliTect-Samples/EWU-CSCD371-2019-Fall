using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mailbox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class SizeTests
    {
        [DataTestMethod]
        [DataRow(Sizes.None, "", DisplayName = "None")]
        [DataRow(Sizes.Premium, "Premium", DisplayName = "Premium Only")]
        [DataRow(Sizes.Small, "Small", DisplayName = "Small")]
        [DataRow(Sizes.Large|Sizes.Premium, "Large Premium", DisplayName = "Large Premium")]
        public void GetString_FormatsStringProperly_MatchesExpectedResult(Sizes size, string expected)
        {
            string result = size.GetString();

            Assert.AreEqual<string>(expected, result);
        }

        [DataTestMethod]
        [DataRow(Sizes.Small, true, DisplayName = "Small, valid")]
        [DataRow(Sizes.Medium | Sizes.Premium, true, DisplayName = "Medium Premium, valid")]
        [DataRow(Sizes.Medium | Sizes.Large, false, DisplayName = "Medium Large, invalid")]
        [DataRow(Sizes.Medium | Sizes.Small, false, DisplayName = "Medium Small, invalid")]
        [DataRow(Sizes.None, false, DisplayName = "None, invalid")]
        [DataRow(Sizes.Premium, false, DisplayName = "Premium, invalid")]
        public void IsValid_ChecksIfValidSizeFlagCombination_MatchesExpectedBooleanResult(Sizes test, bool expected)
        {
            bool result = test.IsValid();

            Assert.AreEqual<bool>(expected, result);
        }
    }
}