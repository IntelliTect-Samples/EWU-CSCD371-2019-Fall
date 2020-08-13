using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void FileConfigSetConfig()
        {
            var sut = new FileConfig();
            sut.GetConfigValue("Hello", out string? s);

            
        }
    }
}
