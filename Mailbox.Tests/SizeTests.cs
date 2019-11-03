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
        [DataRow(Sizes.Small, "Small")]
        [DataRow(Sizes.Large|Sizes.Premium, "Large Premium")]
        public void GetString_FormatsStringProperly_MatchesExpectedResult(Sizes size, string expected)
        {
            string result = size.GetString();

            Assert.AreEqual<string>(expected, result);
        }

        [DataTestMethod]
        [DataRow(Sizes.Small | Sizes.Medium,  Sizes.Medium,  DisplayName = "SM + MD -> MD")]
        [DataRow(Sizes.Large | Sizes.Medium | Sizes.Premium,  Sizes.Large | Sizes.Premium,  DisplayName = "LG + MD + PR -> LG + PR")]
        public void Verify_CorrectsInvalidCombinations_MatchesExpectedCombination(Sizes test, Sizes expected)
        {
            Sizes result = test.Verify();

            Assert.AreEqual<Sizes>(expected, result);
        }

        [DataTestMethod]
        [DataRow(Sizes.Small, Sizes.Small, DisplayName = "Small")]
        [DataRow(Sizes.Medium | Sizes.Premium, Sizes.Medium | Sizes.Premium, DisplayName = "Medium Premium")]
        public void Verify_ValidCombinations_ReturnsUnchangedCombination(Sizes test, Sizes expected)
        {
            Sizes result = test.Verify();

            Assert.AreEqual<Sizes>(expected, result);
        }
    }
}