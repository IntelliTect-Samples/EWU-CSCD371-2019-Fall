using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void EnvironmentConfig_SetConfigTest()
        {
            var sut = new EnvironmentConfig();
            Assert.IsNotNull(sut);
        }
    }
}
